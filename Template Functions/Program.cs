namespace Template_Functions
{
    // Generics in C#
    internal class Program
    {

        static T MyMax<T>(T num1, T num2) where T : IComparable<T> // constraint
        {
            return num1.CompareTo(num2)>0 ? num1 : num2;
        } 

        static dynamic MyMaxVersion2<T>(T num1, T num2)
        {

            return (dynamic)num1>num2 ? (dynamic)num1 : (dynamic)num2;

        }
        
        static dynamic MyMaxVersion3<T1, T2>(T1 num1, T2 num2)
        {

            return (dynamic)num1>num2 ? (dynamic)num1 : (dynamic)num2;

        }

        public static void Swap<T>( ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(MyMax(3, 7)); // 7 (int)
            Console.WriteLine(MyMax(9, 8.8)); // 9 (double)
            Console.WriteLine(MyMax(5.3, 8.8)); // 8.8 (double)
            Console.WriteLine(MyMax('a', 'b')); // b (char)

            Console.WriteLine();

            Console.WriteLine(MyMaxVersion2(3, 7)); // 7 (int)
            Console.WriteLine(MyMaxVersion2(9, 8.8)); // 9 (double)
            Console.WriteLine(MyMaxVersion2(5.3, 8.8)); // 8.8 (double)
            Console.WriteLine(MyMaxVersion2('a', 'b')); // b (char)

            Console.WriteLine();

            Console.WriteLine(MyMaxVersion3(9, 8.8)); // 9 (int)

            string s1 = "Hello", s2 = "World";
            Swap(ref s1, ref s2);
            Console.WriteLine($"s1={s1}, s2={s2}"); // s1=World, s2=Hello

        }
    }
}