using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using JAMK.ICT;
namespace labra11demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Koska useampi metodi=tapahtumankäsittelijä tulee käyttämään näitä muuttujia
        //määritellään luokan tasolle luokan jäsenmuuttujia
        JAMK.ICT.HockeyLeague liiga;
        ObservableCollection<JAMK.ICT.HockeyTeam> joukkueet;
        int counter = 0;
        public MainWindow()
        {
            InitializeComponent();
            IniMyStuff();
        }
        private void IniMyStuff()
        {
            //Tänne kootusti omien kontrollien alustukset
            List<string> muuvit = new List<string>();
            muuvit.Add("Halloween");
            muuvit.Add("Jaws");
            muuvit.Add("Star wars");
            muuvit.Add("Star trek");
            cmbMovies.ItemsSource = muuvit;
            //Haetaan SMLiiga-joukkueet
            liiga = new JAMK.ICT.HockeyLeague();
            joukkueet = liiga.GetTeams();
            cmbTeam.ItemsSource = joukkueet;

        }

        private void nappi_Click(object sender, RoutedEventArgs e)
        {
            //määritellään stackpanelin datacontext
            //Demo1: Datacontekstini on olio
            //HockeyTeam tiimi = new HockeyTeam("KeuPa", "Keuruu");
            //spRight.DataContext = tiimi;
            //demo2 Kytketään olio-kokoelman 1. olioon
            spRight.DataContext = joukkueet[counter];

        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            counter++;
            spRight.DataContext = joukkueet[counter];
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            counter--;
            spRight.DataContext = joukkueet[counter];
        }
    }
}
