using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using FunctionBuilder.Logic;

namespace FunctionBuilder.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyField = new Field(Canvas, Expression.Text, Range.Text, Step.Text);
            
        }
        private Field MyField { get; set; }
        private Point StartPoint { get; set; }
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Canvas.Width = ActualWidth;
            Canvas.Height = ActualHeight - Box1.ActualHeight - Button.ActualHeight;
            try
            {
                MyField.PrintCanvas();
            }
            catch
            {
                MyField.PrintCoordinateLines();
            }
        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var displacement = Mouse.GetPosition(this) - StartPoint;
                MyField.X1 -= displacement.X;
                MyField.Y1 -= displacement.Y;
                try
                {
                    MyField.PrintCanvas();
                }
                catch
                {
                    MyField.PrintCoordinateLines();
                }
            }
            StartPoint = Mouse.GetPosition(this);
        }
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
                StartPoint = e.GetPosition(this);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                MyField = new Field(Canvas, Expression.Text, Range.Text, Step.Text);
                MyField.PrintCanvas();
            }
            catch
            {
                MessageBox.Show("Проверьте формат веденных данных");
            }
        }

    }
}
