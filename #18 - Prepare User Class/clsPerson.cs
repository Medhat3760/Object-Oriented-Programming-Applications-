using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prepare_User_Class
{
    public class clsPerson
    {

        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phone;

        public clsPerson(string firstName, string lastName, string email, string phone)
        {

            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _phone = phone;

        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string getFullName
        {
            get { return _firstName + " " + _lastName; }
        }

        /*
         * No UI Related code inside object.
        public void Print()
        {

            Console.WriteLine("\nInfo:");
            Console.WriteLine("______________________________");
            Console.WriteLine("First Name: " + _firstName);
            Console.WriteLine("Last Name : " + _lastName);
            Console.WriteLine("Full Name : " + getFullName);
            Console.WriteLine("Email     : " + _email);
            Console.WriteLine("Phone     : " + _phone);
            Console.WriteLine("______________________________");

        }
        */

    }
}
