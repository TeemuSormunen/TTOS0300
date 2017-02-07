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

namespace Labra9T2
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double valuutta = Convert.ToDouble(textBox.Text);

                textBlock.Text = Convert.ToString(valuutta * 5.94);
            }
            
            catch (Exception)
            {
                MessageBox.Show("Textbox can't be empty");
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double valuutta = Convert.ToDouble(textBox.Text);

                textBlock.Text = Convert.ToString(valuutta / 5.94);

            }
            catch (Exception)
            {
                MessageBox.Show("Textbox can't be empty");
            }

        }
    }
}
