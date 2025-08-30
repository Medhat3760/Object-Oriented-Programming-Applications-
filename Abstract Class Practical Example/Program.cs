
namespace Abstract_Class_Practical_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {

            clsPerson person1 = new clsPerson("", "", "", "");

            person1.SendSMS("title", "body");
            
        }
    }
}