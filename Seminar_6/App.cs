using Seminar_6;
using System.Threading.Channels;

namespace Seminar_5;

class App
{
    private static void Calculator_GotResult(object sendler, EventArgs eventArgs)
    {
        Console.WriteLine($"ваше число {((Calculator)sendler).result} ");
    }
    static int SumEvenNums(List<int> list, Predicate<int> isEven, Func<int, int, int> operation)
    {
        int sum = 0;
        foreach (int item in list)
        {
            if (isEven(item))
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
    static void Execute(Action<double> action, double value)
    {
        try
        {
            action.Invoke(value);
        }
        catch (CalculatorDivideByZeroException e)
        {
            Console.WriteLine(e);

        }
        catch (CalculateOperationCauseOverflowException e)
        {
            Console.WriteLine(e);
        }
    }
    public static void Main(string[] args)
    {
        Calculator calc = new Calculator();
        calc.GotResult += Calculator_GotResult;
        string action;
        Console.WriteLine("ваше число " + calc.result);


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
                Execute(calc.Divide, GetInt());
                break;
            case "*":
                Execute(calc.Multiply, GetInt());
                break;
            case "-":
                Execute(calc.Substuct, GetInt());
                break;
            case "+":
                Execute(calc.Sum, GetInt());
                break;
            case "<=":
                calc.CancelLast();
                break;
            default:
                Console.WriteLine("Не верное действие"); break;
        }
    }
    static double GetInt()
    {
        Console.WriteLine("введите число");
        return double.Parse(Console.ReadLine());
    }
    void leson()
    {
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