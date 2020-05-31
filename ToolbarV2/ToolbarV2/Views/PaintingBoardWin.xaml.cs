using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ToolbarV2.CommonTools;

namespace ToolbarV2.Views
{
    /// <summary>
    /// PaintingBoardWin.xaml 的交互逻辑
    /// </summary>
    public partial class PaintingBoardWin : Window
    {


        #region Constructors

        public PaintingBoardWin()
        {
            InitializeComponent();

            CustomInitialization();
        }

        #endregion Constructors

        #region  Fields


        #endregion Fields

        #region Properties

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
            RegisterMessages();
        }

        private void RegisterMessages()
        {
            AppUtils.RegisterEvents<string>(this, AppConstants.MSG_GLOBAL_SETPENCOLOR, SwitchPenColor); // 设置 画笔 颜色
            AppUtils.RegisterEvents<double>(this, AppConstants.MSG_GLOBAL_SETPENWIDTH, SwitchPenWidth); // 设置 画笔 粗细
        }

        #endregion LoadAndDispose

        /// <summary>
        /// 切换画笔颜色
        /// </summary>
        /// <param name="colorString"></param>
        public void SwitchPenColor(string colorString)
        {
            MyPaintingBoard.SetPenColor(colorString);
        }

        public void SwitchPenWidth(double width)
        {
            MyPaintingBoard.SetPenWidth(width);
        }

        #endregion Methods

        #region EventHandlers

        #region Windows
        #endregion Windows

        #endregion EventHandlers
    }
}
