using System;

namespace ImmutableObjects
{
    internal static class Program
    {
        private static bool IsHappyHour { get; set; }


        // Reference types are susceptible to aliasing bugs;
        // By changing contents of an existing object we are risking an aliasing bug to apear;
        // Try to avoid instantiating objects directly;
        // Modification to the constructor requires update in all consumers;
        // Let objects of the class construct subsequent objects;
        private static MoneyAmount Reserve(MoneyAmount cost)
        {
            decimal factor = 1;
            var newCost = cost;

            if (IsHappyHour)
            {
                // Create new object when content should change;
                factor = .5M;
            }

            Console.WriteLine($"\nReserving an item that costs {cost}");
            return cost.Scale(factor);
        }

        private static void Buy(MoneyAmount wallet, MoneyAmount cost)
        {
            var enoughMoney = wallet.Amount >= cost.Amount;

            var finalCost = Reserve(cost);

            var finalEnough = wallet.Amount >= finalCost.Amount;

            if (enoughMoney && finalEnough)
                Console.WriteLine($"You will pay {cost} with your {wallet}.");
            else if (finalEnough)
                Console.WriteLine($"This time, {wallet} will be enough to pay {finalCost}");
            else
                Console.WriteLine($"You cannot pay {cost} with your {wallet}.");
        }

        private static void Main()
        {
            //Buy(
            //    new MoneyAmount(100, "USD"),
            //    new MoneyAmount(70, "USD")
            //);

            //IsHappyHour = true;
            //Buy(
            //    new MoneyAmount(100, "USD"),
            //    new MoneyAmount(120, "USD")
            //);

            var x = new MoneyAmount(5, "USD");
            var y = new MoneyAmount(5, "USD");

            if (x == y)
                Console.WriteLine("Equal.");
            if ((x * 2) == y)
                Console.WriteLine("Equal after scaling.");

            //var x = 2;
            //var y = 2;

            //var set = new HashSet<MoneyAmount>();

            //set.Add(x);

            //if (set.Contains(y))
            //    Console.WriteLine("Cannot add repeated value.");
            //else
            //    set.Add(y);


            //Console.WriteLine($"Count = {set.Count}");
        }
    }
}