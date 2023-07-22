using System;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exitRequested = false;

            while (!exitRequested)
            {
                Console.WriteLine("Simple Calculator");
                Console.WriteLine("------------------");
                Console.WriteLine("Enter an expression  or 'exit' to quit:");

                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    exitRequested = true;
                }
                else
                {
                    try
                    {
                        // Evaluate the expression
                        double result = EvaluateExpression(input);
                        Console.WriteLine("Result: " + result);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }

        static double EvaluateExpression(string expression)
        {
            expression = expression.Replace(" ", ""); // Remove any white spaces

            // Find the operator index
            int operatorIndex = -1;
            char[] operators = { '+', '-', '*', '/' };

            foreach (char op in operators)
            {
                operatorIndex = expression.IndexOf(op);
                if (operatorIndex != -1)
                    break;
            }

            if (operatorIndex == -1)
                throw new ArgumentException("Invalid expression.");

            // Parse operands
            double operand1 = double.Parse(expression.Substring(0, operatorIndex));
            double operand2 = double.Parse(expression.Substring(operatorIndex + 1));

            // Perform the calculation
            switch (expression[operatorIndex])
            {
                case '+':
                    return operand1 + operand2;
                case '-':
                    return operand1 - operand2;
                case '*':
                    return operand1 * operand2;
                case '/':
                    if (operand2 == 0)
                        throw new DivideByZeroException("Cannot divide by zero.");
                    return operand1 / operand2;
                default:
                    throw new ArgumentException("Invalid operator.");
            }
        }
    }
}
