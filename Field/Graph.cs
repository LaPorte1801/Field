using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Field
{
    class Graph : Shape
    {
        public double A { get; set; }
        public double From { get; set; }
        public double To { get; set; }
        public Point Center { get; set; }
        public Func<double, double, double> Func { get; set; }

        public Graph(double thickness, Brush stroke, double a, double from, double to, Point center, Func<double, double, double> func)
        {
            StrokeThickness = thickness;
            Stroke = stroke;
            A = a;
            From = from;
            To = to;
            Center = center;
            Func = func;
        }
        protected override Geometry DefiningGeometry => throw new NotImplementedException();
    }
}
