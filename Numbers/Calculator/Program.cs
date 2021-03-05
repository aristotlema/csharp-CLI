using System;


namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isActive = true;
            new Calculator("10", "2", "/");

            while(isActive)
            {
                Console.Write("number >");
                string inputx = Console.ReadLine();
                Console.Write("operator >");
                string selectedOperation = Console.ReadLine();
                Console.Write("number >");
                string inputy = Console.ReadLine();

                Console.Clear();
                new Calculator(inputx, inputy, selectedOperation);
            }
        }
    }

    public class Calculator
    {
        private int ParsedX { get; set; }
        private int ParsedY { get; set; }
        private MathOp SelectedOperation { get; set; }

        public Calculator(string x, string y, string passedOperator)
        {
            ParsedX = Int32.Parse(x);
            ParsedY = Int32.Parse(y);
            SelectedOperation = OperatorConverter(passedOperator);
            CalculateAndPrint(ParsedX, ParsedY, SelectedOperation);
        }

        private void CalculateAndPrint(int x, int y, MathOp f)
        {
            var result = f(x, y);
            Console.WriteLine(result);
        }

        private MathOp OperatorConverter(string passedOperator)
        {
            // Discovery - switch expression vs statment
            return passedOperator switch
            {
                "+" => Add,
                "-" => Subtract,
                "*" => Multiply,
                "/" => Divide,
                _ => throw new InvalidOperationException("unknown item type"),
            };
        }
        
        private int Add(int x, int y) => x + y;
        private int Subtract(int x, int y) => x - y;
        private int Multiply(int x, int y) => x * y;
        private int Divide(int x, int y) => x / y;

        delegate int MathOp(int x, int y);
    }
}
