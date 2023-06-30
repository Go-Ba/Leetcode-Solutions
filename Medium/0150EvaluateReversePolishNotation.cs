using System.Collections.Generic;

public class EvaluateReversePolishNotation
{
    //https://leetcode.com/problems/evaluate-reverse-polish-notation/
    public class Solution
    {
        public int EvalRPN(string[] tokens)
        {
            var stack = new Stack<int>();
            foreach (var t in tokens)
            {
                int result = t switch
                {
                    //the first item popped needs to be the
                    //second item in the equation.
                    //thus we need to reverse the - and / operations
                    //as they are not symmetrical 
                    "+" => stack.Pop() + stack.Pop(),
                    "-" => -stack.Pop() + stack.Pop(),
                    "*" => stack.Pop() * stack.Pop(),
                    "/" => (int)(1d / stack.Pop() * stack.Pop()),
                    _ => int.Parse(t)
                };
                stack.Push(result);
            }
            return stack.Pop();
        }
    }
    public class Solution_RecursivePointer
    {
        int pointer;
        string[] tokens;
        public int EvalRPN(string[] tokens)
        {
            pointer = tokens.Length - 1;
            this.tokens = tokens;
            return GetResult(tokens[pointer--]);
        }
        public int GetResult(string input)
        {
            if (int.TryParse(input, out int result))
                return result;
            return EvaluateExpression(GetResult(tokens[pointer--]), input, GetResult(tokens[pointer--]));
        }
        public int EvaluateExpression(int b, string op, int a)
        {
            return op switch
            {
                "+" => a + b,
                "-" => a - b,
                "*" => a * b,
                "/" => a / b,
                _ => int.MaxValue,
            };
        }
    }
    public class Solution_RecursiveStack
    {
        Stack<string> stack;
        public int EvalRPN(string[] tokens)
        {
            stack = new Stack<string>();
            for (int i = 0; i < tokens.Length; i++)
                stack.Push(tokens[i]);

            return GetResult(stack.Pop());
        }
        public int GetResult(string input)
        {
            if (int.TryParse(input, out int result))
                return result;

            return EvaluateExpression(GetResult(stack.Pop()), input, GetResult(stack.Pop()));
        }
        public int EvaluateExpression(int b, string op, int a)
        {
            return op switch
            {
                "+" => a + b,
                "-" => a - b,
                "*" => a * b,
                "/" => a / b,
                _ => int.MaxValue,
            };
        }
    }
}