using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Fractals
{
    class CantorSet:Fractal
    {
        List<Path> lines;
        /// <summary>
        /// Вертикальное расстояние между линиями
        /// </summary>
        public Vector Distance { get; set; }
        public override int MaxIters { get; } = 5;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="distance">Вертикальное расстояние</param>
        public CantorSet(double distance)
        {
            Distance = new(0,distance);
            lines = new List<Path>();
        }

        public override Path[] Redraw(int iters, double height, double width)
        {
            iterations = iters;
            lines.Clear();
            Point startPoint = new(width / 6, Distance.Length);
            Point endPoint = new(width / 6 * 5, Distance.Length);
            Path startLine = new();
            startLine.Data = new LineGeometry(startPoint, endPoint);
            startLine.Stroke = new SolidColorBrush(CalculateColor(0));
            startLine.StrokeThickness = 5;
            lines.Add(startLine);
            if (iterations > 1)
                CreateLines(1,startLine.Data as LineGeometry);
            return lines.ToArray();
        }
        /// <summary>
        /// Реализует одну итерацию
        /// </summary>
        /// <param name="iter">Текущая итерация</param>
        /// <param name="previousLine">Линия из предыдущей итерации</param>
        void CreateLines(int iter,LineGeometry previousLine)
        {
            Point point1 = new((2 * previousLine.StartPoint.X + previousLine.EndPoint.X) / 3, previousLine.StartPoint.Y);
            Point point2 = new((previousLine.StartPoint.X + 2 * previousLine.EndPoint.X) / 3, previousLine.StartPoint.Y);
            Path firstLine = new();
            firstLine.Data = new LineGeometry(previousLine.StartPoint + Distance, point1 + Distance);
            Path secondLine = new();
            secondLine.Data = new LineGeometry(point2 + Distance, previousLine.EndPoint + Distance);
            firstLine.Stroke =new SolidColorBrush(CalculateColor(iter));
            secondLine.Stroke = new SolidColorBrush(CalculateColor(iter));
            firstLine.StrokeThickness = 5;
            secondLine.StrokeThickness = 5;
            lines.Add(firstLine);
            lines.Add(secondLine);
            if (iter + 1 != iterations)
            {
                CreateLines(iter + 1, firstLine.Data as LineGeometry);
                CreateLines(iter + 1, secondLine.Data as LineGeometry);
            }
        }
    }
}
