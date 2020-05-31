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
using System.Windows.Navigation;
using System.Windows.Shapes;
using PainingBoard.Models;

namespace PainingBoard.Controls
{
    /// <summary>
    /// InkPaintingBoard.xaml 的交互逻辑
    /// </summary>
    public partial class InkPaintingBoard : UserControl, IPaintingBoard
    {
        #region Constructors

        public InkPaintingBoard()
        {
            InitializeComponent();

            CustomInitialization();
        }

        #endregion Constructors

        #region  Fields

        private DrawingAttributes _drawingAttributes;

        #endregion Fields

        #region Properties

        #endregion Properties

        #region Events
        #endregion Events

        #region Methods

        /// <summary>
        /// 切换模式
        /// </summary>
        /// <param name="mode"></param>
        public void SwitchPaintingMode(PaintingMode mode)
        {
            // 先设置背景色
            AdInkCanvas.Background = new SolidColorBrush(Color.FromArgb(1, 0, 0, 0));
            switch (mode)
            {
                case PaintingMode.Pen:
                    this.AdInkCanvas.EditingMode = InkCanvasEditingMode.Ink;
                    break;
                case PaintingMode.Eraser:
                    this.AdInkCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
                    break;
                case PaintingMode.Non:
                    this.AdInkCanvas.EditingMode = InkCanvasEditingMode.None;
                    break;
                case PaintingMode.DeskTop:
                    this.AdInkCanvas.EditingMode = InkCanvasEditingMode.None;
                    // 设置画板背景色为透明
                    AdInkCanvas.Background = Brushes.Transparent;
                    break;
                case PaintingMode.Select:
                    AdInkCanvas.EditingMode = InkCanvasEditingMode.Select;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }

        /// <summary>
        /// 设置画笔的颜色
        /// </summary>
        /// <param name="colorStr"></param>
        public void SetPenColor(string colorStr)
        {
            Color penColor = (Color)ColorConverter.ConvertFromString(colorStr);
            _drawingAttributes.Color = penColor;
        }

        /// <summary>
        /// 设置画笔粗细
        /// </summary>
        /// <param name="width"></param>
        public void SetPenWidth(double width)
        {
            _drawingAttributes.Height = width;
            _drawingAttributes.Width = width;
        }

        /// <summary>
        /// 清除所有
        /// </summary>
        public void ClearAll()
        {
            this.AdInkCanvas.Strokes.Clear();
        }

        #endregion Methods

        #region EventHandlers

        #region Windows

        #region LoadAndDispose

        private void CustomInitialization()
        {
            this.Loaded += Window_OnLoaded;
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
            _drawingAttributes = this.AdInkCanvas.DefaultDrawingAttributes;
        }

        #endregion LoadAndDispose

        #endregion Windows

        #endregion EventHandlers
    }
}
