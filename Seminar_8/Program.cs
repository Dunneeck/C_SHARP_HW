


namespace Seminar_8;
class Program
{
    static void Main(string[] args)
    {
        foreach (var arg in args)
        {
            Console.WriteLine(arg);
        }
        //string str = ReaderFrom(args[0]);
        //WriteTo(str, args[1]);

        //List<string> list = SearchIn(path: args[0], name: args[1]);

        //var text = ReadFrom(args[0]);
        //var filtr = Filtr(args[1], text);
        //Console.WriteLine(String.Join("\n", filtr));

        var files = FindFiles(args[0], args[1]);
        foreach (var file in files)
        {
            ShowResult(file, args[2]);
        }


    }
    public static List<string> FindFiles(string directoryPath, string extension)
    {
        List<string> files = new List<string>();
        DirectoryInfo directory = new DirectoryInfo(directoryPath);

        if (!directory.Exists)
        {
            Console.WriteLine("Directory does not exist.");
            return files;
        }

        foreach (FileInfo file in directory.GetFiles("*." + extension))
        {
            files.Add(file.FullName);
            //Console.WriteLine(file.FullName);
        }

        foreach (DirectoryInfo subDirectory in directory.GetDirectories())
        {
            files.AddRange(FindFiles(subDirectory.FullName, extension));
        }

        return files;
    }
    static void ShowResult(string path,  string wordToFind)
    {
        using StreamReader file = new StreamReader(path);
        string line;
        while ((line = file.ReadLine()!) != null)
        {
            if (line.ToLower().Contains(wordToFind.ToLower()))
            {
                Console.WriteLine(line.ToLower());
            }
        }
    }
    static List<string> ReadFrom(string path)
    {
        List<string> list = new List<string>();
        using (StreamReader sr = new StreamReader(path))
        {
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                list.Add(line); 
            }
        }
        return list;
    }
    static List<string> Filtr(string word, List<string> text)
    {
        return text.Where(a => a.ToLower().Contains(word.ToLower())).Select(x => x.ToLower().Replace(word.ToLower(), word.ToUpper())).ToList();
    }

    private static List<string> SearchIn(string path, string name)
    {
        var list = new List<string>();
        DirectoryInfo directory = new DirectoryInfo(path);
        var directories = directory.GetDirectories();
        var files = directory.GetFiles();
        foreach (var item in files)
        {
            if (item.Name.Contains(name))
                list.Add(item.Name);
            if (item.Extension.Contains(name))
                list.Add(item.Name);
        }
        foreach (var item in directories)
            list.AddRange(SearchIn(item.FullName, name));
        return list;
    }

    private static void WriteTo(string str, string path)
    {
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
        {
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(str);
            }
        }
    }

    private static string ReaderFrom(string path)
    {
        using StreamReader st = new StreamReader(path);
        return st.ReadToEnd();
    }
}