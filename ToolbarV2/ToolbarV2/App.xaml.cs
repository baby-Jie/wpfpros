using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using RecordLib.CommonTools;

namespace ToolbarV2
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            RecorderHelper.InitializeRecorder();
        }

        private void App_OnExit(object sender, ExitEventArgs e)
        {
            RecorderHelper.UnInitializeRecorder();
        }
    }
}
