using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Field
{
    class Lattice : Canvas
    {
        int cellSize;
        public int CellSize
        {
            get
            {
                return cellSize;
            }

            set
            {
                if (value < 1)
                    cellSize = 1;
                else
                    cellSize = value;
            }
        }

        public Brush Color { get; set; }

        public Lattice(int cellSize, Brush color, double height, double width)
        {
            CellSize = cellSize;
            Color = color;
            Height = height;
            Width = width;
        }

        public void LatticeRender()
        {
            List<Line> verLines = new List<Line>();
            List<Line> horLines = new List<Line>();

            //заполнение коллекций линий
            for (int i = 0; i < this.Width / cellSize; i++)
            {
                verLines.Add(new Line());
                verLines[i].StrokeThickness = 0.5;
                verLines[i].Stroke = Color;
            }

            for (int i = 0; i < this.Height / cellSize; i++)
            {
                horLines.Add(new Line());
                horLines[i].StrokeThickness = 0.5;
                horLines[i].Stroke = Color;
            }

            //расстановка линий
            for (int i = 0; i < this.Width / cellSize; i++)
            {
                verLines[i].X1 = i * cellSize;
                verLines[i].X2 = i * cellSize;
                verLines[i].Y1 = 0;
                verLines[i].Y2 = this.Height;
            }

            for (int i = 0; i < this.Height / cellSize; i++)
            {
                horLines[i].X1 = 0;
                horLines[i].X2 = this.Width;
                horLines[i].Y1 = i * cellSize;
                horLines[i].Y2 = i * cellSize;
            }

            this.Children.Clear();
            //добавление линий в canvas
            for (int i = 0; i < verLines.Count; i++)
            {
                verLines[i].Stroke = Brushes.Black;
                this.Children.Add(verLines[i]);
            }

            for (int i = 0; i < horLines.Count; i++)
            {
                horLines[i].Stroke = Brushes.Black;
                this.Children.Add(horLines[i]);
            }
        }
    }
}
