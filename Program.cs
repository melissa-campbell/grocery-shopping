using System;
using System.Collections.Generic;
using System.Linq;

namespace GroceryShopping
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Grocery Shopping Assistant!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("0 to Quit");
            Console.WriteLine("1 to View List");
            Console.WriteLine("2 to Go Shopping!");

            string option = Console.ReadLine();

            switch (option)
            {
                case "0":
                    Console.WriteLine("You entered 0 to Quit");
                    return;
                case "1":
                    //view list
                    Console.WriteLine("You entered 1 to View List");
                    break;
                case "2":
                    //go shopping
                    Console.WriteLine("You entered 2 to Go Shopping!");
                    break;
            }
            
            //check inventory
            //compare on hand vs order thresholds
            //compose list of what is needed

            var pantry = new List<Food>
            {
                new Food("egg", 0, 4, 12),
                new Food("spinach", 0, 1, 1),
                new Food("milk", 2, 6, 8),
                new Food("coffee", 5, 0, 4)
            };

            var groceryList =
                from p in pantry
                where p.OnHandQty < p.OrderThreshold
                select p;

            foreach (var v in groceryList)
            {
                Console.WriteLine(v.Name +" - " +v.OrderQty);
            }

            // pantry[0].OnHandQty = 2;


        }
    }
}
