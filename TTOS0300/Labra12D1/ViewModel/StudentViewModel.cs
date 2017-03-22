using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Labra12D1
{
    class StudentViewModel
    {
        public ObservableCollection<Student>  Students
        {
            get;
            set;
        }

        public void LoadStudents()
        {
            ObservableCollection<Student> students = new ObservableCollection<Student>();
            // Lisätään esimerkin vuoksi muutama opiskelija, oikeassa sovelluksessa haettaisiin esim tietokannasta
            students.Add(new Student { FirstName = "Kalle", LastName = "Jalkanen" });
            students.Add(new Student { FirstName = "Tomi", LastName = "Töttenström" });
            students.Add(new Student { FirstName = "Teppo", LastName = "Testaaja" });
            Students = students;
        }
        //metodi StudentViewModeliin jolla haetaan oppilastiedot mysql-palvemilta
        public void LoadStudentsFromMysql()
        {
            try
            {
                ObservableCollection<Student> students = new ObservableCollection<Student>();
                //luodaan yhteys labranetin mysql-palvelimelle
                string connStr = GetMysqlConnectionString();
                string sql = "SELECT firstname, lastname, asioid FROM students";
                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Labra12D1.Student s = new Student();
                            s.FirstName = reader.GetString(0);
                            s.LastName = reader.GetString(1);
                            s.AsioId = reader.GetString(2);
                            students.Add(s);
                        }
                        Students = students;
                    }
                }
            }
            catch
            {
                throw;
            }
        }
        private string GetMysqlConnectionString()
        {
            string pw = ""; //"Yuz2g30hyDj5cxK2Cqa9phGiockFBZfr";
            pw = Properties.Settings.Default.passu;
            //Haetaan salasana app.Config- tiedostosta
            return string.Format("Data source=mysql.labranet.jamk.fi;Initial Catalog=K9414_3;user=K9414;password={0}",pw);
        }
    }
}
