using PainingBoard.CommonTools;
using PainingBoard.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using Pen = System.Drawing.Pen;
using Bitmap = System.Drawing.Bitmap;
using Graphics = System.Drawing.Graphics;
using RectangleF = System.Drawing.RectangleF;
using FormColor = System.Drawing.Color;

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

        private readonly object _strokeLock = new object();

        private bool _isStrokeHandled = true;

        private Stack<Tuple<StrokeCollection, StrokeCollection>> _undoStack = new Stack<Tuple<StrokeCollection, StrokeCollection>>();

        private Stack<Tuple<StrokeCollection, StrokeCollection>> _redoStack = new Stack<Tuple<StrokeCollection, StrokeCollection>>();
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

            SetPenCursor();
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

        /// <summary>
        /// 撤销
        /// </summary>
        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                lock (_strokeLock)
                {
                    if (_undoStack.Count > 0)
                    {
                        Tuple<StrokeCollection, StrokeCollection> tuple = _undoStack.Pop();
                        _redoStack.Push(tuple);
                        _isStrokeHandled = false;
                        AdInkCanvas.Strokes.Remove(tuple.Item1);
                        AdInkCanvas.Strokes.Add(tuple.Item2);
                        _isStrokeHandled = true;
                    }
                }
            }
        }

        /// <summary>
        /// 重做
        /// </summary>
        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                lock (_strokeLock)
                {
                    if (_redoStack.Count > 0)
                    {
                        Tuple<StrokeCollection, StrokeCollection> tuple = _redoStack.Pop();
                        _undoStack.Push(tuple);
                        _isStrokeHandled = false;
                        AdInkCanvas.Strokes.Remove(tuple.Item2);
                        AdInkCanvas.Strokes.Add(tuple.Item1);
                        _isStrokeHandled = true;
                    }
                }
            }
        }


        private void SetPenCursor()
        {
            //Cursor cursor = new Cursor();
            // 获取颜色
            //Color penColor = _drawingAttributes.Color;

            //object obj = this.FindResource("PenGeometry");
            //if (obj is Geometry penGeometry)
            //{
            //    Bitmap bitmap = new Bitmap(32, 32);
            //    using (Graphics g = Graphics.FromImage(bitmap))
            //    {
            //        g.DrawEllipse(new Pen(FormColor.Red), new RectangleF(2, 2, 10, 10));
            //    }

            //    Cursor cursor = CursorHelper.CreateCursorFromBitmap(bitmap, 255, new System.Drawing.Point());
            //    //GeometryDrawing aGeometryDrawing = new GeometryDrawing();
            //    //aGeometryDrawing.Geometry = penGeometry;
            //    //aGeometryDrawing.Brush = new SolidColorBrush(penColor);
            //    //DrawingImage drawImage = new DrawingImage(aGeometryDrawing);
            //    //TestImage.Source = drawImage;

            //    //Cursor penCursor = CursorHelper.CreateCursor(TestImage, 32, 32);
            //    this.AdInkCanvas.Cursor = cursor;

            //}
            // 生成一个图片文件(svg)
            //Cursor cursor = new Cursor();

        }
        #endregion Methods

        #region EventHandlers

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

            this.AdInkCanvas.Strokes.StrokesChanged += StrokesOnStrokesChanged;
        }

        private void StrokesOnStrokesChanged(object sender, StrokeCollectionChangedEventArgs e)
        {
            if (_isStrokeHandled)
            {
                _undoStack.Push(new Tuple<StrokeCollection, StrokeCollection>(e.Added, e.Removed));
                _redoStack.Clear();
            }
        }

        #endregion LoadAndDispose

        #endregion EventHandlers
    }
}
