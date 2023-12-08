using ConsoleApp4;
using Seminar_1;
using System;

public class App
{

    public static void Main(string[] args)
    {
        addFamiliesPetrovich();
    }
    public static void addFamiliesPetrovich()
    {
        FamamlyMembers GrandFather = new FamamlyMembers()
        {
            FullName = "Петрович дедуся по бате",
            Age = 50,
            Gender = Gender.man


        };

        FamamlyMembers GrandFatherSecond = new FamamlyMembers()
        {
            FullName = "Дедуся по маме",
            Age = 51,
            Gender = Gender.man


        };

        FamamlyMembers GrandMother = new FamamlyMembers()
        {
            FullName = "Петрович бабуся по папе",
            Age = 60,
            Gender = Gender.woman


        };

        FamamlyMembers GrandMotherSecond = new FamamlyMembers()
        {
            FullName = "Петрович бабуся по маме",
            Age = 48,
            Gender = Gender.woman


        };

        FamamlyMembers Mother = new FamamlyMembers()
        {
            FullName = "Петрович мама",
            Age = 30,
            Gender = Gender.woman,
            Father = GrandFatherSecond,
            Mother = GrandMotherSecond

        };

        FamamlyMembers Father = new FamamlyMembers()
        {
            FullName = "Петрович батя",
            Age = 35,
            Gender = Gender.man,
            Father = GrandFather,
            Mother = GrandMother,



        };

        FamamlyMembers Son = new FamamlyMembers()
        {
            FullName = "Петрович сын",
            Age = 16,
            Gender = Gender.man,
            Mother = Mother,
            Father = Father

            
        };
        ViewFamily view = new ViewFamily();
        view.PrintFamilyTree(Son);

    }
}
