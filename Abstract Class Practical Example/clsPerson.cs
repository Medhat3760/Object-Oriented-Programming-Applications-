using Abstract_Class_Practical_Example;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Class_Practical_Example
{
    public class clsPerson : CommunicationBase
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

        public override void SendEmail(string title, string body)
        {

        }

        public override void SendFax(string title, string body)
        {

        }

        public override void SendSMS(string title, string body)
        {
            Log("Sending SMS..."); // استخدام منطق مشترك من الـ abstract class
            Console.WriteLine($"[SMS] {title}: {body}");
        }

    }
}
