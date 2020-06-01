using RecordLib.CommonTools;
using RecordLib.Models;
using System;
using System.ComponentModel;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace RecordLib.Views
{
    /// <summary>
    /// RecordingToolWin.xaml 的交互逻辑
    /// </summary>
    public partial class RecordingToolWin : Window
    {
        #region fields

        //private readonly MainWindow RecorderHelper;
        private Timer _countDownTimer;
        private Timer _topmostTimer;
        private bool _recordingEllipseColor = false;
        private int _fileSizeQueryCount = 0;
        private int _diskFreeSizeQueryCount = 0;
        private bool _disk300Warnninged = false;

        #endregion fields

        #region Constructors

        public RecordingToolWin()
        {
            InitializeComponent();

            _countDownTimer = new Timer(500);
            _countDownTimer.Elapsed += _countDownTimer_Elapsed;

            _topmostTimer = new Timer(1000);
            _topmostTimer.Elapsed += TopmostTimerOnElapsed;

            SourceInitialized += (sender, args) =>
            {
                WindowHiddenFromTabHelper.HiddenWindowFromTab(this);
            };
        }

        #endregion Constructors

        #region EventHandlers

        private void RecordingToolWin_OnLoaded(object sender, RoutedEventArgs e)
        {
            _countDownTimer_Elapsed(null, null);
            StartCountDownTimer();
            StartTopmostTimer();
            SetWinPos();
            SetOwner();
        }

        private void RecordingToolWin_OnClosing(object sender, CancelEventArgs e)
        {
            Dispose();
        }

        private void RecordingToolWin_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void PauseBtn_OnClick(object sender, RoutedEventArgs e)
        {
            PauseAndResumeRecording();
            e.Handled = true;
        }

        private void StopBtn_OnClick(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            StopRecording();
        }

        #endregion EventHandlers

        #region Methods

        #region Private Methods

        #region Timer _topmostTimer

        public void StartTopmostTimer()
        {
            _topmostTimer.Enabled = true;
            _topmostTimer.Start();
        }

        private void Stop_topmostTimer()
        {
            _topmostTimer.Stop();
            _topmostTimer.Enabled = false;
        }

        private void Dispose_topmostTimer()
        {
            if (_topmostTimer != null)
            {
                Stop_topmostTimer();
                _topmostTimer.Dispose();
                _topmostTimer = null;
            }
        }

        private void TopmostTimerOnElapsed(object sender, ElapsedEventArgs e)
        {

            _diskFreeSizeQueryCount++;
            if (_diskFreeSizeQueryCount == 2)
            {
                if (AppUtils.RecordDriveInfo != null)
                {
                    long totalFreeSapce = AppUtils.RecordDriveInfoTotalFreeSpace;

                    // 小于100mb 停止录课
                    if (totalFreeSapce >= 0 && totalFreeSapce <= AppConstants.RECORD_STOP_LEVEL)
                    {
                        RecorderHelper.IsStoppedByForce = true;
                        this.Dispatcher.Invoke((Action)(() => { StopRecording(); }));
                    }
                    //// 如果小于300mb 警告一次
                    //else if (totalFreeSapce >= 0 && totalFreeSapce <= AppConstants.RECORD_WARNING_LEVEL && !_disk300Warnninged)
                    //{
                    //    MessageBox.Show("磁盘控件不足300mb", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                    //    _disk300Warnninged = true;
                    //}
                }

                _diskFreeSizeQueryCount = 0;
            }

            this.Dispatcher.Invoke((Action)(() => { SetTopmost(); }));
        }

        #endregion Timer _topmostTimer

        /// <summary>
        /// 设置此窗口的owner
        /// </summary>
        private void SetOwner()
        {
            this.Owner = AppUtils.Owner;
        }

        private void SetWinPos()
        {
            double clientHeight = SystemParameters.WorkArea.Height;

            this.Left = 20;
            this.Top = clientHeight - this.ActualHeight - 20;
        }

        private void _countDownTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke((Action)(() =>
            {
                TimeSpan timeSpan = RecorderHelper.GetRecordingTime();
                _recordingEllipseColor = !_recordingEllipseColor;

                TimerLb.Text = timeSpan.ToString(@"hh\:mm\:ss");

            }));
        }

        private void StartCountDownTimer()
        {
            if (_countDownTimer != null)
            {
                _countDownTimer.Enabled = true;
                _countDownTimer.Start();
            }
        }

        private void StopCountDownTimer()
        {
            if (_countDownTimer != null)
            {
                _countDownTimer.Stop();
                _countDownTimer.Enabled = false;
            }
        }

        private void DiposeCountDownTimer()
        {
            if (_countDownTimer != null)
            {
                StopCountDownTimer();
                _countDownTimer.Dispose();
                _countDownTimer = null;
            }
        }

        private void Dispose()
        {
            DiposeCountDownTimer();
            Dispose_topmostTimer();
        }

        #endregion Private Methods

        #region Public Methods

        public void StopRecording()
        {
            this.Hide();
            RecorderHelper.StopRecording();
        }

        public void PauseAndResumeRecording()
        {
            if (!RecorderHelper.IsRecording())
            {
                return;
            }

            if (RecorderHelper.IsPausing())
            {
                // 更换暂停按钮图标
                PauseBtn.IsRecording = true;
                ScreenRecorderResult ret = RecorderHelper.ResumeRecording();
                if (ret != ScreenRecorderResult.Success)
                {
                    //MessageBox.Show("");
                }

                //_fileSizeQueryCount = 0;
                _countDownTimer_Elapsed(null, null);
                StartCountDownTimer();
            }
            else
            {
                // 更换暂停按钮图标 
                PauseBtn.IsRecording = false;
                ScreenRecorderResult ret = RecorderHelper.PauseRecording();
                if (ret != ScreenRecorderResult.Success)
                {
                    //MessageBox.Show("");
                }

                StopCountDownTimer();
            }
        }

        public void ShowMe()
        {
            this.Show();
        }

        public void HidenMe()
        {
            this.Hide();
        }

        public void SetTopmost()
        {
            WindowInteropHelper windowInteropHelper = new WindowInteropHelper(this);
            WindowTopmostHelper.SetWindowTopmost(windowInteropHelper.Handle);
        }

        #endregion Public Methods

        #endregion Methods
    }
}
