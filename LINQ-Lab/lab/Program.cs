
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using static lab.ListGenerators;
using static System.Net.Mime.MediaTypeNames;

namespace lab
{
    internal class Program
    {
        //public class CaseInsensitiveComparer : IComparer<string>
        //{
        //    public int Compare(string x, string y)
        //    {
        //        return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
        //    }
        //}
        public class CaseInsensitiveComparer : IEqualityComparer<string>, IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
            }
            public bool Equals(string x, string y)
            {
                return getCanonicalString(x) == getCanonicalString(y);
            }

            public int GetHashCode(string obj)
            {
                return getCanonicalString(obj).GetHashCode();
            }

            private string getCanonicalString(string word)
            {
                char[] wordChars = word.ToCharArray();
                Array.Sort<char>(wordChars);
                return new string(wordChars);
            }
        }
        static void Main(string[] args)
        {
            //Restriction Operators

            //1
            //var result1 = ProductList.FindAll(x => x.UnitsInStock == 0);

            //2
            //var result2 = ProductList.FindAll(x => x.UnitPrice > 3 && x.UnitsInStock == 0);

            //3
            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //var Digits = Arr.Where((digit, i) => Arr[i].Length < i);
            //foreach (var item in Digits)
            //{
            //    Console.WriteLine(item);
            //}

            //-------------------------------------------------------------//
            //Element Operators

            //1
            //var r = ProductList.First(x => x.UnitsInStock == 0);

            //2
            //var r = ProductList.FirstOrDefault(x => x.UnitPrice > 1000);

            //3
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var r = Arr.Where(number => number > 5).OrderBy(x => x).Skip(1).FirstOrDefault();    // Print : 7
            //Console.WriteLine(r);

            //-------------------------------------------------------------//

            //Set Operators

            //1
            // var r = ProductList.Select(x => x.Category).Distinct();

            //2
            //char[] r1 = ProductList.Select(x => x.ProductName[0]).ToArray();
            //char[] r2 = CustomerList.Select(x => x.CompanyName[0]).ToArray();
            //var r3 = r1.Union(r2);
            //foreach (var item in r3)
            //{
            //    Console.WriteLine(item);
            //}

            //3
            //char[] r1 = ProductList.Select(x => x.ProductName[0]).ToArray();
            //char[] r2 = CustomerList.Select(x => x.CompanyName[0]).ToArray();
            //var r3 = r1.Intersect(r2);
            //foreach (var item in r3)
            //{
            //    Console.WriteLine(item);
            //}

            //4
            //char[] r1 = ProductList.Select(x => x.ProductName[0]).ToArray();
            //char[] r2 = CustomerList.Select(x => x.CompanyName[0]).ToArray();
            //var r3 = r1.Except(r2);
            //foreach (var item in r3)
            //{
            //    Console.WriteLine(item);
            //}

            //5
            //string[] r1 = ProductList.Select((x, i) => x.ProductName.Substring(x.ProductName.Length - 3)).ToArray();
            //string[] r2 = CustomerList.Select((x, i) => x.CompanyName.Substring(x.CompanyName.Length - 3)).ToArray();
            //var r3 = r1.Concat(r2);
            //foreach (var item in r3)
            //{
            //    Console.WriteLine(item);
            //}

            //----------------------------------------------------------//
            //Aggregate Operators

            //1
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var r = Arr.Where(x => x % 2 != 0).Count();
            //Console.WriteLine(r);

            //2
            //var r = from customer in CustomerList
            //        group customer by customer.Orders.Count();
            //foreach (var item in r)
            //{
            //    Console.WriteLine(item.Key);
            //    foreach (var i in item)
            //    {
            //        Console.WriteLine(i);
            //    }
            //}

            //3
            //var r = from product in ProductList
            //        group product by product.Category.Count();
            //foreach (var item in r)
            //{
            //    Console.WriteLine(item.Key);
            //    foreach (var i in item)
            //    {
            //        Console.WriteLine(i);
            //    }
            //}


            //4
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var r = Arr.Sum();
            //Console.WriteLine(r);

            string readfile = "dictionary_english.txt";
            var file = File.ReadAllLines(readfile).ToList();

            //5
            //var r = file.Select((t, i) => file[i].ToCharArray()).Count();
            //Console.WriteLine(r);

            //6
            //var r = ProductList.GroupBy(p => p.Category)
            //.Select(g => new { Category = g.Key, UnitsInStock = g.Sum(p => p.UnitsInStock) });
            //foreach (var item in r)
            //{

            //    Console.WriteLine(item);
            //}

            //7
            //string[] arr = file.ToArray();                                       //dictionary
            //var r = arr.OrderBy(x => x.Length).FirstOrDefault();
            //Console.WriteLine(r.Length);


            //8
            //var r = ProductList.GroupBy(x => x.Category).
            //    Select(g => new { Category = g.Key, UnitPrice = g.OrderBy(p => p.UnitPrice).FirstOrDefault() });
            //foreach (var item in r)
            //{

            //    Console.WriteLine(item);
            //}

            //9

            //var r =
            //from prod in ProductList
            //group prod by prod.Category into g
            //let cheapPrice = g.Min(p => p.UnitPrice)
            //select new { Category = g.Key, Cheapest = g.Where(a => a.UnitPrice == cheapPrice).FirstOrDefault() };

            //foreach (var item in r)
            //{

            //    Console.WriteLine(item);
            //}


            //10
            //string[] arr = file.ToArray();                                       //dictionary
            //var r = arr.OrderByDescending(x => x.Length).FirstOrDefault();
            //Console.WriteLine(r.Length);


            //11
            //var r = ProductList.GroupBy(p => p.Category)
            //.Select(g => new { Category = g.Key, UnitPrice = g.OrderByDescending(p => p.UnitPrice).FirstOrDefault() });
            //foreach (var item in r)
            //{

            //    Console.WriteLine(item);
            //}

            //12
            //var r = ProductList.GroupBy(p => p.Category)
            //.Select(g => new { Category = g.Key, UnitPrice = g.OrderByDescending(p => p.UnitPrice).FirstOrDefault() });
            //foreach (var item in r)
            //{

            //    Console.WriteLine(item);
            //}

            //13
            //string[] arr = file.ToArray();                                       //dictionary
            //var r = arr.Average(p=>p.Length);
            //Console.WriteLine(r);


            //14
            //var r = ProductList.GroupBy(p => p.Category)
            //.Select(g => new { Category = g.Key, UnitPrice = g.Average(p => p.UnitPrice) });

            //----------------------------------------------------------//
            //Ordering Operators

            //1
            //var r = from product in ProductList
            //        orderby product.ProductName
            //        select new { product.ProductName};


            //2
            string[] Arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            var r = Arr.OrderBy(a => a, new CaseInsensitiveComparer());


            //3
            //var r = ProductList.OrderByDescending(x => x.UnitsInStock);

            //4
            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            //var r = Arr.OrderBy(x => x.Length).ThenBy(x => x);

            //5

            //string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var r =
            //words.OrderBy(a => a.Length)
            // .ThenBy(a => a, new CaseInsensitiveComparer());

            //6
            //var r = ProductList.OrderBy(x => x.Category).ThenByDescending(x => x.UnitPrice);

            //7
            //string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            //var r =
            //words.OrderBy(a => a.Length)
            // .ThenByDescending(a => a, new CaseInsensitiveComparer());

            //8
            //string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            //var r = Arr.Where(x => x[1] == 'i').Reverse();

            //-----------------------------------------------------------//
            //Partitioning Operators

            //1
            //var r = CustomerList.Where(x => x.Country == "Washington").Take(3);

            //2
            //var r = CustomerList.Where(x => x.Country == "Washington").Skip(2);

            //3
            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var r = numbers.TakeWhile((x, i) => x > i);

            //4
            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var r = numbers.SkipWhile(x => x % 3 != 0);

            //5
            //int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            //var r = numbers.SkipWhile((x, i) => x > i);

            //---------------------------------------------------------------------//

            //Projection Operators

            //1
            //var r = ProductList.Select(x => x.ProductName);

            //2
            //string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            //var r = words.Select(x => new { uppercase = x.ToUpper(), lowercase = x.ToLower() });

            //3
            //var r = ProductList.Select(x => new { ProductID = x.ProductID, ProductName = x.ProductName, Price = x.UnitPrice });

            //4
            //int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };////solve again

            //int count = 0;
            //foreach (var item in Arr)
            //{
            //    Console.WriteLine(item == count++);
            //}
            //var r = from num in Arr select new { num = num,inplace= num == count++ };


            //5
            //int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            //int[] numbersB = { 1, 3, 5, 7, 8 };

            //var r = from a in numbersA
            //        from b in numbersB
            //        where a < b
            //        select new { a, b };


            //foreach (var item in r)
            //{
            //    Console.WriteLine($"{item.a} less than {item.b}");
            //}


            //6
            //var r1 = CustomerList.SelectMany(x => x.Orders).Where(t=>t.Total<500);   //1

            //var r2 = from s in CustomerList                 //Another
            //            from f in s.Orders
            //            where f.Total < 500
            //            select f;

            //foreach (var item in r2)
            //{
            //        Console.WriteLine(item);
            //}


            //7
            //DateTime dt2 = new DateTime(1998, 1, 1);
            //var r = from a in CustomerList
            //        from b in a.Orders
            //        where b.OrderDate > dt2
            //        select b.OrderDate;

            //foreach (var item in r)
            //{
            //    Console.WriteLine(item);
            //}

            //-----------------------------------------------------------------//
            //Quantifiers

            //1

            //string[] arr = file.ToArray();                                       //dictionary
            //var r = arr.Any(x => x.Contains("ei"));
            //Console.WriteLine(r);


            //2

            //var r = ProductList.GroupBy(p => p.Category).Where(x => x.Any(x => x.UnitsInStock == 0));    //1

            //foreach (var item in r)
            //{
            //    Console.WriteLine(item.Key);
            //    foreach (var i in item)
            //    {
            //        Console.WriteLine(i);
            //    }
            //}


            //3
            //var r = ProductList.GroupBy(p => p.Category).Where(x => x.All(x => x.UnitsInStock != 0));
            //foreach (var item in r)
            //{
            //    Console.WriteLine(item.Key);
            //    foreach (var i in item)
            //    {
            //        Console.WriteLine(i);
            //    }
            //}

            //----------------------------------------------------------//
            //Grouping Operators

            //1

            //int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };

            //var r =
            //    from n in numbers
            //    group n by n % 5 into g
            //    select new { Remainder = g.Key, Numbers = g };

            //foreach (var g in r)
            //{
            //    Console.WriteLine("Numbers with a remainder of {0} when divided by 5:", g.Remainder);
            //    foreach (var n in g.Numbers)
            //    {
            //        Console.WriteLine(n);
            //    }
            //}

            //Uses group by to partition a list of words by their first letter.
            //Use dictionary_english.txt for Input

            //2
            //string[] arr = file.ToArray();
            //var result = arr.GroupBy(x => x[0]);
            //foreach (var item in result)
            //{
            //    Console.WriteLine($"Character: {item.Key}");
            //    foreach (var i in item)
            //    {
            //        Console.WriteLine(i);
            //    }
            //}

            //3
            //string[] Arr = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };

            //var result = Arr.GroupBy(w => w.Trim(),
            //        a => a.ToLower(),
            //        new CaseInsensitiveComparer());

            //foreach (var item in result)
            //{
            //    Console.WriteLine($"Word: {item.Key}");
            //    foreach (var i in item)
            //    {
            //        Console.WriteLine(i);
            //    }
            //    Console.WriteLine("----------------------");
            //}
        }
    }
}