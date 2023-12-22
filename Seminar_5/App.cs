using System.Threading.Channels;

namespace Seminar_5;

class App
{
    private static void Calculator_GotResult(object sendler, EventArgs eventArgs)
    {
        Console.WriteLine($"ваше число {((Calculator)sendler).Result} ");
    }
    static int SumEvenNums(List<int> list,Predicate<int> isEven ,Func<int, int, int> operation)
    {
        int sum = 0;
        foreach (int item in list)
        {
            if(isEven(item))
            sum = operation(item, sum);
        }
        return sum;
    }
    static int SumEvenNumsAndPrint(List<int> list, Predicate<int> isEven, Func<int, int, int> operation, Action<int> action)
    {
        int sum = 0;
        foreach (int item in list)
        {
            if (isEven(item))
            {
                sum = operation(item, sum);
                action(sum);
            }
                
        }
        return sum;
    }
    public static void Main(string[] args)
    {
        Calculator calc = new Calculator();
        calc.GotResult += Calculator_GotResult;
        string action;
        Console.WriteLine("ваше число " + calc.Result); 
        
        while (true)
        {
            action = "";
            Console.WriteLine("введите действие ( /, *, -, +, <= - (вернуть пред. знач.)");
            action = Console.ReadLine();
            if (action.Length == 0) break;
            CalcAction(calc, action);

        }
    }
    static void CalcAction(Calculator calc, string action)
    {
        switch (action)
        {
            case "/":
                calc.Divide(GetInt());
                break;
            case "*":
                calc.Multiply(GetInt());
                break;
            case "-":
                calc.Substuct(GetInt());
                break;
            case "+":
                calc.Sum(GetInt());
                break;
            case "<=":
                calc.CancelLast();
                break;
            default:
                Console.WriteLine("Не верное действие"); break;
        }
    }
    static int GetInt()
    {
        Console.WriteLine("введите число");
        return int.Parse(Console.ReadLine());
    }
    void leson() {
        //ICalc calc = new Calculator();
        //calc.GotResult += Calculator_GotResult;
        //calc.Divide(1);
        //calc.CancelLast();
        //Console.WriteLine("-------");
        //List<int> list = new List<int>() {1,2,3,4,5 };
        //int res = calc.SumNums(list, (x, y) => x + y);
        //Console.WriteLine(res);
        //Console.WriteLine("-------");
        //res = SumEvenNums(list, x => x % 2 == 0, (x, y) => x + y);
        //Console.WriteLine(res);
        //Console.WriteLine("-------");
        //res = SumEvenNumsAndPrint(list, x => x % 2 == 0, (x, y) => x + y,Console.WriteLine);
    }

}