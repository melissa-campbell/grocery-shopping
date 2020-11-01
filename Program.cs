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
                new Food("Egg", 0, 4, 12, "Each"),
                new Food("Spinach", 0, 1, 1, "Pounds"),
                new Food("Tomatoes", 0, 1, 1, "Pounds"),
                new Food("Milk", 2, 6, 8, "Gallons"),
                new Food("Coffee", 5, 0, 4, "Pounds")
            };

            //LINQ feature
            var groceryList =
                from i in pantry
                where i.OnHandQty < i.OrderThreshold
                select i;

            Console.WriteLine("Standard Grocery List");
            //Display list of what to buy and how much to buy to user
            foreach (var v in groceryList)
            {
                Console.WriteLine(v.Name +" - " +v.OrderQty);
            }
        }

        static void ThrowParty()
        {
            int guestCount = int.Parse(DetermineGuestCount());
            string menu = DetermineDinnerMenu();

            if (menu == "Tacos")  // Tacos
            {
                Food[] partyFood = {              
                new Food("Ground Beef", 0, 0, 4, "Ounces"), 
                new Food("Flour Tortillas", 0, 0, 3, "Each" ),
                new Food("Corn Tortillas", 0, 0, 1, "Each" ),
                new Food("Shredded Cheese", 0, 0, 2, "Ounces" ),
                new Food("Hot Sauce", 0, 0, 1, "Ounces" )
                };
            
                foreach (Food f in partyFood)
                {
                    Console.WriteLine(f.Name + " " +f.OrderQty*guestCount+ " "+ f.UnitOfMeasure);
                }
            }
            if (menu == "Pizza") // Pizza
            {
                Food[] partyFood = {              
                new Food("Cheese", 0, 0, 2, "Slices"), 
                new Food("Meat", 0, 0, 1, "Slices" ),
                new Food("Veggie", 0, 0, 1, "Slices" ),
                };

                Console.WriteLine("Party Shopping List");
            
                foreach (Food f in partyFood)
                {
                    Console.WriteLine(f.Name + " " +f.OrderQty*guestCount+ " "+ f.UnitOfMeasure);
                }
            }
        }

        static public string DetermineGuestCount()
        {
            Console.WriteLine("How many guests?");
            string numberGuests = Console.ReadLine();
            Console.WriteLine("You have {0} guests", numberGuests);
            return numberGuests;
        }

        static public string DetermineDinnerMenu()
        {
            Console.WriteLine("What would you like to serve?");
            Console.WriteLine("0 for Tacos");
            Console.WriteLine("1 for Pizza");
            string menu = Console.ReadLine();
            if (menu == "0")
            {
                menu = "Tacos";
            }
            if (menu == "1")
            {
                menu = "Pizza";
            }
            Console.WriteLine("You will be serving {0}", menu);
            return menu;
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
                Console.WriteLine("1 to View Standard Grocery List");
                Console.WriteLine("2 to Throw Party!!!!");

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
                        Console.WriteLine("You entered 1 to View Standard Grocery List");
                        ViewList();
                        Thread.Sleep(1000);
                        break;
                    case "2":
                        //throw party
                        Console.WriteLine("You entered 2 to Throw Party!");
                        ThrowParty();
                        Thread.Sleep(1000);
                        break;
                }
            }
        }
    }
}
