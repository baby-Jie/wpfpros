using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ToolbarV2.ViewModels
{
    public class SpotlightViewModel:ViewModelBase
    {

        #region Constructors

        public SpotlightViewModel()
        {

        }

        #endregion Constructors

        #region  Fields

        private readonly static SolidColorBrush MainSolidColorBrush = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)); // 浮层不透明色（关灯）

        private readonly static SolidColorBrush MainTransParentBrush = new SolidColorBrush(Color.FromArgb(128, 0, 0, 0)); // 浮层半透明色（开灯）

        public readonly static Rect FocusOriginalRect = new Rect(100, 100, 260, 200); // 聚焦区域原始尺寸（长度和宽度，位置视多屏而定）

        #endregion Fields

        #region Properties

        #region Full Properties

        #region FullProperty IsMoreScreenMode 是否为多屏模式
        private bool _isMoreScreenMode = true;

        public bool IsMoreScreenMode
        {
            get { return _isMoreScreenMode; }
            set { _isMoreScreenMode = value; }
        }
        #endregion	FullProperty IsMoreScreenMode

        #region FullProperty IsAllowCustomSelectSize
        private bool _isAllowCustomSelectSize = false;

        public bool IsAllowCustomSelectSize
        {
            get { return _isAllowCustomSelectSize; }
            set { _isAllowCustomSelectSize = value; }
        }
        #endregion	FullProperty IsAllowCustomSelectSize

        #region FullProperty IsOperationPanelInside
        private bool _isOperationPanelInside;

        public bool IsOperationPanelInside
        {
            get { return _isOperationPanelInside; }
            set
            {
                _isOperationPanelInside = value;

                if (_isOperationPanelInside)
                {
                    OperationPanelNormalMargin = new Thickness(0, -60, 0, 0);
                    OperationPanelVerticalAlignment = VerticalAlignment.Top;
                }
                else
                {
                    OperationPanelVerticalAlignment = VerticalAlignment.Bottom;
                    OperationPanelNormalMargin = _normalPanelMargin;
                }
            }
        }
        #endregion	FullProperty IsOperationPanelInside

        #endregion Full Properties

        #region Notify Properties

        #region Rect 聚焦相关的geometry 和 尺寸大小

        #region NotifyProperty MaxGeometryRect 屏幕窗口大小的RectangleGeometry的Rect

        private Rect _maxGeometryRect;

        public Rect MaxGeometryRect
        {
            get
            {
                _maxGeometryRect = new Rect(0, 0, WindowWidth, WindowHeight);
                return _maxGeometryRect;
            }
            set
            {
                _maxGeometryRect = value;
                OnPropertyChanged("MaxGeometryRect");
            }
        }

        #endregion	NotifyProperty MaxGeometryRect

        #region NotifyProperty FocusGeometryRect

        private Rect _focusGeometryRect;

        public Rect FocusGeometryRect
        {
            get { return _focusGeometryRect; }
            set
            {
                _focusGeometryRect = value;
                OnPropertyChanged("FocusGeometryRect");

                OnPropertyChanged("ResizeViewPosLeft");
                OnPropertyChanged("ResizeViewPosTop");
                OnPropertyChanged("ResizeViewWidth");
                OnPropertyChanged("ResizeViewHeight");

                RaisePanelPositionChanged();
            }
        }

        #endregion	NotifyProperty FocusGeometryRect

        #region NotifyProperty FocusOriginalRect

        private Rect _focusOriginalRect;

        public Rect FocusOriginalRect
        {
            get { return _focusOriginalRect; }
            set
            {
                _focusOriginalRect = value;
                OnPropertyChanged("FocusOriginalRect");
            }
        }

        #endregion	NotifyProperty FocusOriginalRect

        #region NotifyProperty FocusGeometry

        private Geometry _focusGeometry;

        public Geometry FocusGeometry
        {
            get
            {
                if (_focusGeometry == null)
                {
                    if (AppConstants.ISFOCUSELLIPSE)
                    {
                        _focusGeometry = new EllipseGeometry(FocusGeometryRect);
                        IValueConverter radiusXConverter = new Rectangle2RadiusXConverter();
                        IValueConverter radiuxYConverter = new Rectangle2RadiusYConverter();
                        IValueConverter centerConverter = new Rectangle2CenterConverter();

                        Binding myBindingRadiusX = new Binding("FocusGeometryRect");
                        myBindingRadiusX.Converter = radiusXConverter;
                        myBindingRadiusX.Source = this;

                        Binding myBindingRadiusY = new Binding("FocusGeometryRect");
                        myBindingRadiusY.Converter = radiuxYConverter;
                        myBindingRadiusY.Source = this;

                        Binding myBindingCenter = new Binding("FocusGeometryRect");
                        myBindingCenter.Converter = centerConverter;
                        myBindingCenter.Source = this;

                        BindingOperations.SetBinding(_focusGeometry, EllipseGeometry.RadiusXProperty, myBindingRadiusX);
                        BindingOperations.SetBinding(_focusGeometry, EllipseGeometry.RadiusYProperty, myBindingRadiusY);
                        BindingOperations.SetBinding(_focusGeometry, EllipseGeometry.CenterProperty, myBindingCenter);
                    }
                    else
                    {
                        _focusGeometry = new RectangleGeometry();
                        Binding myBinding = new Binding("FocusGeometryRect");
                        myBinding.Source = this;
                        BindingOperations.SetBinding(_focusGeometry, RectangleGeometry.RectProperty, myBinding);
                    }

                }
                return _focusGeometry;
            }
            set
            {
                _focusGeometry = value;
                OnPropertyChanged("FocusGeometry");
            }
        }

        #endregion	NotifyProperty FocusGeometry

        #endregion Rect 聚焦相关的geometry 和 尺寸大小

        #region Window Position and Size 窗口的大小和位置

        #region NotifyProperty WindowLeftPos 窗口Left值

        private double _windowLeftPos;

        public double WindowLeftPos
        {
            get
            {
                if (IsMoreScreenMode)
                {
                    _windowLeftPos = SystemParameters.VirtualScreenLeft;
                }
                else
                {
                    _windowLeftPos = 0;
                }
                return _windowLeftPos;
            }
            set
            {
                _windowLeftPos = value;
                OnPropertyChanged("WindowLeftPos");
            }
        }

        #endregion	NotifyProperty WindowLeftPos

        #region NotifyProperty WindowTopPos  窗口Top值

        private double _windowTopPos;

        public double WindowTopPos
        {
            get
            {
                if (IsMoreScreenMode)
                {
                    _windowTopPos = SystemParameters.VirtualScreenTop;
                }
                else
                {
                    _windowTopPos = 0;
                }
                return _windowTopPos;
            }
            set
            {
                _windowTopPos = value;
                OnPropertyChanged("WindowTopPos");
            }
        }

        #endregion	NotifyProperty WindowTopPos

        #region NotifyProperty WindowWidth 窗口宽度值

        private double _windowWidth;

        public double WindowWidth
        {
            get
            {
                if (IsMoreScreenMode)
                {
                    _windowWidth = SystemParameters.VirtualScreenWidth;
                }
                else
                {
                    _windowWidth = SystemParameters.PrimaryScreenWidth;
                }
                return _windowWidth;
            }
            set
            {
                _windowWidth = value;
                OnPropertyChanged("WindowWidth");
            }
        }

        #endregion	NotifyProperty WindowWidth

        #region NotifyProperty WindowHeight 窗口高度值

        private double _windowHeight;

        public double WindowHeight
        {
            get
            {
                if (IsMoreScreenMode)
                {
                    _windowHeight = SystemParameters.VirtualScreenHeight;
                }
                else
                {
                    _windowHeight = SystemParameters.PrimaryScreenHeight;
                }
                return _windowHeight;
            }
            set
            {
                _windowHeight = value;
                OnPropertyChanged("WindowHeight");
            }
        }

        #endregion	NotifyProperty WindowHeight

        #endregion Window Position and Size

        #region Brushes 窗体浮层背景色

        #region NotifyProperty MainMaskBrush 窗口浮层背景色

        private SolidColorBrush _mainMaskBrush;

        public SolidColorBrush MainMaskBrush
        {
            get { return _mainMaskBrush; }
            set
            {
                _mainMaskBrush = value;
                OnPropertyChanged("MainMaskBrush");
            }
        }

        #endregion	NotifyProperty MainMaskBrush

        #endregion Brushes

        #region FocusMode 聚焦模式 正聚焦、反聚焦

        #region NotifyProperty GeometryCombineMode

        private GeometryCombineMode _geometryCombineMode;

        public GeometryCombineMode GeometryCombineMode
        {
            get { return _geometryCombineMode; }
            set
            {
                _geometryCombineMode = value;
                OnPropertyChanged("GeometryCombineMode");
            }
        }

        #endregion	NotifyProperty GeometryCombineMode

        #endregion FocusMode 聚焦模式 正聚焦、反聚焦

        #region ResizeView Pos And Size 调整框控件的大小和位置

        #region NotifyProperty ResizeViewPosLeft 调整框控件 左 距离值

        private double _resizeViewPosLeft;

        public double ResizeViewPosLeft
        {
            get
            {
                return FocusGeometryRect.Left;
                //return _resizeViewPosLeft;
            }
            set
            {
                _resizeViewPosLeft = value;
                _focusGeometryRect.X = value;
                OnPropertyChanged("ResizeViewPosLeft");
                OnPropertyChanged("FocusGeometryRect");

                RaisePanelPositionChanged();
            }
        }

        #endregion	NotifyProperty ResizeViewPosLeft 调整框控件 左 距离值

        #region NotifyProperty ResizeViewPosTop 调整框控件 上 距离值

        private double _resizeViewPosTop;

        public double ResizeViewPosTop
        {
            get
            {
                return FocusGeometryRect.Top;
                //return _ResizeViewPosTop;
            }
            set
            {
                _resizeViewPosTop = value;
                _focusGeometryRect.Y = value;
                OnPropertyChanged("ResizeViewPosTop");
                OnPropertyChanged("FocusGeometryRect");

                RaisePanelPositionChanged();
            }
        }

        #endregion	NotifyProperty ResizeViewPosTop 调整框控件 上 距离值

        #region NotifyProperty ResizeViewWidth 调整框控件 宽度

        private double _resizeViewWidth;

        public double ResizeViewWidth
        {
            get
            {
                return FocusGeometryRect.Width;
                //return _resizeViewWidth;
            }
            set
            {
                _resizeViewWidth = value;
                _focusGeometryRect.Width = value;
                OnPropertyChanged("ResizeViewWidth");
                OnPropertyChanged("FocusGeometryRect");

                RaisePanelPositionChanged();
            }
        }

        #endregion	NotifyProperty ResizeViewWidth 调整框控件 宽度

        #region NotifyProperty ResizeViewHeight 调整框控件 高度

        private double _resizeViewHeight;

        public double ResizeViewHeight
        {
            get
            {
                return FocusGeometryRect.Height;
                //return _ResizeViewHeight;
            }
            set
            {
                _resizeViewHeight = value;
                _focusGeometryRect.Height = value;
                OnPropertyChanged("ResizeViewHeight");
                OnPropertyChanged("FocusGeometryRect");

                RaisePanelPositionChanged();
            }
        }

        #endregion	NotifyProperty ResizeViewHeight 调整框控件 高度

        #region NotifyProperty OperationPanelNormalMargin

        private Thickness _operationPanelNormalMargin;

        public Thickness OperationPanelNormalMargin
        {
            get { return _operationPanelNormalMargin; }
            set
            {
                Set(ref _operationPanelNormalMargin, value);
            }
        }

        #endregion	NotifyProperty OperationPanelNormalMargin

        #region the VerticalAlignment of OperationPanel

        private VerticalAlignment _operationPanelVerticalAlignment = VerticalAlignment.Bottom;

        public VerticalAlignment OperationPanelVerticalAlignment
        {
            get { return _operationPanelVerticalAlignment; }
            set
            {
                Set(ref _operationPanelVerticalAlignment, value);
                _operationPanelVerticalAlignment = value;
            }
        }

        #endregion the VerticalAlignment of OperationPanel


        #endregion ResizeView Pos And Size

        #region Other Properties

        #region NotifyProperty IsOffFocus

        private bool _isOffFocus;

        public bool IsOffFocus
        {
            get { return _isOffFocus; }
            set
            {
                _isOffFocus = value;
                Set(ref _isOffFocus, value);
                //SwitchFocusState(value);
                //RaiseStateChanged();
            }
        }

        #endregion	NotifyProperty IsOffFocus

        #region NotifyProperty IsOverSpread

        private bool _isOverSpread;

        public bool IsOverSpread
        {
            get { return _isOverSpread; }
            set
            {
                _isOverSpread = value;
                Set(ref _isOverSpread, value);
                //SwitchOverSpreadState(value);
                //RaiseStateChanged();
            }
        }

        #endregion	NotifyProperty IsOverSpread

        

        #region NotifyProperty IsResizeFrameVisible

        private bool _isResizeFrameVisible = true;

        public bool IsResizeFrameVisible
        {
            get { return _isResizeFrameVisible; }
            set
            {
                Set(ref _isResizeFrameVisible, value);
            }
        }

        #endregion	NotifyProperty IsResizeFrameVisible


        #endregion Other Properties

        #endregion Notify Properties

        #region Command Properties

        #region CommandProperty SwitchFocusCmd

        private RelayCommand _switchLightCmd;

        public RelayCommand SwitchFocusCmd
        {
            get
            {
                if (null == _switchLightCmd)
                {
                    _switchLightCmd = new RelayCommand(() =>
                    {
                        if (IsOverSpread)
                        {
                            IsOverSpread = !IsOverSpread;
                            IsOffFocus = false;
                        }
                        else
                        {
                            IsOffFocus = !IsOffFocus;
                        }
                    });
                }
                return _switchLightCmd;
            }
        }

        #endregion

        #region CommandProperty SwitchOverSpreadCmd

        private RelayCommand _switchOverSpreadCmd;

        public RelayCommand SwitchOverSpreadCmd
        {
            get
            {
                if (null == _switchOverSpreadCmd)
                {
                    _switchOverSpreadCmd = new RelayCommand(() =>
                    {
                        if (IsOverSpread)
                        {
                            IsOffFocus = true;
                        }

                        IsOverSpread = !IsOverSpread;

                        // 进入三状态
                        if (IsOverSpread)
                        {
                            IsOffFocus = false;
                        }
                    });
                }
                return _switchOverSpreadCmd;
            }
        }

        #endregion


        #endregion Command Properties

        #endregion Properties

        #region Methods

        #endregion Methods

        #region EventHandlers

        #region Windows
        #endregion Windows

        #endregion EventHandlers

    }
}
