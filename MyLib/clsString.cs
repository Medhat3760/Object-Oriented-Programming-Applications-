using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class clsString
    {

        private string _value;

        public clsString()
        {
            _value = "";
        }

        public clsString(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public static short Length(string str)
        {

            return (short)str.Length;

        }

        public short Length()
        {
            return Length(_value);
        }

        public static void PrintFirstLetterOfEachWord(string str)
        {

            Console.WriteLine("\nFirst letter of each word:");

            bool isFirstLetter = true;

            for (int i = 0; i < str.Length; i++)
            {

                if (str[i] != ' ' && isFirstLetter)
                {
                    Console.WriteLine(str[i]);
                }

                isFirstLetter = (str[i] == ' ') ? true : false;

            }

        }

        public void PrintFirstLetterOfEachWord()
        {
            PrintFirstLetterOfEachWord(_value);
        }

        public static string UpperFirstLetterOfEachWord(string str)
        {

            char[] charsArray = str.ToCharArray();

            bool isFirstLetter = true;

            for (int i = 0; i < charsArray.Length; i++)
            {

                if (charsArray[i] != ' ' && isFirstLetter)
                {
                    charsArray[i] = char.ToUpper(charsArray[i]);
                }

                isFirstLetter = (charsArray[i] == ' ') ? true : false;

            }

            return new string(charsArray);

        }

        public void UpperFirstLetterOfEachWord()
        {
            _value = UpperFirstLetterOfEachWord(_value);
        }

        public static string LowerFirstLetterOfEachWord(string str)
        {

            char[] arrChar = str.ToCharArray();

            bool isFirstLetter = true;

            for (int i = 0; i < arrChar.Length; i++)
            {

                if (arrChar[i] != ' ' && isFirstLetter)
                {
                    arrChar[i] = char.ToLower(arrChar[i]);
                }

                isFirstLetter = (arrChar[i] == ' ') ? true : false;

            }

            return new string(arrChar);

        }

        public void LowerFirstLetterOfEachWord()
        {
            _value = LowerFirstLetterOfEachWord(_value);
        }

        public static string UpperAllString(string str)
        {

            char[] arrChar = str.ToCharArray();

            for (int i = 0; i < arrChar.Length; i++)
            {

                arrChar[i] = char.ToUpper(arrChar[i]);

            }

            return new string(arrChar);

        }

        public void UpperAllString()
        {
            _value = UpperAllString(_value);
        }

        public static string LowerAllString(string str)
        {

            char[] arrChar = str.ToCharArray();

            for (int i = 0; i < arrChar.Length; i++)
            {

                arrChar[i] = char.ToLower(arrChar[i]);

            }

            return new string(arrChar);

        }

        public void LowerAllString()
        {
            _value = LowerAllString(_value);
        }

        public static char InvertLetterCase(char c)
        {

            return char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c);

        }

        public static string InvertAllLettersCase(string str)
        {

            char[] arrChar = str.ToCharArray();

            for (int i = 0; i < arrChar.Length; i++)
            {

                arrChar[i] = InvertLetterCase(arrChar[i]);

            }

            return new string(arrChar);

        }

        public void InvertAllLettersCase()
        {

            _value = InvertAllLettersCase(_value);

        }

        public enum enWhatToCount
        {
            capitalLetters = 1, smallLetters = 2, All = 3
        }

        public static int CountLetters(string str, enWhatToCount whatToCount = enWhatToCount.All)
        {

            int counter = 0;

            switch (whatToCount)
            {

                case enWhatToCount.All:
                    for (int i = 0; i < str.Length; i++)
                    {

                        if (char.IsLetter(str[i]))
                        {
                            counter++;
                        }

                    }
                    return counter;

                case enWhatToCount.capitalLetters:
                    for (int i = 0; i < str.Length; i++)
                    {

                        if (char.IsUpper(str[i]))
                        {
                            counter++;
                        }

                    }
                    return counter;

                case enWhatToCount.smallLetters:
                    for (int i = 0; i < str.Length; i++)
                    {

                        if (char.IsLower(str[i]))
                        {
                            counter++;
                        }

                    }
                    return counter;

                default:
                    return counter;

            }

        }

        public static int CountCapitalLetters(string str)
        {

            int counter = 0;

            foreach (char letter in str)
            {
                if (char.IsUpper(letter))
                    counter++;
            }

            return counter;

        }

        public int CountCapitalLetters()
        {
            return CountCapitalLetters(_value);
        }

        public static int CountSmallLetters(string str)
        {

            int counter = 0;

            foreach (char letter in str)
            {
                if (char.IsLower(letter))
                    counter++;
            }

            return counter;

        }

        public int CountSmallLetters()
        {
            return CountSmallLetters(_value);
        }

        public static int CountSpecificLetter(string str, char letter, bool matchCase = true)
        {

            int count = 0;

            for (int i = 0; i < str.Length; i++)
            {

                if (matchCase)
                {
                    if (str[i] == letter)
                    {
                        count++;
                    }
                }
                else
                {

                    if (char.ToLower(str[i]) == char.ToLower(letter))
                    {
                        count++;
                    }

                }

            }

            return count;

        }

        public int CountSpecificLetter(char letter, bool matchCase = true)
        {
            return CountSpecificLetter(_value, letter, matchCase);
        }

        public static bool IsVowel(char letter)
        {

            letter = char.ToLower(letter);

            return letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u' || letter == 'a';

        }

        public static int CountVowels(string str)
        {

            int counter = 0;

            for (int i = 0; i < str.Length; i++)
            {

                if (IsVowel(str[i]))
                {
                    counter++;
                }

            }

            return counter;

        }

        public int CountVowels()
        {
            return CountVowels(_value);
        }

        public static void PrintAllVowels(string str)
        {

            Console.Write("\nVowels are: ");

            for (int i = 0; i < str.Length; i++)
            {

                if (IsVowel(str[i]))
                {
                    Console.Write(str[i] + " ");
                }

            }

            Console.WriteLine();

        }

        public void PrintAllVowels()
        {
            PrintAllVowels(_value);
        }

        public static void PrintEachWord(string str, string separator = " ")
        {

            Console.WriteLine("\nWords are: ");

            int pos = 0;
            string sWord = "";
            while ((pos = str.IndexOf(separator)) != -1)
            {

                sWord = str.Substring(0, pos);

                if (sWord != "")
                {
                    Console.WriteLine(sWord);
                }

                str = str.Substring(pos + separator.Length);

            }

            if (str != "")
            {
                Console.WriteLine(str);
            }

        }

        public void PrintEachWord(string separator = " ")
        {
            PrintEachWord(_value, separator);
        }

        public static int CountWords(string str, string delim = " ")
        {
            int counter = 0;
            int pos = 0;
            string sWord = "";
            while ((pos = str.IndexOf(delim)) != -1)
            {

                sWord = str.Substring(0, pos);

                if (sWord != "")
                {

                    counter++;

                }

                str = str.Substring(pos + delim.Length);

            }

            if (str != "")
            {
                counter++;
            }

            return counter;

        }

        public int CountWords(string delim = " ")
        {
            return CountWords(_value, delim);
        }

        public static List<string> Split(string str, string delim = " ")
        {

            List<string> listWords = new List<string>();

            int pos = 0;
            string sWord = " ";
            while ((pos = str.IndexOf(delim)) != -1)
            {

                sWord = str.Substring(0, pos);

                if (sWord != "")
                {
                    listWords.Add(sWord);
                }

                str = str.Substring(pos + delim.Length);

            }

            if (str != "")
            {
                listWords.Add(str);
            }

            return listWords;

        }

        public List<string> Split(string delim = " ")
        {
            return Split(_value, delim);
        }

        public static string TrimLeft(string str)
        {


            for (int i = 0; i < str.Length; i++)
            {

                if (str[i] != ' ')
                {
                    return str.Substring(i);
                }

            }

            return str;

        }

        public void TrimLeft()
        {
            _value = TrimLeft(_value);
        }

        public static string TrimRight(string str)
        {

            for (int i = str.Length - 1; i > 0; i--)
            {

                if (str[i] != ' ')
                {
                    return str.Substring(0, i + 1);
                }

            }

            return str;

        }

        public void TrimRight()
        {
            _value = TrimRight(_value);
        }

        public static string Trim(string str)
        {

            return TrimLeft(TrimRight(str));

        }

        public void Trim()
        {
            _value = Trim(_value);
        }

        public static string JoinString(List<string> lString, string delim = " ")
        {

            string str = "";

            for (int i = 0; i < lString.Count; i++)
            {

                str += lString[i];

                if (i != lString.Count - 1)
                {
                    str += delim;
                }

            }

            return str;

        }

        public static string JoinString(string[] arrString, string delim = " ")
        {

            string str = "";

            for (int i = 0; i < arrString.Length; i++)
            {

                str += arrString[i];

                if (i != arrString.Length - 1)
                {
                    str += delim;
                }

            }

            return str;

        }

        public static string ReverseWordsInString(string str, string delim = " ")
        {

            string reverseWords = "";

            List<string> lString = Split(str, delim);

            for (int i = lString.Count - 1; i >= 0; i--)
            {

                reverseWords += lString[i];

                if (i != 0)
                {
                    reverseWords += delim;
                }

            }

            return reverseWords;

        }

        public void ReverseWordsInString(string delim = " ")
        {
            _value = ReverseWordsInString(_value, delim);
        }

        public static string ReplaceWord(string str, string word, string replaceTo, string delim = " ", bool matchCase = false)
        {

            List<string> lString = Split(str, delim);

            for (int i = 0; i < lString.Count; i++)
            {
                if (matchCase)
                {
                    if (lString[i] == word)
                    {
                        lString[i] = replaceTo;
                    }
                }
                else
                {
                    if (LowerAllString(lString[i]) == LowerAllString(word))
                    {
                        lString[i] = replaceTo;
                    }
                }

            }

            return JoinString(lString, delim);

        }

        public void ReplaceWord(string word, string replaceTo, string delim = " ", bool matchCase = false)
        {
            _value = ReplaceWord(_value, word, replaceTo, delim, matchCase);
        }

        public static string RemovePunctuations(string str)
        {

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {

                if (!char.IsPunctuation(str[i]))
                {
                    sb.Append(str[i]);
                }

            }

            return sb.ToString();

        }

        public void RemovePunctuations()
        {
            _value = RemovePunctuations(_value);
        }


    }
}
