namespace MyLib;
    public class MyCharMethods
    {

        public static char InvertCharacterCase(char character)
        {
            // Check if the character is uppercase. If true, convert it to lowercase; otherwise, convert it to uppercase.
            return char.IsUpper(character) ? char.ToLower(character) : char.ToUpper(character);

        }

    }

