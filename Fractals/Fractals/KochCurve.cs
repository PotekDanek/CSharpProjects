using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Fractals
{
    class KochCurve : Fractal
    {
        /// <summary>
        /// Список вершин
        /// </summary>
        LinkedList<Vertex> vertices;
        public override int MaxIters { get; } = 6;
        /// <summary>
        /// Конструктор
        /// </summary>
        public KochCurve()
        {
            vertices = new LinkedList<Vertex>();
        }
        public override Path[] Redraw(int iters, double height, double width)
        {
            iterations = iters;
            vertices.Clear();
            Vertex startVertex = new(width / 5, height / 2, 0);
            Vertex endVertex = new(width / 5 * 4, height / 2, 0);
            vertices.AddFirst(startVertex);
            vertices.AddLast(endVertex);
            if(iterations>1)
                CreateCurve(1, startVertex, endVertex);

            List<Path> kochCurve = new List<Path>();
            foreach(var vertex in vertices)
            {
                if (vertex != vertices.Last.Value) 
                {
                    Path line = new Path();
                    line.Stroke = new SolidColorBrush(CalculateColor(Math.Min(vertex.Iteration, vertices.Find(vertex).Next.Value.Iteration)));
                    line.StrokeThickness = 1;
                    line.Data = new LineGeometry(vertex.Coordinate, vertices.Find(vertex).Next.Value.Coordinate);
                    kochCurve.Add(line);
                }
            }
            return kochCurve.ToArray();
        }

        /// <summary>
        /// Реализует одну итерацию
        /// </summary>
        /// <param name="iter">Текущая итерация</param>
        /// <param name="start">Первая точка отрезка</param>
        /// <param name="end">Последняя точка отрезка</param>
        void CreateCurve(int iter,Vertex start, Vertex end)
        {
            LinkedListNode<Vertex> previous = vertices.Find(start);
            LinkedListNode<Vertex> next = vertices.Find(end);
            Vector side = (double)1 / 3 * (new Vector(start.Coordinate, end.Coordinate));
            Vertex point1 = new(start.Coordinate + side,iter);
            vertices.AddAfter(previous, point1);
            Vertex point2 = new(start.Coordinate + 2 * side,iter);
            vertices.AddBefore(next, point2);
            Vertex point3 = new(point1.Coordinate + Vector.Move(side, -60),iter);
            vertices.AddAfter(previous.Next, point3);

            if (iter + 1 != iterations)
            {
                CreateCurve(iter + 1, start, point1);
                CreateCurve(iter + 1, point1, point3);
                CreateCurve(iter + 1, point3, point2);
                CreateCurve(iter + 1, point2, end);
            }
        }

        /// <summary>
        /// Вершина кривой
        /// </summary>
        class Vertex
        {
            /// <summary>
            /// Точка
            /// </summary>
            public Point Coordinate { get; private set; }
            /// <summary>
            /// Итерация, на которой рассчитана
            /// </summary>
            public int Iteration { get; private set; }
            /// <summary>
            /// Конструктор 1
            /// </summary>
            /// <param name="x">Координата x</param>
            /// <param name="y">Координата y</param>
            /// <param name="iter">Итерация</param>
            public Vertex(double x, double y, int iter)
            {
                Coordinate = new Point(x, y);
                Iteration = iter;
            }
            /// <summary>
            /// Конструктор 2
            /// </summary>
            /// <param name="p">Точка</param>
            /// <param name="iter">Итерация</param>
            public Vertex(Point p,int iter)
            {
                Coordinate = p;
                Iteration = iter;
            }
        }
    }
}
