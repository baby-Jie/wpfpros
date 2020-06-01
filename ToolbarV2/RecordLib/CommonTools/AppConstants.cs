using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordLib.CommonTools
{
    class AppConstants
    {
        public const long RECORD_CHECK_SIZE = 300L * 1024 * 1024; // 300MB
        public const long RECORD_WARNING_LEVEL = 200L * 1024 * 1024; // 200MB
        public const long RECORD_STOP_LEVEL = 100L * 1024 * 1024; // 100MB

        public const string MSG_GLOBAL_RECORDSTATECHANGED = "MSG_GLOBAL_RECORDSTATECHANGED"; // 录屏状态发生变化

        public const string MUTEX_STR = @"Global\SingletonAppMutextScreenRecorder";
    }
}
