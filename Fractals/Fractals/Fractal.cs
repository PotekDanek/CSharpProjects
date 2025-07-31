using System;
using System.Windows.Shapes;
using System.Windows.Media;


namespace Fractals
{
    abstract class Fractal
    {
        /// <summary>
        /// Первый цвет
        /// </summary>
        public Color StartColor { get; set; } = Colors.Black;
        /// <summary>
        /// Последний цвет
        /// </summary>
        public Color EndColor { get; set; } = Colors.Black;
        /// <summary>
        /// Количество итераций
        /// </summary>
        protected int iterations;
        /// <summary>
        /// Максимальное количество итераций
        /// </summary>
        public abstract int MaxIters { get; }
        /// <summary>
        /// Перерисовывает фрактал
        /// </summary>
        /// <param name="iteration">Количество итераций</param>
        /// <param name="height">Высота холста</param>
        /// <param name="width">Ширина холста</param>
        /// <returns></returns>
        public abstract Path[] Redraw(int iteration, double height, double width);
        /// <summary>
        /// Рассчитывает цвет для данной итерации
        /// </summary>
        /// <param name="iter">Итерация</param>
        /// <returns></returns>
        protected Color CalculateColor(int iter)
        {
            byte redStep = (byte)((EndColor.R - StartColor.R) / iterations);
            byte greenStep = (byte)((EndColor.G - StartColor.G) / iterations);
            byte blueStep = (byte)((EndColor.B - StartColor.B) / iterations);

            return Color.FromRgb((byte)(StartColor.R + redStep * iter), (byte)(StartColor.G + greenStep * iter), (byte)(StartColor.B + blueStep * iter));
        }
    }
}
