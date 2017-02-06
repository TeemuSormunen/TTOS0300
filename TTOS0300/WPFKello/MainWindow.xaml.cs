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

namespace WPFKello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int i;
        public MainWindow()
        {
         
            InitializeComponent();
            i = 0;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
            i++;
            textBlock.Text = "Hello " + textBox.Text;
            MessageBox.Show("Terve " + textBox.Text, "Teemu's");

            textBlock1.Text = Convert.ToString(i);
        }

        private void button_copy_Click(object sender, RoutedEventArgs e)
        {
            //Kutsutaan näkyviin About -niminen ikkuna
            about aboutWin = new WPFKello.about();
            //huom ikkuna voi olla joko modaalinen tai tavallinen
            aboutWin.Show();
        }
    }
}
