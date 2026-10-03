using System;

namespace KT_1
{
    public static class BracketBalancer
    {
        public static bool IsBalanced(string expression)
        {
            if (string.IsNullOrEmpty(expression))
            {
                return true;
            }

            MyStack<char> stack = new MyStack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];

                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    if (stack.IsEmpty)
                    {
                        return false;
                    }

                    char top = stack.Pop();
                    if (!IsMatchingPair(top, c))
                    {
                        return false;
                    }
                }
            }

            return stack.IsEmpty;
        }

        private static bool IsMatchingPair(char opening, char closing)
        {
            if (opening == '(' && closing == ')')
            {
                return true;
            }
            if (opening == '[' && closing == ']')
            {
                return true;
            }
            if (opening == '{' && closing == '}')
            {
                return true;
            }
            return false;
        }
    }
}
