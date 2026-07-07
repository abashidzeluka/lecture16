using Assignment.Helpers;

namespace Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 2, 3 };

            bool hasEven = Algorithms.CustomAny(numbers, x => x % 2 == 0);
            Console.WriteLine("Has even: " + hasEven);

            bool allPositive = Algorithms.CustomAll(numbers, x => x > 0);
            Console.WriteLine("All positive: " + allPositive);

            int evenCount = Algorithms.CustomCount(numbers, x => x % 2 == 0);
            Console.WriteLine("Even count: " + evenCount);

            var distinct = Algorithms.CustomDistinct(numbers);
            Console.Write("Distinct: ");
            foreach (var item in distinct)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            var evens = Algorithms.CustomWhere(numbers, x => x % 2 == 0);
            Console.Write("Evens: ");
            foreach (var item in evens) Console.Write(item + " ");
            Console.WriteLine();

            int first = Algorithms.CustomFirst(numbers, x => x % 2 == 0);
            Console.WriteLine("First even: " + first);
        
            int firstOrDef = Algorithms.CustomFirstOrDefault(numbers, x => x > 10);
            Console.WriteLine("First > 10: " + firstOrDef); 

            var ordered = Algorithms.CustomOrderBy(numbers, x => x);
            Console.Write("Ordered: ");
            foreach (var item in ordered) Console.Write(item + " ");
            Console.WriteLine();
        }
    }
}