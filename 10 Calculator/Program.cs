class Calculator
{

    static int Main()
    {
        try
        {
            double firstNum = double.Parse(Console.ReadLine());

            char operation = char.Parse(Console.ReadLine());

            double secondNum = double.Parse(Console.ReadLine());

            double loh;
            switch (operation)
            {
                case '-':
                    loh = firstNum - secondNum;
                    break;
                case '+':
                    loh = firstNum + secondNum;
                    break;
                case '/':
                    if (secondNum == 0)
                        throw new DivideByZeroException("Devision by zero.");
                    loh = firstNum / secondNum;
                    break;
                case '*':
                    loh = firstNum * secondNum;
                    break;
                case '%':
                    if (secondNum == 0)
                        throw new DivideByZeroException("Devision by zero.");
                    loh = firstNum % secondNum;
                    break;
                default:
                    throw new Exception();
            }

            Console.WriteLine(loh);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return 0;
    }
}