using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class MyMathFunctionLib
    {

        public enum enOpType { Add = '+', Sub = '-', Mult = '*', Div = '/' }

        public static int SimpleCalculator(int num1, int num2, enOpType opType)
        {

            switch (opType)
            {

                case enOpType.Add:
                    return num1+num2;
                case enOpType.Sub:
                    return num1-num2;
                case enOpType.Mult:
                    return num1 * num2;
                case enOpType.Div:
                    return num1 / num2;
                default:
                    //return num1+num2;
                    throw new ArgumentException("Invalid operation type");

            }

        }


    }

}
