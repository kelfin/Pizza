using System;
using System.Collections.Generic;
using System.Linq;

namespace Pizza
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"D:\Development\Hashcode\Pizza\Pizza\bin\Debug\netcoreapp3.1\set_input\a_example.in");

            var input = lines[0].Split(" ");
            var pizza = Convert.ToInt32(input[0]);
            var t2 = Convert.ToInt32(input[1]);
            var t3 = Convert.ToInt32(input[2]);
            var t4 = Convert.ToInt32(input[3]);

            var pizzaIng = new List<List<string>>();

            for(var i = 1; i <= pizza; i++)
            {
                var pizzaLine = lines[i];
                var pizzaSplit = pizzaLine.Split(" ");
                var bahan = pizzaSplit.TakeLast(pizzaSplit.Count() - 1).ToList();
                pizzaIng.Add(bahan);
            }

            //begin step 2
            var teams = new List<int>();
            var cTeams = new List<IEnumerable<int>>();
            for(var i = 0; i < t2; i++)
            {
                teams.Add(2);
            }

            for (var i = 0; i < t3; i++)
            {
                teams.Add(3);
            }

            for (var i = 0; i < t4; i++)
            {
                teams.Add(4);
            }

            for (var i = 1; i <= teams.Count(); i++)
            {
                var asd = EnumExtension.Combinations(teams, i).ToList();
                asd.ForEach(row =>
                {
                    var total = 0;
                    row.ToList().ForEach(r =>
                    {
                        total += r;
                    });

                    if (total <= pizza)
                        cTeams.Add(row);
                });
            }
            //end step2

            //cTeams need to distinct
            //foreach (IEnumerable<int> i in cTeams)
            //    Console.WriteLine(string.Join(" ", i));

            foreach (IEnumerable<string> i in pizzaIng)
                Console.WriteLine(string.Join(" ", i));



            //foreach (IEnumerable<int> i in cTeams)
            //{
            //    //var asd = EnumExtension.Combinations(cTeams, pizza).ToList();
            //    i.ToList().ForEach(tSize =>
            //    {
            //        Console.Write(tSize + ' ');
            //    });
            //    Console.WriteLine();
            //}

            //Console.ReadLine();
            //sum di linq
        }
    }
}
