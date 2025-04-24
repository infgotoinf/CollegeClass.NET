using System.Runtime.CompilerServices;

class Calculator
{
    
    static int Main()
    {
        while (true)
        {
            string? firstNum;
            do
            {
                firstNum = Console.ReadLine();
            } while (firstNum == null);

            if (double.TryParse(firstNum, out var number)) break;
            else
            {
                Console.WriteLine("Not a number!");
            }
        }

        while (true)
        {
            string? operation;
            do
            {
                operation = Console.ReadLine();
            } while (operation == null);

            bool result = (String operation =>
            {
                switch (operation)
                {
                    case "-":
                    case "+":
                    case "/":
                    case "*":
                    case "%":
                        return false;
                    default:
                        return true;
                }
            })

            if ((operation) =>
            {
                switch (operation)
                {
                    case "-":
                    case "+":
                    case "/":
                    case "*":
                    case "%":
                        return false;
                    default:
                        return true;
                }
            });

        }

        
        


        return 0;
    }
}
