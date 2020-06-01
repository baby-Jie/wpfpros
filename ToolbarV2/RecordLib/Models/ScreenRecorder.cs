using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordLib.Models
{
    public abstract class ScreenRecorder
    {
        protected ScreenRecorderSetting _recorderSetting;

        public ScreenRecorderSetting RecorderSetting
        {
            get { return _recorderSetting; }
        }

        /// <summary>
        /// 初始化录制
        /// </summary>
        /// <returns></returns>
        public abstract ScreenRecorderResult InitializeRecord();

        /// <summary>
        /// 卸载录制
        /// </summary>
        public abstract void UninitializeRecord();

        /// <summary>
        /// 设置许可证
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public abstract ScreenRecorderResult SetLicense();

        /// <summary>
        /// 根据配置开始录制
        /// </summary>
        /// <param name="recorderSetting"></param>
        /// <returns></returns>
        public abstract ScreenRecorderResult StartRecord(ScreenRecorderSetting recorderSetting);

        /// <summary>
        /// 停止录制
        /// </summary>
        /// <returns></returns>
        public abstract ScreenRecorderResult StopRecord();

        /// <summary>
        /// 暂停录制
        /// </summary>
        /// <returns></returns>
        public abstract ScreenRecorderResult PauseRecord();

        /// <summary>
        /// 恢复录制
        /// </summary>
        /// <returns></returns>
        public abstract ScreenRecorderResult ResumeRecord();

        /// <summary>
        /// 获取录制时间
        /// </summary>
        /// <returns></returns>
        public abstract TimeSpan GetRecordTime();

        /// <summary>
        /// 检测系统音频输入设备时候可用
        /// </summary>
        /// <param name="playBack"></param>
        /// <returns></returns>
        public abstract bool IsAudioInputDeviceEnable();

        /// <summary>
        /// 检测系统音频输出设备时候可用
        /// </summary>
        /// <returns></returns>
        public abstract bool IsAudioOutputDeviceEnable();

        /// <summary>
        /// 判断是否正在录屏
        /// </summary>
        /// <returns></returns>
        public abstract bool IsRecording();

        public abstract bool IsPausing();

    }

    public enum ScreenCaptureMode
    {
        FullScreen,
        FullScreenNoTaskbar,
        Rect,
        LastChoose
    }

    public enum ScreenRecorderResult
    {
        Success = 0,
        InitialzedError = 1,
        IsRecording,
        IsNotRecording,
        IsPausing,
        IsNotPausing,
        StartRecordingError,
        PauseRecordingError,
        ResumeRecordingError,
        LicenseError,
    }

    public enum VideoType
    {
        Mp4,
        Flv,
        Avi,
    }

    public enum AudioMode
    {
        Speaker,
        Microphone,
        SpeakerAndMicrophone
    }

    public enum RecordQuality
    {
        High = 1,
        Standard = 23,
        Low = 40,
    }

    public enum RecordStatus
    {
        NoRecord = 0, // 没有录屏
        Recording, // 正在录屏
        Pause, // 暂停录屏
        RecordComplete, // 录屏完成
    }
}
