using System;

namespace ParenthesesBalancing
{
  /* Calculates if the parenthesis of the input string are balanced. See the tests for more information. */

  public class ParenthesesBalancing
  {
        public bool IsBalanced(string input)
        {
            int parenthesis = 0;

            //
            if (input.Length == 0)
            {
                return true;
            }

            //
            if ((!input.Contains("(")) && (!input.Contains(")")))
            {
                return true;
            }

            //
            foreach (char c in input)
            {
                if(c == '(')
                {
                    parenthesis++;
                }
                else if(c == ')')
                {
                    parenthesis--;
                }

                if (parenthesis < 0)
                {
                    return false;
                }
            }

            if(parenthesis == 0)
            {
                return true;
            }

            return false;
        }

      
  }
}