/* Ассинхронное программирование
 * 
 * Это подход к написанию кода при котором выполнение операций выносится  из основного потока выполнения программы.
 * 
 * Синхронность - это когда опирации поочереди.
 * Ассинхронность - некоторые операции выполняются параллельно с основным потоком.
 * 
 * Можно использовать, когда долгие вычесления, работа с бд, нужно увеличить отзывчивость приложения.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Method();
    }

    static void Method()
    {
        // Ассинхронная операция возвращающая тип Т
        Task<int> task = Task.FromResult(42);
    }

    public async Task Method2()
    {
        var task1 = Task.Delay(200);
        var task2 = Task.Delay(1000);

        await Task.WhenAll(task1, task2);
        Console.WriteLine("ttttttt");

        var a = await Task.WhenAny(task1, task2);
    }
}