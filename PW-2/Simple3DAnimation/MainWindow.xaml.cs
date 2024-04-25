using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Threading;

namespace Simple3DAnimation
{
    public partial class MainWindow : Window
    {
        private RotateTransform3D myYRotate, myZRotate;
        private AxisAngleRotation3D myYAxis, myZAxis;
        private DispatcherTimer MyTimer;  
        private RotateTransform3D myYRotate2, myZRotate2;
        private AxisAngleRotation3D myYAxis2, myZAxis2;


        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            myYRotate = new RotateTransform3D();
            myYAxis = new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0);
            myYRotate.Rotation = myYAxis;
            myZRotate = new RotateTransform3D();
            myZAxis = new AxisAngleRotation3D(new Vector3D(0, 0, 1), 0);
            myZRotate.Rotation = myZAxis;

            Transform3DGroup myTransform1 = new Transform3DGroup();
            MyModel.Transform = myTransform1;
            myTransform1.Children.Add(myYRotate);
            myTransform1.Children.Add(myZRotate);

            MyTimer = new DispatcherTimer();
            MyTimer.Tick += MyTimer_Tick;
            MyTimer.Interval = TimeSpan.FromMilliseconds(20);


            myYRotate2 = new RotateTransform3D();
            myYAxis2 = new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0);
            myYRotate2.Rotation = myYAxis2;
            myZRotate2 = new RotateTransform3D();
            myZAxis2 = new AxisAngleRotation3D(new Vector3D(0, 0, 1), 0);
            myZRotate2.Rotation = myZAxis2;

            Transform3DGroup myTransform2 = new Transform3DGroup();
            MyModel2.Transform = myTransform2;
            myTransform2.Children.Add(myYRotate2);
            myTransform2.Children.Add(myZRotate2);

        }

        private void StartAnimation_Click(object sender, RoutedEventArgs e)
        {
            MyTimer.Start();
        }

        private void StopAnimation_Click(object sender, RoutedEventArgs e)
        {
            MyTimer.Stop();
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            myYAxis.Angle += 1;
            myZAxis.Angle += 1;

            myYAxis2.Angle += 1;
            myZAxis2.Angle += 1;

        }
    }
}
