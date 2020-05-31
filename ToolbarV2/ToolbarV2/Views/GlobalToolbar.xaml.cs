using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using PainingBoard.Models;
using ToolbarV2.CommonTools;
using ToolbarV2.Controls;
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

            _menuButtonList = new List<MenuButton>();
            _menuButtonList.Add(SelectBtn);
            _menuButtonList.Add(PenBtn);
            _menuButtonList.Add(EraserBtn);
        }

        #endregion Constructors

        #region  Fields

        private IPaintingBoard _transparentBoardController;

        private PaintingBoardWin _paintingBoardWin;

        private readonly List<MenuButton> _menuButtonList;

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
            _paintingBoardWin?.Close();
        }

        private void LoadInitialization()
        {
            SetWindowPosition();

            LoadPaintingBoard();
        }

        /// <summary>
        /// 加载透明画板窗口
        /// </summary>
        private void LoadPaintingBoard()
        {
            CheckPaintBoard();
            ShowPaintingBoard();
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

        /// <summary>
        /// 选中菜单按钮
        /// </summary>
        /// <param name="activeButton"></param>
        private void SelectMenuButton(MenuButton activeButton)
        {
            foreach (var btn in _menuButtonList)
            {
                btn.IsSelected = false;
            }

            activeButton.IsSelected = true;
        }

        #region 画板控制

        private void SwitchPen()
        {
            SelectMenuButton(PenBtn);
            _transparentBoardController.SwitchPaintingMode(PaintingMode.Pen);
        }

        /// <summary>
        /// 切换桌面模式
        /// </summary>
        private void SwitchDesktop()
        {
            SelectMenuButton(SelectBtn);
            _transparentBoardController.SwitchPaintingMode(PaintingMode.DeskTop);
        }

        /// <summary>
        /// 切换橡皮擦模式
        /// </summary>
        private void SwitchErase()
        {
            SelectMenuButton(EraserBtn);
            _transparentBoardController.SwitchPaintingMode(PaintingMode.Eraser);
        }

        /// <summary>
        /// 清除所有画笔
        /// </summary>
        private void ClearAllPen()
        {
            _transparentBoardController.ClearAll();
        }

        #endregion 画板控制	

        private void ShowPaintingBoard()
        {
            _paintingBoardWin.Show();
        }

        /// <summary>
        /// 检查画板对象是否为null，为null创建
        /// </summary>
        private void CheckPaintBoard()
        {
            if (_paintingBoardWin == null)
            {
                // 第一次进入 加载win
                _paintingBoardWin = AppUtils.GetPaintingBoardWinInstance();
                _transparentBoardController = _paintingBoardWin.MyPaintingBoard;
                _paintingBoardWin.Loaded += delegate (object sender, RoutedEventArgs args)
                {
                    this.Owner = _paintingBoardWin;
                };
            }
        }

        /// <summary>
        /// 获取画笔的宽度
        /// </summary>
        /// <returns></returns>
        private double GetPenWidth()
        {
            if (PenWidthSlimRadioBtn.IsChecked == true)
            {
                return AppConstants.PEN_WIDTH_SLIM;
            }
            else if (PenWidthMiddleRadioBtn.IsChecked == true)
            {
                return AppConstants.PEN_WIDTH_MIDDLE;
            }
            else if (PenWidthThickRadioBtn.IsChecked == true)
            {
                return AppConstants.PEN_WIDTH_THICK;
            }
            else
            {
                return AppConstants.PEN_WIDTH_SLIM;
            }
        }

        /// <summary>
        /// 设置画笔的宽度
        /// </summary>
        private void SetPenWidth()
        {
            double penWidth = GetPenWidth();
            AppUtils.SendMessage(penWidth, AppConstants.MSG_GLOBAL_SETPENWIDTH);
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

        private void StopLessonBtn_OnClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PenBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (PenBtn.IsSelected)
            {
                // 打开pen设置弹窗
                ViewModel.IsPenSettingPopOpen = true;
            }
            else
            {
                // 切换画笔模式
                SwitchPen();
            }
        }

        private void SelectBtn_OnClick(object sender, RoutedEventArgs e)
        {
            SwitchDesktop();
        }

        private void EraserBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (EraserBtn.IsSelected)
            {
                // 打开橡皮设置弹窗
                ViewModel.IsEraserSettingPopOpen = true;
            }
            else
            {
                // 切换橡皮模式
                SwitchErase();
            }
        }

        private void EraserAllBtn_OnClick(object sender, RoutedEventArgs e)
        {
            ClearAllPen();
            SwitchDesktop(); // 清除完毕之后返回桌面模式
            ViewModel.IsEraserSettingPopOpen = false; // 关闭弹窗
        }

        /// <summary>
        /// 画笔 宽度 选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PenWidthRadioBtn_OnChecked(object sender, RoutedEventArgs e)
        {
            SetPenWidth();

            ViewModel.IsPenSettingPopOpen = false;
        }

        #endregion EventHandlers
    }
}
