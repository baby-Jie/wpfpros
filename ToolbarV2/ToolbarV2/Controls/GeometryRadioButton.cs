using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ToolbarV2.Controls
{
    public class GeometryRadioButton : RadioButton
    {
        #region 依赖属性

        #region 主图标

        public Geometry MainGeometry
        {
            get { return (Geometry)GetValue(MainGeometryProperty); }
            set { SetValue(MainGeometryProperty, value); }
        }

        public static readonly DependencyProperty MainGeometryProperty =
            DependencyProperty.Register("MainGeometry", typeof(Geometry), typeof(GeometryRadioButton), new PropertyMetadata(default(Geometry)));

        #endregion 主图标	

        #region 是否是镜像的

        public bool IsMirror
        {
            get { return (bool)GetValue(IsMirrorProperty); }
            set { SetValue(IsMirrorProperty, value); }
        }

        public static readonly DependencyProperty IsMirrorProperty =
            DependencyProperty.Register("IsMirror", typeof(bool), typeof(GeometryRadioButton), new PropertyMetadata(false));

        #endregion 是否是镜像的	

        #region 主图标旋转角度

        public double MainRotateAngle
        {
            get { return (double)GetValue(MainRotateAngleProperty); }
            set { SetValue(MainRotateAngleProperty, value); }
        }

        public static readonly DependencyProperty MainRotateAngleProperty =
            DependencyProperty.Register("MainRotateAngle", typeof(double), typeof(GeometryRadioButton), new PropertyMetadata(default(double)));

        #endregion 主图标旋转角度	

        #endregion 依赖属性	
    }
}
