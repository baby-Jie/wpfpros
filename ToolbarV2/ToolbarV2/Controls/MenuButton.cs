using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ToolbarV2.Controls
{
    public class MenuButton : Button
    {
        #region 依赖属性

        #region 是否被选中

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(MenuButton), new PropertyMetadata(false));

        #endregion 是否被选中	

        #region 是否在拐角

        public bool IsCorner
        {
            get { return (bool)GetValue(IsCornerProperty); }
            set { SetValue(IsCornerProperty, value); }
        }

        public static readonly DependencyProperty IsCornerProperty =
            DependencyProperty.Register("IsCorner", typeof(bool), typeof(MenuButton), new PropertyMetadata(false));

        #endregion 是否在拐角

        #region 拐角位置

        public int CornerPosition
        {
            get { return (int)GetValue(CornerPositionProperty); }
            set { SetValue(CornerPositionProperty, value); }
        }

        public static readonly DependencyProperty CornerPositionProperty =
            DependencyProperty.Register("CornerPosition", typeof(int), typeof(MenuButton), new PropertyMetadata(0));

        #endregion 拐角位置	

        #region 是否是镜像的

        public bool IsMirror
        {
            get { return (bool)GetValue(IsMirrorProperty); }
            set { SetValue(IsMirrorProperty, value); }
        }

        public static readonly DependencyProperty IsMirrorProperty =
            DependencyProperty.Register("IsMirror", typeof(bool), typeof(MenuButton), new PropertyMetadata(false));

        #endregion 是否是镜像的	

        #region 主图标旋转角度

        public double MainRotateAngle
        {
            get { return (double)GetValue(MainRotateAngleProperty); }
            set { SetValue(MainRotateAngleProperty, value); }
        }

        public static readonly DependencyProperty MainRotateAngleProperty =
            DependencyProperty.Register("MainRotateAngle", typeof(double), typeof(MenuButton), new PropertyMetadata(default(double)));

        #endregion 主图标旋转角度	

        #region 子图标旋转角度

        public double SubRotateAngle
        {
            get { return (double)GetValue(SubRotateAngleProperty); }
            set { SetValue(SubRotateAngleProperty, value); }
        }

        public static readonly DependencyProperty SubRotateAngleProperty =
            DependencyProperty.Register("SubRotateAngle", typeof(double), typeof(MenuButton), new PropertyMetadata(default(double)));

        #endregion 子图标旋转角度	

        #region 是否含有子菜单 有的话左上角显示小三角

        public bool HasSubMenu
        {
            get { return (bool)GetValue(HasSubMenuProperty); }
            set { SetValue(HasSubMenuProperty, value); }
        }

        public static readonly DependencyProperty HasSubMenuProperty =
            DependencyProperty.Register("HasSubMenu", typeof(bool), typeof(MenuButton), new PropertyMetadata(false));

        #endregion 是否含有子菜单	

        #region 主图标

        public Geometry MainGeometry
        {
            get { return (Geometry)GetValue(MainGeometryProperty); }
            set { SetValue(MainGeometryProperty, value); }
        }

        public static readonly DependencyProperty MainGeometryProperty =
            DependencyProperty.Register("MainGeometry", typeof(Geometry), typeof(MenuButton), new PropertyMetadata(default(Geometry)));

        #endregion 主图标	

        #region 子菜单标志图标

        public Geometry SubGeometry
        {
            get { return (Geometry)GetValue(SubGeometryProperty); }
            set { SetValue(SubGeometryProperty, value); }
        }

        public static readonly DependencyProperty SubGeometryProperty =
            DependencyProperty.Register("SubGeometry", typeof(Geometry), typeof(MenuButton), new PropertyMetadata(default(Geometry)));

        #endregion 子菜单标志图标	

        #region icon的周长

        public double MainIconRadiux
        {
            get { return (double)GetValue(MainIconRadiuxProperty); }
            set { SetValue(MainIconRadiuxProperty, value); }
        }

        public static readonly DependencyProperty MainIconRadiuxProperty =
            DependencyProperty.Register("MainIconRadiux", typeof(double), typeof(MenuButton), new PropertyMetadata(default(double)));

        #endregion icon的周长	

        #endregion 依赖属性	
    }
}
