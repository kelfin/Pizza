using System;
using System.Collections.Generic;
using System.Linq;

namespace Pizza
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"D:\Development\Hashcode\Pizza\Pizza\bin\Debug\netcoreapp3.1\set_input\a_example_1.in");

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
                    {
                        if(cTeams.Where(f => string.Join(" ", f) == string.Join(" ", row)).Count() == 0)
                        {
                            cTeams.Add(row);
                        }
                    }
                });
            }
            //end step2

            //cTeams need to distinct
            //foreach (IEnumerable<int> i in cTeams)
            //    Console.WriteLine(string.Join(" ", i));
            //2
            //3
            //3
            //4
            //2 3
            //2 3

            //foreach (IEnumerable<string> i in pizzaIng)
            //    Console.WriteLine(string.Join(" ", i));
            var cTeamsDistinct = new List<IEnumerable<int>>();

            var pizzaMap = new List<PizzaMap>();
            var id = 0;

            var pizzaList = new List<int>();
            for (int j = 0; j < pizzaIng.Count(); j++)
            {
                pizzaList.Add(j);
            }

            EnumExtension.Combinations(pizzaList, 2).ToList().ForEach(k => {
                id++;
                pizzaMap.Add(new PizzaMap() { ID = id, TeamId = 2, PizzaOption = k }); ;
            });
            EnumExtension.Combinations(pizzaList, 3).ToList().ForEach(k => {
                id++;
                pizzaMap.Add(new PizzaMap() { ID = id, TeamId = 3, PizzaOption = k }); ;
            });
            EnumExtension.Combinations(pizzaList, 4).ToList().ForEach(k => {
                id++;
                pizzaMap.Add(new PizzaMap() { ID = id, TeamId = 4, PizzaOption = k }); ;
            });

            var resultAll = new List<List<string>>();
            foreach (IEnumerable<int> i in cTeams)
            {
                var result = new List<string>();
                if(i.Count() > 0)
                {
                    var currPiza = pizzaMap.Where(f => f.TeamId == i.ToList()[0]).ToList();
                    result.AddRange(currPiza.Select(r => r.ID.ToString()));
                    for (int j = 0; j < i.Count()-1; j++)
                    {
                        var temp = new List<string>();
                        for (var k = 0; k < result.Count(); k++)
                        {
                            var currPizzaID = result[k];
                            var nextPizza = pizzaMap.Where(f => f.TeamId == i.ToList()[j+1]).ToList();
                            for (var l = 0; l < nextPizza.Count(); l++)
                            {
                                var nextPizzaID = nextPizza[l].ID;
                                var strPizza = currPizzaID + " " + nextPizzaID;
                                var arrPizza = strPizza.Split(" ").ToList();

                                if(!checkDuplicate(arrPizza))
                                    temp.Add(strPizza);
                            }
                            Console.WriteLine();
                        }
                        result = temp;

                        Console.WriteLine(string.Join(" ", result));
                        //var asd = pizzaMap.Where(f => f.TeamId == j);
                        //for(var k = 0; k < asd.Count(); k++)
                        //{
                        //    for(var l = 0; l < )
                        //}
                        //EnumExtension.Combinations(pizzaList, j).ToList().ForEach(k =>
                        //{
                        //    id++;
                        //    pizzaMap.Add(new PizzaMap() { ID = id, TeamId = j, PizzaOption = k }); ;
                        //});
                        //foreach (IEnumerable<int> k in test)
                        //{

                        //    Console.WriteLine(string.Join(" ", k));
                        //}
                        //Console.WriteLine("i");
                   }
                }
                resultAll.Add(result);
            }
            var d = RemoveDuplicate(resultAll);

            var e = new List<List<string>>();

            foreach(var a in d)
            {
                foreach(var f in a)
                {
                    var g = f.Split(" ").ToList();
                    var h = 1;
                }
            }


            pizzaMap.ForEach(f =>
            {
                Console.WriteLine("team:"+f.TeamId + ";" + string.Join(" ", f.PizzaOption) + "; id:" + f.ID);
            });

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

        //static IEnumerable<int> forz(IEnumerable<int> r)
        //{
            
        //}

        static List<List<string>> RemoveDuplicate(List<List<string>> data)
        {
            var result = new List<List<string>>();

            foreach(var r in data)
            {
                var arrList = new List<List<string>>();
                foreach(var s in r)
                {
                    var arrs = s.Split(" ").OrderBy(s => Convert.ToInt32(s)).ToList();
                    arrList.Add(arrs);
                }

                var distinct = arrList.Select(s => string.Join(" ", s)).ToList().Distinct().ToList();

                result.Add(distinct);
            }
            return result;
        }
        static bool checkDuplicate(List<string> data)
        {
            for (int i = 0; i < data.Count(); i++)
            {
                for (int j = i + 1; j < data.Count(); j++)
                {
                    if (data[i] == data[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static int Factorial(int number)
        {
            // Declare a temporary variable of type integer
            int temp;
            if (number <= 1) return 1;
            temp = number * Factorial(number - 1);

            return temp;
        }
    }
}
