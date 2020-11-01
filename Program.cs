using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GroceryShopping
{
    class Program
    {  
        //check inventory
        //compare on hand vs order thresholds
        //compose list of what is needed
        static public void ViewList()
        {            
            //List<> feature
            var pantry = new List<Food>
            {
                // Food(string name, int onHandQty, int orderThreshold, int orderQty)
                new Food("egg", 0, 4, 12),
                new Food("spinach", 0, 1, 1),
                new Food("milk", 2, 6, 8),
                new Food("coffee", 5, 0, 4)
            };

            //LINQ feature
            var groceryList =
                from i in pantry
                where i.OnHandQty < i.OrderThreshold
                select i;

            //Display list of what to buy and how much to buy to user
            foreach (var v in groceryList)
            {
                Console.WriteLine(v.Name +" - " +v.OrderQty);
            }
        }

          
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Grocery Shopping Assistant!");
            bool keepGoing = true;

            //Master Loop feature
            while ( keepGoing == true)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("0 to Quit");
                Console.WriteLine("1 to View List");
                Console.WriteLine("2 to Add more functionality... hmmmmm!");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "0":
                        Console.WriteLine("You entered 0 to Quit");
                        keepGoing = false;
                        Console.WriteLine("Goodbye");
                        return;
                    case "1":
                        //view list
                        Console.WriteLine("You entered 1 to View List");
                        ViewList();
                        Thread.Sleep(2000);
                        break;
                    case "2":
                        //go shopping
                        Console.WriteLine("You entered 2 to Go Shopping!");
                        //GoShopping();
                        break;
                }
            }
            
            


            


        }
    }
}
