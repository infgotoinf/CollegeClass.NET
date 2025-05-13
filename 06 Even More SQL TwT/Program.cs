using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public int PublicationYear { get; set; }
    public int Pages { get; set; }
    public bool IsAvalible { get; set; }
    public int Rating { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public void PrintBook()
    {
        Console.WriteLine($"{Id}: \"{Title}\" by {Author}");
        Console.WriteLine($"Genre: {Genre}; Publication Year: {PublicationYear}; Pages Count: {Pages}");
        Console.WriteLine($"Avalible: {IsAvalible}; Rating: {Rating}/100; Price: {Price}$");
        Console.WriteLine($"\"{Description}\"\n");
    }
}
public class AppDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=1234");
    }
}

class Program2
{
    static void Main()
    {
        var context = new AppDbContext();
        context.Database.EnsureCreated();

        context.Books.AddRange(
            new Book
            {
                Id = 1,
                Title = "Phython",
                Author = "Bullied Nerd",
                Genre = "Programming",
                PublicationYear = 19999,
                Pages = 2,
                IsAvalible = false,
                Rating = -228,
                Description = "LEARN HOW TO SPEAAK PYTHON IN TWO DAYS",
                Price = -1000
            },
            new Book
            {
                Id = 2,
                Title = "Gore & Flowers",
                Author = "Lingus Dingus",
                Genre = "Diary",
                PublicationYear = 2025,
                Pages = 4,
                IsAvalible = true,
                Rating = 99,
                Description = "A short but cute story about Lingus Dingus playing with his friends :3 ... and their guts... UwU",
                Price = 0
            },
            new Book
            {
                Id = 3,
                Title = "A guide to true programmer",
                Author = "Cool Guy 228 337",
                Genre = "Programming",
                PublicationYear = 1989,
                Pages = 649,
                IsAvalible = true,
                Rating = 97,
                Description = "Ultimate guide to install Archlinux, programm C and Assembly, use jsons on github as a database and never ever touch grass or speak with women",
                Price = 2500
            },
            new Book
            {
                Id = 4,
                Title = "How I realised what the most important thing is...",
                Author = "Cool Guy 228 337",
                Genre = "Diary",
                PublicationYear = 2002,
                Pages = 11423123,
                IsAvalible = false,
                Rating = 72,
                Description = "In this book I'm goint to tell you how I and why I...",
                Price = 500
            }
        );

        context.SaveChanges();

        Console.WriteLine("Хныки добавлены.\n");

        Console.WriteLine("Все продукты:");
        var books = context.Books.ToList();

        foreach (var b in books)
        {
            b.PrintBook();
        }

        Console.WriteLine("\nПоиск продукта по имени:");

        var product = context.Books.FirstOrDefault(p => p.Id == 2);

        if (product != null)
        {
            Console.WriteLine($"Найден продукт:");
            product.PrintBook();
        }
        else
        {
            Console.WriteLine("Продукт не найден.");
        }

        //Console.WriteLine("\nПродукты дороже 700:");

        //// Используем метод Where() для фильтрации продуктов.
        //var filteredProducts = context.Products.Where(p => p.Price > 700).ToList();

        //foreach (var pr in filteredProducts)
        //{
        //    Console.WriteLine($"{pr.Name} - {pr.Price}");
        //}

        //Console.WriteLine("\nОбновление цены продукта:");

        //// Ищем продукт с Id = 1 с помощью метода Find().
        //// Этот метод ищет объект в базе данных по его первичному ключу (в данном случае Id).
        //product = context.Products.Find(1);

        //if (product != null)
        //{
        //    product.Price = 900;

        //    // Сохраняем изменения в базе данных с помощью метода SaveChanges().
        //    // Без этого метода изменения останутся только в памяти программы, но не будут записаны в базу данных.
        //    context.SaveChanges();

        //    Console.WriteLine($"Цена продукта {product.Name} обновлена до {900}.");
        //}
        //else
        //{
        //    Console.WriteLine("Продукт для обновления не найден.");
        //}

        //books = context.Products.ToList();

        //foreach (var pr in books)
        //{
        //    Console.WriteLine($"{pr.Id}: {pr.Name} - {pr.Price}");
        //}

        Console.WriteLine("\nУдаление продукта:");

        product = context.Books.Find(1);

        if (product != null)
        {
            context.Books.Remove(product);

            context.SaveChanges();

            Console.WriteLine($"Продукт \"{product.Title}\" удален.");
        }
        else
        {
            Console.WriteLine("Продукт для удаления не найден.");
        }

        //books = context.Products.ToList();
        //foreach (var pr in books)
        //{
        //    Console.WriteLine($"{pr.Id}: {pr.Name} - {pr.Price}");
        //}

        //Console.WriteLine("\nСредняя цена всех продуктов:");

        //// Используем метод Average() для вычисления средней цены всех продуктов.
        //var averagePrice = context.Products.Average(p => p.Price);
        //Console.WriteLine($"Средняя цена: {averagePrice:F2}");

        Console.WriteLine("\nОчистка таблицы:");

        context.Books.RemoveRange(context.Books);

        context.SaveChanges();

        Console.WriteLine("Таблица очищена.");

        books = context.Books.ToList();
        foreach (var b in books)
        {
            b.PrintBook();
        }
    }
}
