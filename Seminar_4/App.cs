using System;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Seminar_4;
class App
{
    public static void Main(string[] args)
    {
        int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8 };

        int target = 7;
        Console.WriteLine("Это решения я посмотрел в интернете... оно выводит все возможные варианты\r\nтам используется Dictionary, хотя я не понял зачем..");
        HomeWork.PrintAllTriplets(nums, target);

        Console.WriteLine("_____________");

        Console.WriteLine("А это моё... тут я додумался только до тройного цикла...");
        HomeWork.MySolution(nums, target);


    }


    static void test()
    {
        //    Дан массив и число. Найдите три числа в массиве сумма которых равна искомому числу. 
        //    Подсказка: если взять первое число в массиве, можно ли найти в оставшейся его части два числа равных по сумме первому.
        int[] array = new int[15] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 14, 12, 13, 11, 15 };
        int target = 27;
        var variants = new HashSet<int>();
        foreach (var i in array)
        {
            var checkFirstValue = target - i;
            if (variants.Contains(checkFirstValue))
            {
                Console.WriteLine($"{checkFirstValue} + {i} = {target}");
            }
            else
            {
                variants.Add(i);
            }

        }
    }
    static void task4()
    {
        List<string> list = new List<string>();
        list.Add("Danik");
        list.Add("Daniil");
        list.Add("Danila");
        list.Add("Danya");
        list.Add("Dodik");

        string check = "iK";

        var result = list.Where(s => s.ToUpper().Contains(check.ToUpper())).Select(s => s.ToUpper());
        Console.WriteLine(string.Join("\n", result));

    }
    static void task3()
    {
        List<User> users = new List<User>();
        users.Add(new User() { FirstName = "Петя", LastName = "Пуп", Age = 33 });
        users.Add(new User() { FirstName = "Петя", LastName = "Снюс", Age = 33 });
        users.Add(new User() { FirstName = "Даня", LastName = "Нави", Age = 22 });
        users.Add(new User() { FirstName = "Люба", LastName = "Нави", Age = 22 });
        users.Add(new User() { FirstName = "Люба", LastName = "Снюс", Age = 22 });
        users.Add(new User() { FirstName = "Люба", LastName = "Снюс", Age = 11 });

        var firstName = users.GroupBy(x => x.FirstName).OrderByDescending(g => g.Count()).First().Key;
        Console.WriteLine(firstName);
        var lasttName = users.GroupBy(x => x.LastName).OrderBy(g => g.Count()).First().Key;
        Console.WriteLine(lasttName);
        var age = users.GroupBy(x => x.Age).OrderBy(g => g.Count()).Last().Key;
        Console.WriteLine(age);
    }
    static void task2()
    {
        //Дан список целых чисел(числа не последовательны), в котором некоторые числа повторяются.
        //Выведите список чисел на экран, исключив из него повторы. Постарайтесь сделать задачу за O(N)
        List<int> ints = new List<int> { 0, 1, 1, -1, 101, 102, 101, 11, 1111, 11 };
        List<int> ints2 = new List<int>();
        foreach (var item in ints)
        {
            if (!ints2.Any(i => i == item))
            {
                ints2.Add(item);
            }
        }
        foreach (int i in ints2)
        {
            Console.WriteLine(i);
        }
    }
    static void task1()
    {
        // Дан список целых чисел(числа не последовательны), в котором некоторые числа повторяются.
        // Выведите список чисел на экран, расположив их в порядке возрастания частоты повторения

        List<int> ints = new List<int> { 1, 2, 2, 2, 3, 4, 4, 5, 5, 5, 5, 6, 7, 0 };

        Dictionary<int, int> dict = new Dictionary<int, int>();

        foreach (int i in ints)
        {
            if (dict.ContainsKey(i))
                dict[i]++;
            else
                dict.Add(i, 0);
        }


        PriorityQueue<int, int> queue = new PriorityQueue<int, int>();
        //yes
        foreach (var element in dict)
        {
            queue.Enqueue(element.Key, element.Value * -1);

        }

        while (queue.Count > 0)
        {
            Console.WriteLine(queue.Dequeue());
        }
    }
    static void lecture()
    {
        var d = new Dictionary<string, int>();
        var text = "Тест текста текста! Я я пример для для для ознакомления!";
        var sb = new StringBuilder();
        foreach (var elem in text)
        {
            if (Char.IsLetter(elem))
            {
                sb.Append(elem);
            }
            else
            {
                if (sb.Length > 0)
                {
                    var key = sb.ToString().ToLower();
                    if (d.ContainsKey(key))
                    {
                        d[key]++;
                    }
                    else { d[key] = 1; }
                    sb.Clear();
                }
            }
        }
        if (sb.Length > 0)
        {
            var key = sb.ToString().ToLower();
            if (d.ContainsKey(key))
            {
                d[key]++;
            }
            else { d[key] = 0; }
            sb.Clear();
        }
        foreach (var item in d)
        {
            Console.WriteLine($"{item.Key} = {item.Value}");
        }
    }

}
class User
{
    public string FirstName;
    public string LastName;
    public int Age;
}