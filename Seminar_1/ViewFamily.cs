using ConsoleApp4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seminar_1
{
    public class ViewFamily
    {
        public FamamlyMembers person { get; set; }
       
        public  void PrintFamilyTree(FamamlyMembers sun, int level = 0)
        {
            Console.WriteLine(new string('-', level) + sun.FullName);
            if (sun.Mother != null)
            {
                PrintFamilyTree(sun.Mother, level + 1);
            }
            if (sun.Father != null)
            {
                PrintFamilyTree(sun.Father, level + 1);
            }
        }
    }
}
