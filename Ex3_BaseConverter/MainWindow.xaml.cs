/*
 * Задание 3: Конвертация целочисленных данных в бинарные.
 *
 * Created: 04.04.23
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ex3_BaseConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            sourseBaseCompoBox.SelectedItem = 10;
            targetBaseCompoBox.SelectedItem = 2;
            sourceNumberTextBox.Text = "";
            targetNumberTextBox.Text = "";
        }

        private string ConverNumberBase(string srcNumber, int sourceBase, int targetBase)
        {
            string alphabet = "0123456789ABCDEF";

            int number;
            
            if (!int.TryParse(srcNumber, out number))
            {
                MessageBox.Show("Input format error");
                return "";
            }
            if (number < 0)
            {
                MessageBox.Show("The number must not be negative!");
                return "";
            }

            StringBuilder result = new StringBuilder();
            int reminder = 0;

            do
            {
                reminder = number % targetBase;
                number /= targetBase;
                result.Insert(0, alphabet[reminder].ToString());

            } while (number > 0);

            return result.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string number = sourceNumberTextBox.Text;
            int sourceBase = (int) sourseBaseCompoBox.SelectedItem;
            int targetBase = (int) targetBaseCompoBox.SelectedItem;

            targetNumberTextBox.Text = ConverNumberBase(number, sourceBase, targetBase);
        }
    }
}
