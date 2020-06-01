using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordLib.Models
{
    public interface IRecorderHelper
    {
        /// <summary>
        /// 录屏初始化
        /// </summary>
        /// <returns></returns>
        bool RecorderInitialization();

        bool RecorderUnInitialization();

        /// <summary>
        /// 开始录屏
        /// </summary>
        /// <returns></returns>
        bool StartRecord();

        /// <summary>
        /// 暂停录屏
        /// </summary>
        /// <returns></returns>
        bool PauseRecord();

        /// <summary>
        /// 继续录屏
        /// </summary>
        /// <returns></returns>
        bool ContinueRecord();

        /// <summary>
        /// 停止录屏
        /// </summary>
        /// <returns></returns>
        bool StopRecord();

        /// <summary>
        /// 是否正在录屏
        /// </summary>
        /// <returns></returns>
        bool IsRecording();
    }
}
