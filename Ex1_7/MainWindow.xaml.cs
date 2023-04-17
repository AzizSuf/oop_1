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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ex1_7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            inputNumberTextBox.Text = "";
            statusLabel.Content = "";
        }

        private void CheckNumber(string text)
        {
            double number = 0;

            try
            {
                number = double.Parse(text);
                statusLabel.Background = new SolidColorBrush(Color.FromArgb(100, 38, 127, 0));
                statusLabel.Content = "OK";
            }
            catch (Exception)
            {
                statusLabel.Background = new SolidColorBrush(Color.FromArgb(100, 255, 0, 0));
                statusLabel.Content = "Error";
                return;
            }
        }

        private void checkButton_Click(object sender, RoutedEventArgs e)
        {
            CheckNumber(inputNumberTextBox.Text);
        }

        private void numberTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.IsLoaded && (autoCheckBox.IsChecked ?? false))
            {
                CheckNumber(inputNumberTextBox.Text);
            }
        }

        private void autoCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckNumber(inputNumberTextBox.Text);
        }
    }
}
