using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using ToolbarV2.ViewModels;

namespace ToolbarV2.Views
{
    /// <summary>
    /// GlobalToolbar.xaml 的交互逻辑
    /// </summary>
    public partial class GlobalToolbar : Window
    {
        #region Constructors

        public GlobalToolbar()
        {
            InitializeComponent();
            CustomInitialization();
        }

        #endregion Constructors

        #region  Fields
        #endregion Fields

        #region Properties

        public GlobalToolbarViewModel ViewModel => (GlobalToolbarViewModel)DataContext;

        #endregion Properties

        #region Events
        #endregion Events

        #region Methods

        #region LoadAndDispose

        private void CustomInitialization()
        {
            this.Loaded += Window_OnLoaded;
            this.Closing += Window_Closing;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            Dispose();
        }

        private void Window_OnLoaded(object sender, RoutedEventArgs e)
        {
            LoadInitialization();
        }

        private void Dispose()
        {

        }

        private void LoadInitialization()
        {
            SetWindowPosition();
        }

        #endregion LoadAndDispose

        /// <summary>
        /// 设置全局工具栏的位置
        /// </summary>
        private void SetWindowPosition()
        {
            double actualWidth = this.ActualWidth;
            double actualHeight = this.ActualHeight;
            double clientWidth = SystemParameters.WorkArea.Width;
            double clientHeight = SystemParameters.WorkArea.Height;
            if (!double.IsNaN(actualWidth) && !double.IsNaN(actualHeight))
            {
                // 此种情况只适合 任务栏在底部
                double left = (clientWidth - actualWidth) / 2;
                double top = clientHeight - actualHeight;
                this.Left = left;
                this.Top = top;
            }
        }

        #endregion Methods

        #region EventHandlers

        private void CollapsedButton_OnCollapsedChanged(object sender, EventArgs e)
        {
            if (ViewModel.IsCollapsed)
            {
                // 收起
                DockPanel.SetDock(CollapsedContainer, Dock.Bottom);
                DockPanel.SetDock(ContainerPanel, Dock.Top);
                ContainerPanel.Visibility = Visibility.Hidden;
            }
            else
            {
                // 展开
                DockPanel.SetDock(CollapsedContainer, Dock.Top);
                DockPanel.SetDock(ContainerPanel, Dock.Bottom);
                ContainerPanel.Visibility = Visibility.Visible;
            }
        }

        #region Windows
        #endregion Windows

        #endregion EventHandlers

    }
}
