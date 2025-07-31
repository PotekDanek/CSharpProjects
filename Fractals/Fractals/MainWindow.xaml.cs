using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WPF.ColorPicker;

namespace Fractals
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Конструктор главного окна
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        // fractal - выбранный фрактал для построения
        Fractal fractal;

        /// <summary>
        /// Перерисовка фрактала
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateFractal(object sender, RoutedEventArgs e)
        {
            try
            {
                canvas.Children.Clear();
                Path[] shapes = fractal.Redraw((int)iterationsSlider.Value, this.Height, this.Width * 0.6);
                foreach (var shape in shapes)
                    canvas.Children.Add(shape);
            }
            catch (NullReferenceException)
            {
                if (this.IsActive)
                    MessageBox.Show("Choose a fractal to build!!!\n(You can choose it from the drop-down list at the top of the window)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Смена вида фрактала
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fractalComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            pascalTreeSettings.Visibility = Visibility.Collapsed;
            cantorSetSettings.Visibility = Visibility.Collapsed;
            switch (((ComboBoxItem)fractalComboBox.SelectedItem).Content)
            {
                case "Pascal Tree":
                    pascalTreeSettings.Visibility = Visibility.Visible;
                    fractal = new PascalTree(startLengthSlider.Value, coefficientSlider.Value, (int)leftAngleSlider.Value, (int)rightAngleSlider.Value);
                    break;
                case "Koch curve":
                    fractal = new KochCurve();
                    break;
                case "Sierpinski Carpet":
                    fractal = new SierpinskiCarpet();
                    break;
                case "Sierpinski Triangle":
                    fractal = new SierpinskiTriangle();
                    break;
                case "Cantor Set":
                    cantorSetSettings.Visibility = Visibility.Visible;
                    fractal = new CantorSet(distanceSlider.Value);
                    break;
            }
            iterationsSlider.Maximum = fractal.MaxIters;
            iterationsSlider.Value = iterationsSlider.Minimum;
            startColorButton.Background = new SolidColorBrush(fractal.StartColor);
            endColorButton.Background = new SolidColorBrush(fractal.EndColor);
            UpdateFractal(sender, e);
        }

        /// <summary>
        /// Выбор первого цвета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startColorButton_Click(object sender, RoutedEventArgs e)
        {
            Color color;
            if (ColorPickerWindow.ShowDialog(out color))
            {
                try
                {
                    fractal.StartColor = color;
                    startColorButton.Background = new SolidColorBrush(color);
                }
                catch (NullReferenceException)
                {
                    if (this.IsActive)
                        MessageBox.Show("Choose a fractal to build!!!\n(You can choose it from the drop-down list at the top of the window)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Выбор последнего цвета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void endColorButton_Click(object sender, RoutedEventArgs e)
        {
            Color color;
            if (ColorPickerWindow.ShowDialog(out color))
            {
                try
                {
                    endColorButton.Background = new SolidColorBrush(color);
                    fractal.EndColor = color;
                }
                catch (NullReferenceException)
                {
                    if (this.IsActive)
                        MessageBox.Show("Choose a fractal to build!!!\n(You can choose it from the drop-down list at the top of the window)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        /// <summary>
        /// Изменение длины начального отрезка для дерева Паскаля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startLengthSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (fractal != null)
                (fractal as PascalTree).StartLength = startLengthSlider.Value;
        }
        /// <summary>
        /// Изменение коэффицента для дерева Паскаля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void coefficientSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (fractal != null)
                (fractal as PascalTree).Coefficient = coefficientSlider.Value;
        }

        /// <summary>
        /// Изменение левого угла для дерева Паскаля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void leftAngleSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (fractal != null)
                (fractal as PascalTree).AngleLeft = (int)leftAngleSlider.Value;
        }

        /// <summary>
        /// Изменение правого угла для дерева Паскаля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rightAngleSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (fractal != null)
                (fractal as PascalTree).AngleRight = (int)rightAngleSlider.Value;
        }

        /// <summary>
        /// Изменение расстояния для множества Кантора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void distanceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (fractal != null)
                (fractal as CantorSet).Distance = new Vector(0, distanceSlider.Value);
        }

    }
}