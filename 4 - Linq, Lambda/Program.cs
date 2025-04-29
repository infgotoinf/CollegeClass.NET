using System.Collections.Generic;
using System.Xml.Linq;

class Person
{
    public string Name { get; set; }

    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

/***************************************************************************/

class Departament
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public Departament(int id, string name)
    {
        Id = id;
        Name = name;
    }
}

class Employee
{
    public int DepartamentId { get; set; }
    public string Name { get; set; }
    public Employee(int departamentId, string name)
    {
        DepartamentId = departamentId;
        Name = name;
    }
}


/***************************************************************************/
/***************************************************************************/

class Program
{
    static int Main()
    {
        int[] nums = { 1, 2, 3, 4, 5 };

        var evenNums = nums.Where(x => x % 2 == 0);

        var evenNums2 = from x in nums
                        where x % 2 == 0
                        select x;

        string[] names = { "Loh", "Loh21", "Loh3" };

        /***************************************************************************/

        var sortedNames = names.OrderBy(x => x.Length);

        var sortedNames3 = names.OrderByDescending(x => x.Length);

        foreach (var name in sortedNames)
        {
            Console.WriteLine(name);
        }

        var sortedNames2 = from name in names
                           orderby name.Length
                           select name;

        /***************************************************************************/

        var squares = nums.Select(x => x * x);

        var squares2 = from x in squares
                       select x;

        /***************************************************************************/

        int count = nums.Count();
        int sum = nums.Sum();
        int min = nums.Min();
        int max = nums.Max();
        double average = nums.Average();

        var result = nums
            .Where(x => x % 2 != 0)
            .OrderByDescending(x => x)
            .Select(x => x * x);

        /***************************************************************************/

        var people = new List<Person>()
        {
            new Person("Loh", 25),
            new Person("Loh21", 21),
            new Person("Loh3", 69),
            new Person("Loh404", 25)
        };

        var groupedPeople = people.GroupBy(x => x.Age);

        foreach (var grouped in groupedPeople)
        {
            Console.WriteLine($"Years: {grouped.Key}");
            foreach (var person in grouped)
            {
                Console.WriteLine(person.Name);
            }
        }

        /***************************************************************************/

        var departaments = new List<Departament>
        {
            new Departament(1, "HR"),
            new Departament(2, "IT")
        };

        var employees = new List<Employee>
        {
            new Employee(1, "Loh3"),
            new Employee(2, "Loh"),
            new Employee(1, "Loh21")
        };

        var employeeDepartaments = departaments.Join(
            employees,
            d => d.Id,
            e => e.DepartamentId,
            (d, e) => new {DepartamentName = d.Name, EmployeeName = e.Name}
            );

        foreach (var item in employeeDepartaments)
        {
            Console.WriteLine($"{item.EmployeeName} works in {item.DepartamentName}");
        }

        /***************************************************************************/

        int[] nums1 = { 1, 2, 3, 4, 5 };
        int[] nums2 = { 4, 5, 6, 7, 8 };

        var nums3 = nums1.Concat(nums2);

        foreach (var i in nums3)
        {
            Console.WriteLine(i);
        }

        var nums4 = nums3.Distinct();

        foreach (var i in nums4)
        {
            Console.WriteLine(i);
        }

        var nums5 = nums1.Union(nums2);
        var nums6 = nums1.Intersect(nums2);
        var nums7 = nums1.Except(nums2);

        var nums8 = nums1.Skip(2).Take(2);
        var nums9 = nums1.SkipWhile(x => x < 2).TakeWhile(x => x < 4);
        return 0;
    }
}