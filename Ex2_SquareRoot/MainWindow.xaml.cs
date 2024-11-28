/*
 * Задание 2: Вычислить квадратный корень с контролем точности.
 *
 * Created: 28.02.23
 * Author : Aziz Sufyanov
 * e-mail : aziz-sufyanov@mail.ru
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ex2_SquareRoot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int ITERATIONS_LIMIT = 10000;

        /// <summary>
        /// Constructor for MainWindow
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            resultDotNetLabel.Content = "0.0";
            resultNewtonLabel.Content = "0.0";
            epsilonTextBox.Text = "0";
            diffLabel.Content = "0.0";
            iterationsRichTextBox.Document.Blocks.Clear();
        }

        private void uiProcess(decimal eps)
        {
            iterationsRichTextBox.Document.Blocks.Clear();
            double number = 0;

            if (!double.TryParse(numberTextBox.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out number))
            {
                MessageBox.Show("Invalid input format!");
                return;
            }
            if (number < 0)
            {
                MessageBox.Show("The number must not be negative!");
                return;
            }

            double netRoot = Math.Sqrt(number);
            resultDotNetLabel.Content = netRoot.ToString();

            decimal numberD = Convert.ToDecimal(number);

            int i = 0;
            decimal rootResult = 0.0m;
            foreach (decimal root in CalcSquareRootYield(numberD, eps))
            {
                iterationsRichTextBox.AppendText($"iter: {i},  value: {root}\r");
                i++;
                rootResult = root;
            }

            resultNewtonLabel.Content = rootResult.ToString();
            diffLabel.Content = Math.Abs((decimal)netRoot - rootResult).ToString();

        }

        /// <summary>
        /// Вычисляет квадратный корень с помощью метода Ньютона.
        /// </summary>
        /// <param name="number">Входное число</param>
        /// <param name="eps">Точность расчета</param>
        /// <returns>Значение в decimal</returns>
        private decimal CalcSquareRoot(decimal number, decimal eps)
        {
            decimal newtonRoot = number / 2.0m;

            decimal prevNewtonRoot = 0;

            int i = 0;
            while (Math.Abs(newtonRoot - prevNewtonRoot) > eps && (i < ITERATIONS_LIMIT))
            {
                prevNewtonRoot = newtonRoot;

                newtonRoot = (number / newtonRoot + newtonRoot) / 2;

                i++;
            }
            
            return newtonRoot;
        }

        /// <summary>
        /// Вычисляет квадратный корень с помощью метода Ньютона.
        /// </summary>
        /// <param name="number">Входное число</param>
        /// <param name="eps">Точность расчета</param>
        /// <returns>Итератор</returns>
        private IEnumerable<decimal> CalcSquareRootYield(decimal number, decimal eps)
        {
            decimal newtonRoot = number / 2.0m;

            decimal prevNewtonRoot = 0;

            int i = 0;
            while (Math.Abs(newtonRoot - prevNewtonRoot) > eps && (i < ITERATIONS_LIMIT))
            {
                prevNewtonRoot = newtonRoot;

                newtonRoot = (number / newtonRoot + newtonRoot) / 2;

                i++;
                yield return newtonRoot;
            }

            yield break;
        }

        /// <summary>
        /// Обработчик кнопки расчета с максимально возможной точностью.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fullButton_Click(object sender, RoutedEventArgs e)
        {
            uiProcess(0.0m);
        }

        /// <summary>
        /// Обработчик кнопки расчета с заданной точностью.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void epsButton_Click(object sender, RoutedEventArgs e)
        {
            decimal eps;

            if (!decimal.TryParse(epsilonTextBox.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out eps))
            {
                MessageBox.Show("Invalid input format!");
                return;
            }

            if (eps < 0)
            {
                MessageBox.Show("The eps must not be negative!");
            }

            uiProcess(eps);
        }
    }
}
