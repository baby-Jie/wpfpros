using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RecordLib.Controls
{
    public class ImageButton : Button
    {

        #region Properties

        #region OverImage
        public string OverImage
        {
            get { return (string)GetValue(OverImageProperty); }
            set { SetValue(OverImageProperty, value); }
        }

        public static readonly DependencyProperty OverImageProperty =
            DependencyProperty.Register("OverImage", typeof(string), typeof(ImageButton), new PropertyMetadata(string.Empty));
        #endregion

        #region NormalImage


        public string NormalImage
        {
            get { return (string)GetValue(NormalImageProperty); }
            set { SetValue(NormalImageProperty, value); }
        }

        public static readonly DependencyProperty NormalImageProperty =
            DependencyProperty.Register("NormalImage", typeof(string), typeof(ImageButton), new PropertyMetadata(string.Empty));

        #endregion

        #region DependencyProperty IsSelected

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(ImageButton), new PropertyMetadata(false));

        #endregion

        #region DependencyProperty ImageDescriptionText

        public string ImageDescriptionText
        {
            get { return (string)GetValue(ImageDescriptionTextProperty); }
            set { SetValue(ImageDescriptionTextProperty, value); }
        }

        public static readonly DependencyProperty ImageDescriptionTextProperty =
            DependencyProperty.Register("ImageDescriptionText", typeof(string), typeof(ImageButton), new PropertyMetadata(string.Empty));

        #endregion

        #region DependencyProperty RotateAngle
        public double RotateAngle
        {
            get { return (double)GetValue(RotateAngleProperty); }
            set { SetValue(RotateAngleProperty, value); }
        }

        public static readonly DependencyProperty RotateAngleProperty =
            DependencyProperty.Register("RotateAngle", typeof(double), typeof(ImageButton), new PropertyMetadata(default(double)));

        #endregion DependencyProperty RotateAngle

        #region DependencyProperty PathHeight

        public double PathHeight
        {
            get { return (double)GetValue(PathHeightProperty); }
            set { SetValue(PathHeightProperty, value); }
        }

        public static readonly DependencyProperty PathHeightProperty =
            DependencyProperty.Register("PathHeight", typeof(double), typeof(ImageButton), new PropertyMetadata(26d));

        #endregion DependencyProperty PathHeight	

        #region DependencyProperty PathWidth

        public double PathWidth
        {
            get { return (double)GetValue(PathWidthProperty); }
            set { SetValue(PathWidthProperty, value); }
        }

        public static readonly DependencyProperty PathWidthProperty =
            DependencyProperty.Register("PathWidth", typeof(double), typeof(ImageButton), new PropertyMetadata(26d));

        #endregion DependencyProperty PathWidth	

        #endregion Properties

        #region Constructors

        static ImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
        }

        #endregion Constructors

        #region Override Methods

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            try
            {
                var exxpandContainer = this.GetTemplateChild("PART_ExpandContainer") as UIElement;

                if (exxpandContainer != null)
                {
                    exxpandContainer.MouseLeftButtonDown += (sender, args) => { args.Handled = true; };
                    exxpandContainer.MouseLeftButtonUp += (sender, args) =>
                    {
                        Console.WriteLine("Expand Events");
                        args.Handled = true;
                        RoutedEventArgs e = new RoutedEventArgs(ExpandEvent, this);
                        this.RaiseEvent(e);
                    };
                }
            }
            catch (Exception ex)
            {
            }

        }

        #endregion Override Methods

        #region Events

        #region	RoutedEvent

        public event EventHandler Expand
        {
            add { AddHandler(ExpandEvent, value); }
            remove { RemoveHandler(ExpandEvent, value); }
        }

        public static readonly RoutedEvent ExpandEvent = EventManager.RegisterRoutedEvent(
        "Expand", RoutingStrategy.Tunnel | RoutingStrategy.Bubble, typeof(EventHandler), typeof(ImageButton));

        #endregion	RoutedEvent


        #endregion Events
    }
}
