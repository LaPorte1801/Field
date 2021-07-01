using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Field
{
    /// <summary>
    /// Логика взаимодействия для GraphReg.xaml
    /// </summary>
    public partial class GraphReg : Window
    {
        public GraphReg()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void ColorSelector(Brush brush)
        {
            switch (colorBox.SelectedIndex)
            {
                case 0:
                    brush = Brushes.Black;
                    break;
                case 1:
                    brush = Brushes.Blue;
                    break;
                case 2:
                    brush = Brushes.Red;
                    break;
                case 3:
                    brush = Brushes.Green;
                    break;
                case 4:
                    brush = Brushes.Yellow;
                    break;
                default:
                    break;
            }
        }

        public void FuncSelector(Func<double, double, double> func)
        {
            switch (functionBox.SelectedIndex)
            {
                case 0:
                    func = Functions.LinearFuncDelegate;
                    break;
                case 1:
                    func = Functions.QuadraticFuncDelegate;
                    break;
                case 2:
                    func = Functions.SinFuncDelegate;
                    break;
                case 3:
                    func = Functions.CosFuncDelegate;
                    break;
                default:
                    break;
            }
        }

    }
}
