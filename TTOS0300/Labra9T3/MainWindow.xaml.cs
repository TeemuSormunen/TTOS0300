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

namespace Labra9T3
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
                int korkeus = Convert.ToInt32(textBox.Text);
                int leveys = Convert.ToInt32(textBox1.Text);
                int karmipuu = Convert.ToInt32(textBox2.Text);

                int ikkunanala = korkeus * leveys / 100;
                int lasinala = ((korkeus - karmipuu) * (leveys - karmipuu)) / 100;
                int karmipituus = (leveys * 2 + korkeus * 2) / 10;

                textBox3.Text = Convert.ToString(ikkunanala + " cm ^ 2");
                textBox4.Text = Convert.ToString(lasinala + " cm^2");
                textBox5.Text = Convert.ToString(karmipituus + " cm");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
