using System;
using System.Linq;
using System.Text;

// 1. Use new and old syntax ✅
// 2. Use record types
// 3. Ranges & indices ✅
// 4. * Create an interface with default implementation
//      and create two classes which would implement it ✅
// 5. Use pattern matching features ✅


namespace App
{
    class Program
    {
        public static void Main(string[] args)
        {
            var list = new List<Animal>
            {
                new Lion("John"),
                new Bird("Sia"),
                new Dog("Michael"),
                new Bird("Travis"),
                new Lion("Jolene"),
                new Dog("Billy"),
                new Bird("Serene"),
                new Lion("Rob"),
                new Bird("Kito"),
                new Bird("Kyle")
            };

            var flyingCreatures = new List<IFlies>();
            var walkingCreatures = new List<IWalks>();

            foreach (var item in list)
            {
                if ( item is IWalks )
                {
                    walkingCreatures.Add((IWalks)item);
                } else
                {
                    flyingCreatures.Add((IFlies)item);
                }
            }


            foreach (var item in walkingCreatures)
            {
                item.Walk();
            }
            foreach (var item in flyingCreatures)
            {
                item.Fly();
            }


            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n---- The walking creatures list reversed ----");
            for (int i = 0; i < walkingCreatures.Count; i++)
            {
                Console.WriteLine($"[{walkingCreatures.Count - 1 - i}]: " + walkingCreatures[^(i+1)]);
            }




            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n---- Some lyrics ----");
            var songLyric = new string[] { "В", "траве", "сидел", "кузнечик", "зелененький", "он", "был" };
            Console.OutputEncoding = Encoding.UTF8;

            var partOfALyric = songLyric[2..5];
            foreach (var item in partOfALyric)
            {
                Console.Write(item + " ");
            }

            var ageSequence = new int[] { 4, 38, 23, 2, 11, 18, 17, 83};

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n---- Classifying the age ----");
            foreach (var item in ageSequence)
            {
                Console.WriteLine(ClassifyByAge(item));
            }
       


        }

        public static string ClassifyByAge(int item) => item switch
        {
            (> 0) and (< 4) => "It's a baby",
            (< 4) and (< 12) => "It's a child",
            (< 12) and (< 19) => "It's a teenager",
            (< 19) and (< 67) => "It's an adult",
            < 67 => "It's elder person",
            _ => "Who is it???"
        };
    }


    interface IFlies
    {
        public void Fly() => Console.WriteLine("I'M FLYING!"); 
    }

    interface IWalks
    {
        public void Walk() => Console.WriteLine("I'M walking..??");
    }

    class Animal
    {
        public string Name { get; set; }

        public Animal(string name)
        {
            Name = name;
        }

        public override string? ToString()
        {
            return "Name: " + Name;
        }
    }

    class Lion : Animal, IWalks
    {
        public Lion(string name) : base(name)
        {
        }
    }

    class Dog : Animal, IWalks
    {
        public Dog(string name) : base(name)
        {
        }
    }

    class Bird : Animal, IFlies
    {
        public Bird(string name) : base(name)
        {
        }
    }
}