/*
 * Задание 2: Вычислить квадратный корень с контролем точности.
 *
 * Created: 28.02.23
 * Author : Aziz Sufyanov
 * e-mail : aziz-sufyanov@mail.ru
 */

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

        /// <summary>
        /// Вычисляет квадратный корень с помощью библиотеки .NET Math.
        /// Вычисляет квадратный корень с помощью метода Ньютона.
        /// Отображает информацию на окне.
        /// </summary>
        /// <param name="inEps">Точность расчета квадратоного корня методом Ньютона</param>
        private void CalcSquareRoots(decimal inEps)
        {
            iterationsRichTextBox.Document.Blocks.Clear();
            double number = 0;

            if (!double.TryParse(numberTextBox.Text, out number))
            {
                MessageBox.Show("Invalid input format!");
                return;
            }
            if (number < 0)
            {
                MessageBox.Show("The number must not be negative!");
            }

            double netRoot = Math.Sqrt(number);
            resultDotNetLabel.Content = netRoot.ToString();

            decimal numberD = decimal.Parse(numberTextBox.Text);
            decimal newtonRoot = numberD / 2.0m;

            decimal prevNewtonRoot = 0;
            decimal eps = inEps;

            int i = 0;
            while (Math.Abs(newtonRoot - prevNewtonRoot) > eps && (i < ITERATIONS_LIMIT))
            {
                iterationsRichTextBox.AppendText($"iter: {i},  value: {newtonRoot}\r");
                prevNewtonRoot = newtonRoot;

                newtonRoot = (numberD / newtonRoot + newtonRoot) / 2;

                i++;
            }
            iterationsRichTextBox.AppendText($"iter: {i},  value: {newtonRoot}\r");

            resultNewtonLabel.Content = newtonRoot.ToString();
            diffLabel.Content = Math.Abs((decimal)netRoot - newtonRoot).ToString();
        }

        /// <summary>
        /// Обработчик кнопки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fullButton_Click(object sender, RoutedEventArgs e)
        {
            CalcSquareRoots(0.0m);
        }

        /// <summary>
        /// Обработчик кнопки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void epsButton_Click(object sender, RoutedEventArgs e)
        {
            decimal eps;

            if (!decimal.TryParse(epsilonTextBox.Text, out eps))
            {
                MessageBox.Show("Invalid input format!");
                return;
            }

            if (eps < 0)
            {
                MessageBox.Show("The eps must not be negative!");
            }

            CalcSquareRoots(eps);
        }

    }
}
