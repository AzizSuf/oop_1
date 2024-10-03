using System.Drawing;
using System.Globalization;
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

namespace AnyType
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Type[] types = new Type[] { typeof(char), typeof(string),
                                    typeof(byte), typeof(int),
                                    typeof(float), typeof(double),
                                    typeof(decimal), typeof(bool),
                                    typeof(object) };

        public MainWindow()
        {
            InitializeComponent();
            fromTypeComboBox.ItemsSource = types;
            fromTypeComboBox.SelectedIndex = 0;

            toTypeComboBox.ItemsSource = types;
            toTypeComboBox.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Type t = (Type)fromTypeComboBox.SelectedValue;

            string val = inputTextBox.Text;

            var methodInfo = t.GetMethod("Parse", new Type[] { typeof(string) });

            object[] parameters = new object[] { val };

            object ret = null;
            try
            {
                ret = methodInfo.Invoke(null, parameters);
                label.Content = "Conversion from text sucsess";
                label.Background = new SolidColorBrush(Colors.Green);
            }
            catch (Exception ex)
            {
                label.Content = "Conversion from text failed";
                label.Background = new SolidColorBrush(Colors.Red);
            }

            Type to = (Type)toTypeComboBox.SelectedValue;

        }
    }
}