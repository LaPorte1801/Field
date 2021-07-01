using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Field
{
    static class Functions
    {
        public static Func<double, double, double> LinearFuncDelegate = new Func<double, double, double>(LinearFunc);
        public static Func<double, double, double> QuadraticFuncDelegate = new Func<double, double, double>(QuadraticFunc);
        public static Func<double, double, double> SinFuncDelegate = new Func<double, double, double>(SinFunc);
        public static Func<double, double, double> CosFuncDelegate = new Func<double, double, double>(CosFunc);

        private static double LinearFunc(double a, double x) => a * x;
        private static double QuadraticFunc(double a, double x) => a * x * x;
        private static double SinFunc(double a, double x) => a * Math.Sin(x);
        private static double CosFunc(double a, double x) => a * Math.Cos(x);
    }
}
