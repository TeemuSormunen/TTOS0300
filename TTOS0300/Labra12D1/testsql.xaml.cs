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
using System.Windows.Shapes;

namespace Labra12D1
{
    /// <summary>
    /// Interaction logic for testsql.xaml
    /// </summary>
    public partial class testsql : Window
    {
        public testsql()
        {
            InitializeComponent();
        }

        private void btnGetData_click(object sender, RoutedEventArgs e)
        {
            try
            {
                Labra12D1.StudentViewModel svmo = new StudentViewModel();
                svmo.LoadStudentsFromMysql();
                dgStudents.DataContext = svmo.Students;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
