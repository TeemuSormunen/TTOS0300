using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labra12D1
{
    public class Student
    {
        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        private string lastname;

        public string LastName
        {
            get { return lastname; }
            set { lastname = value; }
        }
        private string asioId;

        public string AsioId
        {
            get { return asioId; }
            set { asioId = value; } 
        }
        public string FullName
        {
            get
            {
                return firstName + " " + lastname;
            }
        }

    }
}
