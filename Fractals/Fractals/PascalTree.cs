using System;
using System.Windows.Shapes;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Media;
namespace Fractals
{
    class PascalTree : Fractal
    {
        /// <summary>
        /// Стартовая длина
        /// </summary>
        public double StartLength { get; set; }
        /// <summary>
        /// Коэффициент для рассчета длины следующей ветки
        /// </summary>
        public double Coefficient { get; set; }
        /// <summary>
        /// Левый угол
        /// </summary>
        public int AngleLeft { get; set; }
        /// <summary>
        /// Правый угол
        /// </summary>
        public int AngleRight { get; set; }
        /// <summary>
        /// Список веток
        /// </summary>
        List<Path> branches;
        public override int MaxIters { get; } = 10;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="len">Длина первой ветки</param>
        /// <param name="coeff">Коэффициент</param>
        /// <param name="angleL">Левый угол</param>
        /// <param name="angleR">Правый угол</param>
        public PascalTree(double len, double coeff, int angleL,int angleR)
        {
            StartLength = len;
            Coefficient = coeff;
            AngleLeft = angleL;
            AngleRight = angleR;
            branches = new List<Path>();
        }
        public override Path[] Redraw(int iter, double height, double width)
        {
            iterations = iter;
            branches.Clear();
            Point startPoint = new Point(width / 2, height/4*3);
            CreateBranch(0, startPoint, new Vector(0, -StartLength));
            return branches.ToArray();
        }
        /// <summary>
        /// Создание ветки
        /// </summary>
        /// <param name="iter">Текущая итерация</param>
        /// <param name="startPoint">Точка начала отрезка</param>
        /// <param name="vector">Вектор, задающий направление и длину ветки</param>
        void CreateBranch(int iter, Point startPoint, Vector vector)
        {
            // Создание "ветки" 
            Path branch = new Path();
            branch.Stroke = new SolidColorBrush(CalculateColor(iter));
            branch.StrokeThickness = 1;
            Point endPoint = startPoint + vector;
            branch.Data = new LineGeometry(startPoint, endPoint);
            branches.Add(branch);

            // Рекурсивный вызов
            if (iter+1 != iterations)
            {
                CreateBranch(iter + 1, endPoint, Vector.Move(Math.Pow(Coefficient, iter+1) * vector, -AngleLeft));
                CreateBranch(iter + 1, endPoint, Vector.Move(Math.Pow(Coefficient, iter+1) * vector, AngleRight));
            }
        }
    }
}
