using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public enum Gender { man, woman }
    public class FamamlyMembers
    {
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string FullName { get; set; }
        public FamamlyMembers Mother { get; set; }
        public FamamlyMembers Father { get; set; }


        public FamamlyMembers[] GetGrandMotherName()
        {
            return new FamamlyMembers[] { Mother?.Mother, Father?.Mother };
        }


        public FamamlyMembers[] GetGrandFatherName()
        {
            return new FamamlyMembers[] { Mother?.Father, Father?.Father };
        }


    }
}