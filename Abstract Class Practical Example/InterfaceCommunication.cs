using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Class_Practical_Example
{
    public interface InterfaceCommunication
    {

        void SendEmail(string title, string body);
        void SendFax(string title, string body);
        void SendSMS(string title, string body);

    }

    public class person : InterfaceCommunication
    {

        private string _firstName;
        private string _lastName;
        private string _email;
        private string _phone;

        public person(string firstName, string lastName, string email, string phone)
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

        public void SendEmail(string title, string body)
        {

        }

        public void SendFax(string title, string body)
        {

        }

        public void SendSMS(string title, string body)
        {
            
        }

    }

}
