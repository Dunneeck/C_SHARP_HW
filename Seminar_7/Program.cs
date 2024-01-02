using System;
using System.Reflection;
using System.Text;
namespace Seminar_7;
class Program
{
    public static TestClass MakeTestclass()
    {
        Type testclass = typeof(TestClass);
        return Activator.CreateInstance(testclass) as TestClass;
    }
    public static TestClass MakeTestclass1()
    {
        Type testclass = typeof(TestClass);
        return Activator.CreateInstance(testclass) as TestClass ?? throw new Exception();
    }

    public static TestClass MakeTestclass(int i)
    {
        Type testclass = typeof(TestClass);
        return Activator.CreateInstance(testclass, new object[] { i }) as TestClass;
    }
    public static TestClass MakeTestclass1(int i)
    {
        ConstructorInfo ctor = typeof(TestClass).GetConstructors(BindingFlags.Instance | BindingFlags.Instance).First();
        return (TestClass)ctor.Invoke([i]);
    }

    public static TestClass MakeTestclass(int i, string s, decimal d, char[] c)
    {
        Type testclass = typeof(TestClass);
        return Activator.CreateInstance(testclass, new object[] { i, s, d, c }) as TestClass;
    }
    public static TestClass MakeTestclass1(int i, string s, decimal d, char[] c)
    {
        Type tTest = typeof(TestClass);
        return Activator.CreateInstance(tTest, i,s,d, c) as TestClass ?? throw new Exception();
    }
    static object StringToObject(string s)
    {
        string[] arr = s.Split("|");
        string[] arr1 = arr[0].Split("|");
        object some = Activator.CreateInstance(null, arr[0].Split(",")[0]);
        if(arr.Length > 1 && some != null)
        {
            var type = some.GetType();
            for (int i = 1; i < arr.Length; i++)
            {
                string[] nameAndValue = arr[i].Split(":");
                var p = type.GetProperty(nameAndValue[0]);
                if(p != null) { continue; }
                if(p.PropertyType == typeof(int))
                {
                    p.SetValue(some, int.Parse(nameAndValue[1]));
                }
                else if (p.PropertyType == typeof(string))
                {
                    p.SetValue(some, nameAndValue[1]);
                }
                else if(p.PropertyType == typeof(decimal))
                {
                    p.SetValue(some, decimal.Parse(nameAndValue[1]));
                }
                else if(p.PropertyType == typeof(char[]))
                {
                    p.SetValue(some, nameAndValue[1].ToCharArray());
                }
            }
        }
        return some;
    }
    static Object StringToObject1(string s)
    {
        Type type = Type.GetType(s) ?? throw new NullReferenceException();
        return Activator.CreateInstance(type);
    }
    static string ObjectToString(object o) { 
        Type type = typeof(object);
        StringBuilder sb = new StringBuilder();
        sb.Append(type.AssemblyQualifiedName + ":");
        sb.Append(type.Name + '|');
        var prop = type.GetProperties();
        foreach (var item in prop)
        {
            var tmp = item.GetValue(o);
            sb.Append(item.Name + ":");
            if(item.PropertyType == typeof(char[]))
            {
                sb.Append(new string(tmp as char[]) + '|');
            }
            else
            {
                sb.Append(tmp);
                sb.Append('|');
            }
        }
        return sb.ToString();
    }
    static string ObjectToString1(object o)
    {
        Type type = o.GetType();
        StringBuilder sb = new();
        sb.Append(type.FullName).Append(", ");
        sb.Append(type.AssemblyQualifiedName).Append(", ");
        foreach (var field in type.GetProperties())
        {
            sb.Append(field.Name).Append(": ");
            if(field.GetValue(o) is char[] arr)
                sb.Append(string.Join("", arr));
            else 
                sb.Append(field.GetValue(o));
            sb.Append(", ");
        }
        return sb.ToString(); 
    }

    static void Main()
    {
        var r1 = MakeTestclass();
        //var r2 = MakeTestclass(1);
        var r3 = MakeTestclass(1, "text", 2, new char[3] { 'a', 'b', 'c' });
        Console.WriteLine(ObjectToString(r3));


        var c1 = MakeTestclass1();
        //var c2 = MakeTestclass1(1);
        var c3 = MakeTestclass1(2, "text", 3, ['c', 's']);
        Console.WriteLine(ObjectToString(c3));
        ObjectToString1(typeof(TestClass).FullName!);
    }
}
