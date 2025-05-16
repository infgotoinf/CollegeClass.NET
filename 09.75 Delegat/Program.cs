using System;

class Program
{
    delegate int CalculateDeliver(int a, int b);

    static void Main()
    {
        back:
        CalculateDeliver deliver;
        Console.WriteLine("Give the cost");
        string cost = Console.ReadLine();
        int.TryParse(cost, out var cost_num);

        Console.WriteLine("Give the distance");
        string distance = Console.ReadLine();
        int.TryParse(distance, out var distance_num);

        Console.WriteLine("По какой доставке хотите?");
        Console.WriteLine("1:Фиксированной; 2:Зависящей от цены; 3:Зависящей от расстояния");
        string deliverType = Console.ReadLine();
        switch(deliverType)
        {
            case ("1"):
                deliver = Fixed;
                break;
            case ("2"):
                deliver = Precent;
                break;
            case ("3"):
                deliver = Distance;
                break;
            default:
                goto back;
        }
        InvokeDelegate(deliver, cost_num, distance_num);
    }

    static int Fixed(int cost_num, int distance_num)
    {
        return 500;
    }

    static int Precent(int cost_num, int distance_num)
    {
        cost_num /= 10;
        return cost_num;
    }

    static int Distance(int cost_num, int distance_num)
    {
        distance_num /= 20;
        return distance_num;
    }

    static void InvokeDelegate(CalculateDeliver deliver, int a, int b)
    {
        if (deliver != null)
        {
            foreach (CalculateDeliver handler in deliver.GetInvocationList())
            {
                try
                {
                    Console.WriteLine($"Результат выполнения {handler.Method.Name}: {handler(a, b)} рублей");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка в методе {handler.Method.Name}: {ex.Message}");
                }
            }
        }
    }
}