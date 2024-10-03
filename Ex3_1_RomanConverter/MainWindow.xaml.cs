using System.Globalization;
using System.Numerics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ex3_1_RomanConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void arabic2RomanButton_Click(object sender, RoutedEventArgs e)
        {
            int number = 0;
            if (!int.TryParse(inputTextBox.Text, out number))
            {
                MessageBox.Show("Invalid input format!");
                return;
            }

            resultTextBox.Text = RomanConverter.ToRoman(number);
        }

        private void roman2ArabicButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                resultTextBox.Text = RomanConverter.ToArabic(inputTextBox.Text).ToString();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}