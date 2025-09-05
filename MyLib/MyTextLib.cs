using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyLib
{
    public class MyTextLib
    {

        // Function to return a string with the required number of tabs
        public static string Tabs(short numberOfTabs)
        {

            string tabs = ""; // Initialize an empty string to store the tabs

            for (short i = 1; i <= numberOfTabs; i++)
            {

                tabs += "\t"; // Append a tab character ("\t") to the string during each iteration

            }

            return tabs; // Return the string with the required number of tabs

        }


        // Function to return a string with the required number of newLines
        public static string NewLines(short numberOfLines)
        {

            string newLines = ""; // Initialize an empty string to store the newLines

            for (short i = 0; i < numberOfLines; i++)
            {

                newLines += "\n"; // Append a tab character ("\n") to the string during each iteration

            }

            return newLines; // Return the string with the required number of newLines

        }


        // Function to return a column separator based on the counter value
        public static string ColumnSeparator(int counter)
        {

            if (counter < 10)
            {

                return "   |"; // return a string with 3 spaces followed by a pipe character "|"

            }
            else
            {

                return "  |"; // return a string with 2 spaces followed by a pipe character "|"

            }

        }


        // Helper method to format cells with right alignment
        public static string FormatCell(string text, short width)
        {

            return text.PadLeft(width); // Aligns the text to the right with the specified width

        }


        public static string EncryptText(string text, short encryptionKey)
        {

            char[] charArray = text.ToCharArray(); // Convert the string to a char array

            for (int i = 0; i < text.Length; i++) // Change the condition from <= to < since arrays are 0-indexed
            {

                charArray[i] = (char)(text[i] + encryptionKey); // Encrypt each character

            }

            return new string(charArray); // Return the new encrypted string

        }

        public static string DecryptText(string text, short encryptionKey)
        {

            char[] charArray = text.ToCharArray();

            for (int i = 0; i < text.Length; i++)
            {

                charArray[i] = (char)(charArray[i] - encryptionKey); // Decrypt each character

            }

            return new string(charArray); // Return the new Decrypted string

        }



    }
}
