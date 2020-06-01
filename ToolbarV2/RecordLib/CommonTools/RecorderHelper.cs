using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using RecordLib.Models;
using RecordLib.Views;

namespace RecordLib.CommonTools
{
    /// <summary>
    /// 用于全局录屏使用
    /// 使用方法:
    /// 1. InitializeRecorder
    /// 2. 如果IsInitialized为true后，可以开始录屏操作
    /// 3. 程序关闭前 UnInitializeRecorder
    /// </summary>
    public static class RecorderHelper
    {
        private static CommonScreenRecorder _screenRecorder = new ABScreenRecorder(); // 录屏工具
        private static ScreenRecorderSetting _recorderSetting = new ABScreenRecorderSetting(); // 录屏配置
        private static RecordingToolWin _recordingToolWin; // 录屏工具栏
        public static bool IsStoppedByForce { get; set; } // 是否被强制终止

        public static bool IsInitialized
        {
            get;
            private set;
        }

        /// <summary>
        /// 初始化错误
        /// </summary>
        public static bool IsInitializedError
        {
            get;
            private set;
        }

        /// <summary>
        /// 录制视频的时长，在录制停止时进行赋值
        /// </summary>
        public static TimeSpan RecordTime
        {
            get;
            private set;
        }

        /// <summary>
        /// 开始录制的时间
        /// </summary>
        public static DateTime StartRecordTime
        {
            get;
            private set;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public static void InitializeRecorder()
        {
            ScreenRecorderResult ret = _screenRecorder.InitializeRecord();
            if (ret != ScreenRecorderResult.Success)
            {
                MessageBox.Show("初始化失败, 错误信息:" + ret, "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                IsInitializedError = true;
                return;
            }
            ret = _screenRecorder.SetLicense();
            if (ret != ScreenRecorderResult.Success)
            {
                MessageBox.Show("设置许可证失败，错误信息:" + ret, "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                IsInitializedError = true;
                return;
            }

            IsInitialized = true;

            ConfigureRecordSetting();
        }

        /// <summary>
        /// 卸载
        /// </summary>
        public static void UnInitializeRecorder()
        {
            _screenRecorder.UninitializeRecord();
        }

        /// <summary>
        /// 配置录屏参数
        /// </summary>
        private static void ConfigureRecordSetting()
        {
            _recorderSetting.IsAduioEnable = true;
            _recorderSetting.AudioMode = AudioMode.SpeakerAndMicrophone; // 麦克风和电脑音
            _recorderSetting.RecordQuality = RecordQuality.Standard;
            _recorderSetting.ScreenCaptureMode = ScreenCaptureMode.FullScreen;
            _recorderSetting.CaptureRect = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
        }

        /// <summary>
        /// 显示倒计时
        /// </summary>
        /// <param name="ownerWindow"></param>
        private static void ShowRecordCountDown(Window ownerWindow = null)
        {
            WpfCountdown countDownWpf = new WpfCountdown(3);

            if (ownerWindow != null)
            {
                countDownWpf.Owner = ownerWindow;
            }

            countDownWpf.ShowDialog();
        }

        /// <summary>
        /// 开始录屏（录屏工具录屏）
        /// </summary>
        public static void StartRecord(Window windowOwner = null)
        {
            AppUtils.Owner = windowOwner;
            bool success = AppUtils.CheckDisk();

            if (!success)
            {
                InvokeRecordStateChanged(RecordStatus.NoRecord);
                return;
            }

            bool isAudioInputDeviceEnable = IsAudioInputDeviceEnable();
            bool isAudioOutputDeviceEnable = IsAudioOutputDeviceEnable();

            if (!(isAudioInputDeviceEnable && isAudioOutputDeviceEnable))
            {
                var res = MessageBox.Show(null, "没有音频设备，是否继续录制？", "提示");

                if (res != MessageBoxResult.OK)
                {
                    InvokeRecordStateChanged(RecordStatus.NoRecord);
                    return;
                }
            }

            ShowRecordCountDown(windowOwner);
            var ret = StartRecording();
            if (ret != ScreenRecorderResult.Success)
            {
                // 开始录课失败
            }
            StartRecordTime = DateTime.Now;
            _recordingToolWin = new RecordingToolWin();
            _recordingToolWin.Owner = windowOwner;
            _recordingToolWin.Show();
        }

        /// <summary>
        /// 开始录屏
        /// </summary>
        /// <returns></returns>
        public static ScreenRecorderResult StartRecording()
        {
            ScreenRecorderResult ret = _screenRecorder.StartRecord(_recorderSetting);
            InvokeRecordStateChanged(RecordStatus.Recording);

            return ret;
        }

        /// <summary>
        /// 停止录屏
        /// </summary>
        /// <returns></returns>
        public static ScreenRecorderResult StopRecording(Window windowOwner = null)
        {
            int checkCount = 0;
            string recordFilePath = GetRecordFilePath();

            while (true)
            {
                if (checkCount > 10)
                {
                    break;
                }

                if (AppUtils.GetFileSizeSafe(recordFilePath) < 2048)
                {
                    Thread.Sleep(200);
                    checkCount++;
                }
                else
                {
                    break;
                }
            }

            ScreenRecorderResult ret = _screenRecorder.StopRecord();
            string microName = string.Empty;

            if (!string.IsNullOrWhiteSpace(recordFilePath))
            {
                string tempFileName = System.IO.Path.GetFileName(recordFilePath);
                microName = Path.GetFileNameWithoutExtension(tempFileName);
            }

            bool needSaveWindow = false;
            if (needSaveWindow)
            {
                RecordSaveWin win = new RecordSaveWin();
                if (windowOwner != null)
                {
                    win.Owner = windowOwner;
                }

                win.SaveFileNameTbox.Text = microName;

                win.ShowDialog();
                win.SaveRecordAndDeleteFile();
            }
            else
            {
                RecordSaveWin.SaveRecordAndDeleteFile(microName);
            }
            InvokeRecordStateChanged(RecordStatus.RecordComplete);

            _recordingToolWin?.Close();
            _recordingToolWin = null;

            EmptyRecordFilePath();

            return ret;
        }

        /// <summary>
        /// 暂停录屏
        /// </summary>
        /// <returns></returns>
        public static ScreenRecorderResult PauseRecording()
        {
            ScreenRecorderResult ret = _screenRecorder.PauseRecord();
            InvokeRecordStateChanged(RecordStatus.Pause);

            return ret;
        }

        /// <summary>
        /// 恢复录屏
        /// </summary>
        /// <returns></returns>
        public static ScreenRecorderResult ResumeRecording()
        {
            ScreenRecorderResult ret = _screenRecorder.ResumeRecord();
            InvokeRecordStateChanged(RecordStatus.Recording);

            return ret;
        }

        /// <summary>
        /// 判断是否正在录制中
        /// </summary>
        /// <returns></returns>
        public static bool IsRecording()
        {
            return _screenRecorder.IsRecording();
        }

        /// <summary>
        /// 判断是否暂停中
        /// </summary>
        /// <returns></returns>
        public static bool IsPausing()
        {
            return _screenRecorder.IsPausing();
        }

        /// <summary>
        /// 获取录制时间
        /// </summary>
        /// <returns></returns>
        public static TimeSpan GetRecordingTime()
        {
            return _screenRecorder.GetRecordTime();
        }

        /// <summary>
        /// 获取录制文件路径
        /// </summary>
        /// <returns></returns>
        public static string GetRecordFilePath()
        {
            return _screenRecorder.RecorderSetting.SaveRecordFilePath;
        }

        /// <summary>
        /// 清空录制路径
        /// </summary>
        public static void EmptyRecordFilePath()
        {
            _screenRecorder.RecorderSetting.SaveRecordFilePath = string.Empty;
        }

        /// <summary>
        /// 设置录制工具 置顶
        /// </summary>
        public static void SetRecordToolTopmost()
        {
            _recordingToolWin?.SetTopmost();
        }

        /// <summary>
        /// 音频输入设备是否可用
        /// </summary>
        /// <returns></returns>
        public static bool IsAudioInputDeviceEnable()
        {
            return _screenRecorder.IsAudioInputDeviceEnable();
        }

        /// <summary>
        /// 音频输出设备是否可用
        /// </summary>
        /// <returns></returns>
        public static bool IsAudioOutputDeviceEnable()
        {
            return _screenRecorder.IsAudioOutputDeviceEnable();
        }

        /// <summary>
        /// 录屏状态发生变换
        /// </summary>
        private static void InvokeRecordStateChanged(RecordStatus recordStatus)
        {
            //AppUtils.SendMessage(recordStatus, AppConstants.MSG_GLOBAL_RECORDSTATECHANGED);
            RecordStatusChangedEvent?.Invoke(null, recordStatus);
        }

        public static event EventHandler<RecordStatus> RecordStatusChangedEvent;
    }
}
