using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordLib.Models
{
    public class ABScreenRecorder : CommonScreenRecorder
    {
        #region Override Methods

        /// <summary>
        /// 初始化录制
        /// </summary>
        /// <returns></returns>
        public override ScreenRecorderResult InitializeRecord()
        {
            bool success = ZFTqgv.TFL.TeoNjd_Kokukbnjzf();
            if (success)
                return ScreenRecorderResult.Success;
            else
                return ScreenRecorderResult.InitialzedError;
        }

        /// <summary>
        /// 卸载录制
        /// </summary>
        public override void UninitializeRecord()
        {
            ZFTqgv.TFL.TeoNjd_Wokokukbnjzf();
        }

        /// <summary>
        /// 设置许可证
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public override ScreenRecorderResult SetLicense()
        {
            bool success = ZFTqgv.TFL.TeoNjd_UfvMkdgoufY("zdsoft", "support@zdsoft.com", "E187C-121DE-J1A52-DEP25-63VC0");
            if (success)
            {
                return ScreenRecorderResult.Success;
            }
            else
            {
                return ScreenRecorderResult.LicenseError;
            }
        }

        /// <summary>
        /// 根据配置开始录制
        /// </summary>
        /// <param name="recorderSetting"></param>
        /// <returns></returns>
        public override ScreenRecorderResult StartRecord(ScreenRecorderSetting recorderSetting)
        {
            bool success = false;

            if (ZFTqgv.TFL.TeoNjd_KtTfeptekoi())
            {
                return ScreenRecorderResult.IsRecording;
            }

            ConfigureRecorderSetting(recorderSetting);
            _recorderSetting = recorderSetting;

            success = ZFTqgv.TFL.TeoNjd_UucsvSgdqsfjph();

            return success ? ScreenRecorderResult.Success : ScreenRecorderResult.StartRecordingError;
        }

        /// <summary>
        /// 停止录制
        /// </summary>
        /// <returns></returns>
        public override ScreenRecorderResult StopRecord()
        {
            if (!ZFTqgv.TFL.TeoNjd_KtTfeptekoi())
            {
                return ScreenRecorderResult.IsNotRecording;
            }

            ZFTqgv.TFL.TeoNjd_UuqqTfeptekoi();

            return ScreenRecorderResult.Success;
        }

        /// <summary>
        /// 暂停录制
        /// </summary>
        /// <returns></returns>
        public override ScreenRecorderResult PauseRecord()
        {
            if (!ZFTqgv.TFL.TeoNjd_KtTfeptekoi())
            {
                return ScreenRecorderResult.IsNotRecording;
            }

            if (ZFTqgv.TFL.TeoNjd_KtRbwtge())
            {
                return ScreenRecorderResult.IsPausing;
            }

            bool success = ZFTqgv.TFL.TeoNjd_RbwtgSgdqsfjph();

            if (success)
            {
                return ScreenRecorderResult.Success;
            }
            else
            {
                return ScreenRecorderResult.PauseRecordingError;
            }
        }

        /// <summary>
        /// 恢复录制
        /// </summary>
        /// <returns></returns>
        public override ScreenRecorderResult ResumeRecord()
        {
            if (!ZFTqgv.TFL.TeoNjd_KtTfeptekoi())
            {
                return ScreenRecorderResult.IsNotRecording;
            }

            if (!ZFTqgv.TFL.TeoNjd_KtRbwtge())
            {
                return ScreenRecorderResult.IsNotPausing;
            }

            bool success = ZFTqgv.TFL.TeoNjd_TfuvofTfeptekoi();
            if (success)
            {
                return ScreenRecorderResult.Success;
            }
            else
            {
                return ScreenRecorderResult.ResumeRecordingError;
            }
        }

        /// <summary>
        /// 获取录制时间
        /// </summary>
        /// <returns></returns>
        public override TimeSpan GetRecordTime()
        {
            uint duration = ZFTqgv.TFL.TeoNjd_IfvSgdVjof();
            TimeSpan timeSpan = new TimeSpan(0, 0, 0, 0, (int)duration);
            return timeSpan;
        }

        /// <summary>
        /// 检测系统音频输入设备时候可用
        /// </summary>
        /// <param name="playBack"></param>
        /// <returns></returns>
        public override bool IsAudioInputDeviceEnable()
        {
            return ZFTqgv.TFL.TeoNjd_IfvBwekpUpwsefFfxjefY(false, -1, new StringBuilder(500));
        }

        /// <summary>
        /// 检测系统音频输出设备时候可用
        /// </summary>
        /// <returns></returns>
        public override bool IsAudioOutputDeviceEnable()
        {
            return ZFTqgv.TFL.TeoNjd_IfvBwekpUpwsefFfxjefY(true, -1, new StringBuilder(500));
        }

        /// <summary>
        /// 判断是否正在录屏
        /// </summary>
        /// <returns></returns>
        public override bool IsRecording()
        {
            return ZFTqgv.TFL.TeoNjd_KtTfeptekoi();
        }

        public override bool IsPausing()
        {
            return ZFTqgv.TFL.TeoNjd_KtRbwtge();
        }

        #endregion Override Methods

        #region Private Methods

        /// <summary>
        /// 配置录制设置
        /// </summary>
        /// <param name="recorderSetting"></param>
        private void ConfigureRecorderSetting(ScreenRecorderSetting recorderSetting)
        {
            ZFTqgv.TFL.TeoNjd_UfvWkegpRbviY(recorderSetting.SaveRecordFilePath);

            #region AudioConfiguration
            if (!recorderSetting.IsAduioEnable)
            {
                SetAudioOutputConfig(false, false);
            }
            else
            {
                switch (recorderSetting.AudioMode)
                {
                    case AudioMode.Speaker:
                        SetAudioOutputConfig(true, false);
                        break;
                    case AudioMode.Microphone:
                        SetAudioOutputConfig(false, true);
                        break;
                    case AudioMode.SpeakerAndMicrophone:
                        SetAudioOutputConfig(true, true);
                        break;
                }
            }
            #endregion AudioConfiguration

            if (recorderSetting.ScreenIndex != -1 || recorderSetting.ScreenCaptureMode == ScreenCaptureMode.Rect)
            {
                ZFTqgv.TFL.TeoNjd_UfvDcqvvtfTfijqo(recorderSetting.CaptureRect.Left, recorderSetting.CaptureRect.Top,
                    recorderSetting.CaptureRect.Right, recorderSetting.CaptureRect.Bottom);
            }
            else
            {
                ZFTqgv.TFL.TeoNjd_UfvDcqvvtfTfijqo(0, 0, 0, 0);
            }

            int recordQuality = (int)recorderSetting.RecordQuality;
            ZFTqgv.TFL.TeoNjd_UfvWkegpSvcmkuy(recordQuality);

            // 鼠标效果
            ZFTqgv.TFL.TeoNjd_CefDwsuptFhggdvt(true, true, false, true);

            // 更改鼠标外圈颜色
            //uint highlightColor = 0;
            //uint leftClickColor = 0;
            //uint rightClickColor = 0;
            //uint trackColor = 0;
            //ZFTqgv.TFL.TeoNjd_IfvDwsuptFhggdvtColors(ref highlightColor, ref leftClickColor, ref rightClickColor, ref trackColor);

            //highlightColor = 65535;

            //ZFTqgv.TFL.TeoNjd_UfvDwsuptFhggdvtEpnptt(highlightColor, leftClickColor, rightClickColor, trackColor);
        }

        /// <summary>
        /// 设置音频输出
        /// </summary>
        /// <param name="isSpeakerEnable"></param>
        /// <param name="isMicrophoneEnable"></param>
        private void SetAudioOutputConfig(bool isSpeakerEnable, bool isMicrophoneEnable)
        {
            ZFTqgv.TFL.TeoNjd_TfepteCvfjqTqvtdg(true, isSpeakerEnable);
            ZFTqgv.TFL.TeoNjd_TfepteCvfjqTqvtdg(false, isMicrophoneEnable);
        }

        #endregion Private Methods
    }
}
