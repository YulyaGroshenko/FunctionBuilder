using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using FunctionBuilder.Logic;

namespace FunctionBuilder.WPF
{
    class Field
    {
        public Field(Canvas canvas, string expression, string range, string step)
        {
            Canvas = canvas;
            X1 = -Canvas.Width / 2;
            Y1 = -Canvas.Height / 2;
            Expression = expression;
            Range = range;
            Step = step;
        }
        public Canvas Canvas { get; private set; }
        public double X1 { get; set; }
        public double X2 { get { return X1 + Canvas.Width; } }
        public double Y1 { get; set; }
        public double Y2 { get { return Y1 + Canvas.Height; } }
        public int Scale { get; set; } = 100;
        public string Expression { get; set; }
        public string Range { get; set; }
        public string Step { get; set; }
        public void PrintNums()
        {
            int j = 0;
            for (double i = 0; i >= Y1; i -= 0.4 * Scale)
            { 
                if (i <= Y2)
                {
                    Label label = new Label()
                    {
                        Content = j
                    };
                    Canvas.SetLeft(label, i - this.Y1);
                    j++;
                    Canvas.Children.Add(label);
                }
            }
        }
        public void PrintCoordinateLines()
        {
            Canvas.Children.Clear();
            PrintXTopLines();
            PrintXBottomLines();
            PrintYLeftLines();
            PrintYRightLines();
        }
        public void PrintCanvas()
        {
            Canvas.Children.Clear();
            PrintXTopLines();
            PrintXBottomLines();
            PrintYLeftLines();
            PrintYRightLines();
            PrintFunc();
        }
        private void PrintXTopLines()
        {
            for (double i = 0; i >= Y1; i -= 0.4 * Scale)
            {
                if (i <= Y2)
                {
                    Line line = new Line()
                    {
                        X1 = 0,
                        X2 = Canvas.Width,
                        Y1 = i - this.Y1,
                        Y2 = i - this.Y1
                    };
                    if (i == 0)
                        line.Stroke = Brushes.Black;
                    else
                        line.Stroke = Brushes.Gray;
                    Canvas.Children.Add(line);
                }
            }
        }
        private void PrintXBottomLines()
        {
            for (double i = 0; i <= Y2; i += 0.4 * Scale)
            {
                if (i >= Y1)
                {
                    Line line = new Line()
                    {
                        X1 = 0,
                        X2 = Canvas.Width,
                        Y1 = i - this.Y1,
                        Y2 = i - this.Y1
                    };
                    if (i == 0)
                        line.Stroke = Brushes.Black;
                    else
                        line.Stroke = Brushes.Gray;
                    Canvas.Children.Add(line);
                }
            }
        }
        private void PrintYRightLines()
        {
            for (double i = 0; i <= X2; i += 0.4 * Scale)
            {
                if (i >= X1)
                {
                    Line line = new Line()
                    {
                        Y1 = 0,
                        Y2 = Canvas.Height,
                        X1 = i - this.X1,
                        X2 = i - this.X1
                    };
                    if (i == 0)
                        line.Stroke = Brushes.Black;
                    else
                        line.Stroke = Brushes.Gray;
                    Canvas.Children.Add(line);
                }
            }
        }
        private void PrintYLeftLines()
        {
            for (double i = 0; i >= X1; i -= 0.4 * Scale)
            {
                if (i <= X2)
                {
                    Line line = new Line()
                    {
                        Y1 = 0,
                        Y2 = Canvas.Height,
                        X1 = i - this.X1,
                        X2 = i - this.X1
                    };
                    if (i == 0)
                        line.Stroke = Brushes.Black;
                    else
                        line.Stroke = Brushes.Gray;
                    Canvas.Children.Add(line);
                }
            }
        }
        public void PrintFunc()
        {
            InfoWorker info = new InfoWorker(Expression, Range, Step);
            Polyline polyline = new Polyline()
            {
                Stroke = Brushes.Red,
                Points = new PointCollection()
            };
            foreach (var rpn in info.RPNs)
            {
                if (rpn.X * (0.4 * Scale) >= X1 && rpn.X * (0.4 * Scale) <= X2 &&
                    -rpn.Y * (0.4 * Scale) >= Y1 && -rpn.Y * (0.4 * Scale) <= Y2)
                {
                    Point point = new Point()
                    {
                        X = rpn.X * (0.4 * Scale) - X1,
                        Y = -rpn.Y * (0.4 * Scale) - Y1
                    };
                    polyline.Points.Add(point);
                }
            }
            Canvas.Children.Add(polyline);
        }
    }
}
