using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml.Linq;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public int Pages { get; set; }
    public string Genre { get; set; }
    public Book(string title, string author, int year, int pages, string genre)
    {
        Title = title;
        Author = author;
        Year = year;
        Pages = pages;
        Genre = genre;
    }
}

class Program
{
    static int Main()
    {
        var books = new List<Book>()
        {
            new Book("How to use Nlohman C++", "Nlohman", 1969, 69, "Programming"),
            new Book("UwU in the modern word of technoogy", "Mr.UwUwster", 2024, 300, "IT"),
            new Book("I use Arch btw", "Mr.UwUwster", 2025, 20, "Linux"),
            new Book("101 reason to hate python", "CoolGuy", 2023, 512, "Programming"),
            new Book("Cars in de code", "CoolGuy", 2024, 34, "Programming"),
            new Book("How to hide a corpse", "ParkourStalkesSniperAssasin2283372007", 2024, 51, "Everyday life"),
            new Book("Most important keyboard shortcuts for vim", "CoolGuy", 2023, 666, "Programming"),
            new Book("Fready Fazber's in my code!", "Mr.UwUwster", 2025, 34, "Programming"),
            new Book("How to use NUKE and GUYS in your code", "CoolGuy", 2025, 23, "Programming"),
            new Book("[]___-[]--__[]-", "ParkourStalkesSniperAssasin2283372007", 2024, 13, "Diary"),
        };

        var year = books
            .Where(x => x.Year <= 2023)
            .Select(x => x.Title);
        foreach (var i in year)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();

        var pagesorder = books
            .OrderBy(x => x.Pages)
            .Select(x => x.Title);
        foreach (var i in pagesorder)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();

        var genres = books.GroupBy(x => x.Genre);
        foreach (var i in genres)
        {
            Console.WriteLine($"Genre: {i.Key}");
            foreach (var j in i)
            {
                Console.WriteLine($"{j.Title} - {j.Author}");
            }
        }
        Console.WriteLine();

        var count = books.Count();
        Console.WriteLine($"Number of books - {count}");

        var sum = books.Sum(x => x.Pages);
        Console.WriteLine($"Sum of pages - {sum}");

        var min = books.Min(x => x.Pages);
        Console.WriteLine($"Min number of pages - {min}");

        var max = books.Max(x => x.Pages);
        Console.WriteLine($"Max number of pages - {max}");

        var average = books.Average(x => x.Pages);
        Console.WriteLine($"Average number of pages - {average}\n");

        foreach (var i in genres)
        {
            Console.WriteLine($"Genre \"{i.Key}\" has {i.Count()} books");
        }
        Console.WriteLine();

        var cool = books
            .Where(x => x.Author == "CoolGuy")
            .OrderBy(x => x.Year)
            .Select(x => x.Title);
        foreach (var i in cool)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();

        var first = books.Take(3);
        var last = books.Skip(count - 3);

        //Не уверен
        var nodupl = books.Union(books);

        return 0;
    }
}