using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Class_Practical_Example
{
    public abstract class CommunicationBase
    {

        public abstract void SendEmail(string title, string body);
        public abstract void SendFax(string title, string body);
        public abstract void SendSMS(string title, string body);

        protected void Log(string message)
        {
            Console.WriteLine($"[LOG] {message}");
        }

    }

}
