using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ToolbarV2.Controls
{
    public class GlobalCollapsedButton:Button
    {
        #region 是否收起

        public bool IsCollapsed
        {
            get { return (bool)GetValue(IsCollapsedProperty); }
            set { SetValue(IsCollapsedProperty, value); }
        }

        public static readonly DependencyProperty IsCollapsedProperty =
            DependencyProperty.Register("IsCollapsed", typeof(bool), typeof(GlobalCollapsedButton), new PropertyMetadata(false, CollapsedPropertyChangedCallback));

        private static void CollapsedPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            if (d is GlobalCollapsedButton button)
            {
                button.RaiseCollapsedChangedEvent(e);
            }
        }

        private void RaiseCollapsedChangedEvent(DependencyPropertyChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(CollapsedChangedEvent, this);
            this.RaiseEvent(args);
        }

        #endregion 是否收起	

        #region 是否是镜像的

        public bool IsMirror
        {
            get { return (bool)GetValue(IsMirrorProperty); }
            set { SetValue(IsMirrorProperty, value); }
        }

        public static readonly DependencyProperty IsMirrorProperty =
            DependencyProperty.Register("IsMirror", typeof(bool), typeof(GlobalCollapsedButton), new PropertyMetadata(false));

        #endregion 是否是镜像的	


        #region	RoutedEvent

        public event EventHandler CollapsedChanged
        {
            add { AddHandler(CollapsedChangedEvent, value); }
            remove { RemoveHandler(CollapsedChangedEvent, value); }
        }

        public static readonly RoutedEvent CollapsedChangedEvent = EventManager.RegisterRoutedEvent(
            "CollapsedChanged", RoutingStrategy.Bubble, typeof(EventHandler), typeof(GlobalCollapsedButton));

        #endregion	RoutedEvent
    }
}
