using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Field
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int cellSize = 20;
        Graph graph;
        Lattice lattice;

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Обработчики

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lattice = new Lattice(cellSize, Brushes.Black, field.ActualHeight, field.ActualWidth);
            lattice.LatticeRender();


            field.Height = graphGrid.ActualHeight;
            field.Width = graphGrid.ActualWidth;

            field.Children.Add(lattice);
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            graphGrid.Height = e.NewSize.Height;
            graphGrid.Width = e.NewSize.Width * graphBlock.Width.Value / functionBlock.Width.Value - 12;

            field.Height = graphGrid.Height;
            field.Width = graphGrid.Width;

            if (IsLoaded)
            {
                field.Children.Remove(lattice);
                lattice.Height = field.ActualHeight;
                lattice.Width = field.ActualWidth;
                lattice.LatticeRender();
                field.Children.Add(lattice);
            }
        }

        private void cellSizeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (IsLoaded)
            {
                lattice.CellSize = (int)e.NewValue;
                cellSize = (int)e.NewValue;
                field.Children.Remove(lattice);
                lattice.Height = field.ActualHeight;
                lattice.Width = field.ActualWidth;
                lattice.LatticeRender();
                field.Children.Add(lattice);
            }
        }
        #endregion
        
        private static void SetDot(Grid grid, Point point, int cellSize, Brush fill, int dotSize = 10)
        {
            Ellipse ellipse = new Ellipse();
            Canvas canvas = new Canvas();

            canvas.Height = grid.Height;
            canvas.Width = grid.Width;

            ellipse.Fill = fill;
            ellipse.Height = dotSize;
            ellipse.Width = dotSize;

            canvas.Children.Add(ellipse);

            Canvas.SetLeft(ellipse, (int)point.X * cellSize - ellipse.Height / 2);
            Canvas.SetTop(ellipse, (int)point.Y * cellSize - ellipse.Width / 2);

            grid.Children.Add(canvas);
        }

        private static void SetGraph(Grid grid, int cellSize, Graph graph)
        {
            Polyline polyline = new Polyline();
            Canvas canvas = new Canvas();
            canvas.Height = grid.Height;
            canvas.Width = grid.Width;
            polyline.Stroke = graph.Stroke;
            polyline.StrokeThickness = graph.StrokeThickness;

            canvas.Children.Add(polyline);

            Canvas.SetTop(polyline, graph.Center.Y * cellSize);
            Canvas.SetLeft(polyline, graph.Center.X * cellSize);

            int accuracy = 1000;

            PointCollection points = new PointCollection();
            double[] values = new double[accuracy];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = graph.From + (graph.To - graph.From) / accuracy * i;
            }
            
            for (int i = 0; i < values.Length; i++)
            {
                points.Add(new Point(values[i] * cellSize, graph.Func(graph.A, values[i]) * cellSize));
            }

            polyline.Points = points;

            grid.Children.Add(canvas);
        }

        //private void createGraph_Click(object sender, RoutedEventArgs e)
        //{
        //    //GraphReg graphReg = new GraphReg();
        //    //graphReg.ShowDialog();

        //    //Brush color = null;
        //    //graphReg.ColorSelector(color);

        //    //Func<double, double, double> func = Functions.LinearFuncDelegate;
        //    //graphReg.FuncSelector(func);

        //    //Graph graph;

        //    //graph = new Graph(Convert.ToInt32(graphReg.thicknessField.Text), color,
        //    //    Convert.ToDouble(graphReg.toField.Text),
        //    //    Convert.ToDouble(graphReg.fromField.Text), Convert.ToDouble(graphReg.toField.Text),
        //    //    new Point(Convert.ToDouble(graphReg.xField.Text), Convert.ToDouble(graphReg.yField.Text)), func);

        //    //SetGraph(graphGrid, graph.Func, cellSize, graph);
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                graph = new Graph(Convert.ToInt32(thicknessField.Text), ColorSwitch(), Convert.ToDouble(tbxParameterA.Text), Convert.ToDouble(fromField.Text),
                    Convert.ToDouble(toField.Text), new Point(Convert.ToInt32(xField.Text), Convert.ToInt32(yField.Text)),
                    FuncSwicth());
                SetGraph(graphGrid, cellSize, graph);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Input error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        private Brush ColorSwitch()
        {
            switch (colorBox.SelectedIndex)
            {
                case 0:
                    return Brushes.Black;
                case 1:
                    return Brushes.Blue;
                case 2:
                    return Brushes.Red;
                case 3:
                    return Brushes.Green;
                case 4:
                    return Brushes.Yellow;
                default:
                    return null;
            }
        }

        private Func<double, double, double> FuncSwicth()
        {
            switch (functionBox.SelectedIndex)
            {
                case 0:
                    return Functions.LinearFuncDelegate;
                case 1:
                    return Functions.QuadraticFuncDelegate;
                case 2:
                    return Functions.SinFuncDelegate;
                case 3:
                    return Functions.CosFuncDelegate;
                default:
                    return null;
            }
        }
    }
}
