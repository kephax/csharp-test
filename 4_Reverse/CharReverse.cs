using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Reverse
{
  public class CharReverse
  {
    /// <summary>
    /// Reverses the characters in each word in the sentence, while keeping the same order of words.
    /// The words are delimited by: space, comma, dot
    /// eg: The quick brown fox ==> ehT kciuq nworb xof
    /// </summary>
    /// <param name="input">String to reverse words in.</param>
    /// <returns>The string containing reversed words.</returns>
    public string Reverse(string input)
    {
            if (input.Length == 0)
            {
                return input;
            }

            string reversedInput = "";

            string[] words = Regex.Split(input, @"(\s|\.|\,)");

            foreach (string word in words)
            {
                reversedInput += ReverseWord(word);
            }

            return reversedInput;

        }



        private string ReverseWord(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }



    }
}