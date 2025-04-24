class Base
{
    static int Main()
    {
        string UwU = "UwU";
        Console.WriteLine(UwU);
        Console.ReadKey();
        Console.Clear();
        Console.WriteLine($"{UwU}");
        Console.WriteLine("{0}{1}", UwU, UwU);
        double? OwO = Convert.ToDouble(Console.ReadLine());
        int a = 10, b = 20;
        int c = ++a * b--;

        if (a < b)
        {
        }
        else if (c > b)
        {
        }
        else
        {
        }

        Console.Write(a > b ? "Lol" : "Mem");
        switch (c)
        {
            case 0:
            case 1:
                Console.WriteLine();
                break;
            default:
                break;
        }

        return 0;
    }
}