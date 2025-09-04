using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Template_Classes
{

    // C# Generic Classes

    public class Calculator<T> where T : INumber<T>
    {

        private T _number1;
        private T _number2;

        public Calculator(T n1, T n2)
        {

            _number1= n1;
            _number2= n2;

        }

        public void PrintResults()
        {

            Console.WriteLine($"\nNumbers: {_number1} and {_number2}.");

            Console.WriteLine($"\n{_number1} + {_number2} = {Add()}");
            Console.WriteLine($"\n{_number1} - {_number2} = {Subtract()}");
            Console.WriteLine($"\n{_number1} * {_number2} = {Multiply()}");
            Console.WriteLine($"\n{_number1} / {_number2} = {Divide()}");

        }

        public T Add()
        {

            //return (dynamic)_number1 + (dynamic)_number2; // unsafe, slower
            return _number1 + _number2;

        }
        
        public T Subtract()
        {
            return _number1 - _number2;
        }

        public T Multiply()
        {
            return _number1 * _number2;
        }

        public T Divide()
        {
            return _number1 / _number2;
        }

    }
}
