using RecordLib.CommonTools;
using System;
using System.Timers;
using System.Windows;

namespace RecordLib.Views
{
    /// <summary>
    /// WpfCountdown.xaml 的交互逻辑
    /// </summary>
    public partial class WpfCountdown : Window
    {
        /// <summary>
        /// <para>剩余倒计时秒数</para>
        /// <para>注：会比实际秒数多一秒用于显示倒计时 0</para>
        /// </summary>
        private int _second = 0;

        private Timer _timer;

        /// <summary>
        /// <para>倒计时窗口</para>
        /// <para>注：会比实际秒数多一秒用于显示倒计时 0</para>
        /// </summary>
        /// <param name="second">倒计时秒数</param>
        public WpfCountdown(int second)
        {
            InitializeComponent();
            _timer = new Timer(1000);
            _timer.Enabled = true;
            _timer.Elapsed += Timer_Elapsed;

            _second = second;
            //messageLabel.Content = SR.GetString(SR.CountdownForm_Message);
            timeLabel.Content = _second.ToString();
        }

        void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.BeginInvoke((Action)(() =>
            {
                _second--;
                if (_second > -1)
                {
                    timeLabel.Content = _second.ToString();
                    return;
                }
                _timer.Enabled = false;
                _timer.Dispose();

                Close();
            }));
        }

        private void WpfCountdown_OnLoaded(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// 设置此窗口的owner
        /// </summary>
        private void SetOwner()
        {
            this.Owner =AppUtils.Owner;
        }
    }
}
