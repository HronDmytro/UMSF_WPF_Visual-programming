using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace PW_1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AnimateShapes();
        }

        private void AnimateShapes()
        {
            AnimateShape(triangle, 0, 200, TimeSpan.FromSeconds(5), 0, 0);
            AnimateShape(rectangle, 200, 0, TimeSpan.FromSeconds(5), 0, 200);
            AnimateShape(circle, 0, 200, TimeSpan.FromSeconds(5), 200, 200);
            AnimateShape(pyramid, 200, 0, TimeSpan.FromSeconds(5), 200, 0);
        }

        private void AnimateShape(UIElement shape, double from, double to, TimeSpan duration, double x, double y)
        {
            shape.Visibility = Visibility.Visible;
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = from;
            animation.To = to;
            animation.Duration = duration;

            TranslateTransform transform = new TranslateTransform();
            shape.RenderTransform = transform;

            animation.Completed += (sender, e) =>
            {
                transform.BeginAnimation(TranslateTransform.XProperty, null);
                transform.BeginAnimation(TranslateTransform.YProperty, null);
                transform.X = x;
                transform.Y = y;
                AnimateShape(shape, from, to, duration, x, y);
            };

            transform.BeginAnimation(TranslateTransform.XProperty, animation);
            transform.BeginAnimation(TranslateTransform.YProperty, animation);
        }
    }
}
