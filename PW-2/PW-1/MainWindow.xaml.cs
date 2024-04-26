using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace PW_1
{
    public partial class MainWindow : Window
    {
        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            AnimateShapes();
        }

        private void AnimateShapes()
        {
            AnimateShapeWithRandomPath(triangle, TimeSpan.FromSeconds(5));
            AnimateShapeWithRandomPath(rectangle, TimeSpan.FromSeconds(5));
            AnimateShapeWithRandomPath(circle, TimeSpan.FromSeconds(5));
            AnimateShapeWithRandomPath(pyramid, TimeSpan.FromSeconds(5));
        }

        private void AnimateShapeWithRandomPath(UIElement shape, TimeSpan duration)
        {
            shape.Visibility = Visibility.Visible;

            double startX = random.NextDouble() * (canvas.ActualWidth - 40);
            double startY = random.NextDouble() * (canvas.ActualHeight - 40);
            double endX = random.NextDouble() * (canvas.ActualWidth - 40);
            double endY = random.NextDouble() * (canvas.ActualHeight - 40);

            AnimateShape(shape, startX, startY, endX, endY, duration);
        }

        private void AnimateShape(UIElement shape, double startX, double startY, double endX, double endY, TimeSpan duration)
        {
            DoubleAnimation animationX = new DoubleAnimation();
            animationX.From = startX;
            animationX.To = endX;
            animationX.Duration = duration;

            DoubleAnimation animationY = new DoubleAnimation();
            animationY.From = startY;
            animationY.To = endY;
            animationY.Duration = duration;

            TranslateTransform transform = new TranslateTransform();
            shape.RenderTransform = transform;

            animationX.Completed += (sender, e) =>
            {
                transform.BeginAnimation(TranslateTransform.XProperty, null);
                transform.BeginAnimation(TranslateTransform.YProperty, null);
                transform.X = endX;
                transform.Y = endY;
                AnimateShape(shape, endX, endY, random.NextDouble() * (canvas.ActualWidth - 40), random.NextDouble() * (canvas.ActualHeight - 40), duration);
            };

            transform.BeginAnimation(TranslateTransform.XProperty, animationX);
            transform.BeginAnimation(TranslateTransform.YProperty, animationY);
        }

    }
}
