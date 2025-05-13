using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

public class Products
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
    public int CategoryId { get; set; }
    public void Print()
    {
        Console.WriteLine($"{Id}: {Name}");
        Console.WriteLine($"{CategoryId}: {Price}$");
    }
}

public class Categories
{
    public int Id { get; set; }
    public string Name { get; set; }
    public void Print()
    {
        Console.WriteLine($"{Id}: \"{Name}\"");
    }
}

public class Orders
{
    public int Id { get; set; }
    public string Date { get; set; }
    public int CustomerId { get; set; }
    public string Status { get; set; }
    public void Print()
    {
        Console.WriteLine($"{Id}: {Date} - {CustomerId}: {Status}");
    }
}

public class OrderDetails
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public int Quanyity { get; set; }
    public void Print()
    {
        Console.WriteLine($"{Id}: {OrderId}: {ProductId}: {Quanyity}");
    }
}

public class Customers
{
    public int Id { get; set; }
    public int FirstName { get; set; }
    public int LastName { get; set; }
    public int Email { get; set; }
    public void Print()
    {
        Console.WriteLine($"{Id}: {FirstName} {LastName} - {Email}");
    }
}

public class AppDbContext : DbContext
{
    public DbSet<Products> Products { get; set; }
    public DbSet<Categories> Categories { get; set; }
    public DbSet<Products> Orders { get; set; }
    public DbSet<Categories> OrderDetails { get; set; }
    public DbSet<Products> Customers { get; set; }
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

        context.Products.AddRange(
            new Product
            {
                Id = 1,
                Name = "Бесполезный куб из облачного хранилища",
                Price = 999,
                CategoryId = 3,
            },
            new Product
            {
                Id = 2,
                Name = "Вечная батарейка (работает только когда гремит гром)",
                Price = 404,
                CategoryId = 3
            },
            new Product
            {
                Id = 3,
                Name = "Курс 'Как стать 10x разработчиком за 24 часа'",
                Price = -500, // Платят вам за страдания
                CategoryId = 2
            },
            new Product
            {
                Id = 4,
                Name = "Кофе для программиста 'Syntax Error' (с нотками отладки до рассвета)",
                Price = 1337,
                CategoryId = 1
            }
        );

        context.Categories.AddRange(
            new Category
            {
                Id = 1,
                Name = "Еда для тех, кто видел 3am"
            },
            new Category
            {
                Id = 2,
                Name = "Цифровые страдания"
            },
            new Category
            {
                Id = 3,
                Name = "Физические воплощения багов"
            },
            new Category
            {
                Id = 4,
                Name = "NFT-коллекция 'Мемы с совещаний'"
            }
        );
        
        context.Orders.AddRange(
            new Order
            {
                Id = 1,
                Date = "2023-12-32",
                CustomerId = 4,
                Status = "Застрял в лифте с курьером"
            },
            new Order
            {
                Id = 2,
                Date = "1970-01-01",
                CustomerId = 1,
                Status = "Доставлено в /dev/null"
            },
            new Order
            {
                Id = 3,
                Date = "2024-02-29",
                CustomerId = 3,
                Status = "Застрял в лифте с курьером"
            }
        );
        
        context.OrderDetails.AddRange(
            new OrderDetail
            {
                Id = 1,
                OrderId = 2,
                ProductId = 3,
                Quanyity = 42 // Ответ на главный вопрос
            },
            new OrderDetail
            {
                Id = 2,
                OrderId = 1,
                ProductId = 4,
                Quanyity = 0xC0FFEE // Шестнадцатеричный кофе
            },
            new OrderDetail
            {
                Id = 3,
                OrderId = 3,
                ProductId = 1,
                Quanyity = -1 // Бесконечный цикл
            }
        );
        
        context.Customers.AddRange(
            new Customer
            {
                Id = 1,
                FirstName = "Иван",
                LastName = "Дурак",
                Email = "click.me@example.com"
            },
            new Customer
            {
                Id = 2,
                FirstName = "Нано",
                LastName = "Бот",
                Email = "beep_boop@ai.mail"
            },
            new Customer
            {
                Id = 3,
                FirstName = "Ошибка",
                LastName = "404",
                Email = "not_found@void.com"
            },
            new Customer
            {
                Id = 4,
                FirstName = "Чак",
                LastName = "Норис",
                Email = "roundhouse.kick@sql.injection"
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
