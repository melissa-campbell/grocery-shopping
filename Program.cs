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
                new Food{Name = "Egg", OrderThreshold = 4, OrderQty = 12, UnitOfMeasure = "Each"},
                new Food{Name = "Spinach", OrderThreshold = 1, OrderQty = 1, UnitOfMeasure = "Pounds"},
                new Food{Name = "Tomatoes", OrderThreshold = 4, OrderQty = 8, UnitOfMeasure = "Each"},
                new Food{Name = "Milk", OnHandQty = 2, OrderThreshold = 1, OrderQty = 1, UnitOfMeasure = "Gallons"},
                new Food{Name = "Coffee", OrderThreshold = 4, OrderQty = 12, UnitOfMeasure = "Pounds"},
                new Food{Name = "Potatoes", OnHandQty = 5, OrderThreshold = 1, OrderQty = 1, UnitOfMeasure = "Pounds"}
            };

            //LINQ feature
            var groceryList =
                from i in pantry
                where i.OnHandQty < i.OrderThreshold
                select i;

            SetColor(ConsoleColor.Green);
            Console.WriteLine("Standard Grocery List");
            Console.ResetColor();
            //Display list of what to buy and how much to buy to user
            foreach (var v in groceryList)
            {
                Console.WriteLine(v.Name +" - " +v.OrderQty + " " +v.UnitOfMeasure);
            }
        }

        static void WriteHeader(string menu)
        {
            Console.WriteLine();
            SetColor(ConsoleColor.Green);
            Console.WriteLine("{0} Party Shopping List", menu);
            Console.ResetColor();
        
        }

        static void SetColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        static void ThrowParty()
        {
            int guestCount = int.Parse(DetermineGuestCount());
            string menu = DetermineDinnerMenu();

            if (menu == "Tacos")   
            {
                Food[] partyFood = {              
                new Food{Name = "Ground Beef", OrderQty = 4, UnitOfMeasure = "Ounces"},
                new Food{Name = "Flour Tortillas", OrderQty = 3, UnitOfMeasure = "Each"},
                new Food{Name = "Corn Tortillas", OrderQty = 1, UnitOfMeasure = "Each"},
                new Food{Name = "Shredded Cheese", OrderQty = 2, UnitOfMeasure = "Ounces"},
                new Food{Name = "Hot Sauce", OrderQty = 1, UnitOfMeasure = "Ounces"},
                new Food{Name = "Jalepenos", OrderQty = 1, UnitOfMeasure = "Ounce"}
                };

                WriteHeader("Taco");                
            
                foreach (Food f in partyFood)
                {
                    Console.WriteLine(f.Name + " " +f.OrderQty*guestCount+ " "+ f.UnitOfMeasure);
                }
            }
            if (menu == "Pizza")  
            {
                Food[] partyFood = {      
                new Food{Name = "Cheese", OrderQty = 2, UnitOfMeasure = "Slices"},
                new Food{Name = "Meat", OrderQty = 1, UnitOfMeasure = "Slices"},
                new Food{Name = "Veggie", OrderQty = 1, UnitOfMeasure = "Slices"}
                };

                WriteHeader(menu);

                //Convert 8 slices = 1 pizza.  Add 1 more pizza per flavor for late night.
                foreach (Food f in partyFood)
                {
                    Console.WriteLine(f.Name + " " +((f.OrderQty*guestCount)/8 + 1 )+ " Pizzas");
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
            Console.WriteLine();

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
            SetColor(ConsoleColor.Red);
            Console.WriteLine("Welcome to the Grocery Shopping Assistant!");
            bool keepGoing = true;

            //Master Loop feature
            while ( keepGoing == true)
            {
                Console.WriteLine();
                SetColor(ConsoleColor.Blue);
                Console.WriteLine("What would you like to do?");
                Console.ResetColor();
                Console.WriteLine("0 to Quit");
                Console.WriteLine("1 to View Standard Grocery List");
                Console.WriteLine("2 to Throw Party!!!!");

                string option = Console.ReadLine();
                Console.WriteLine();

                switch (option)
                {
                    case "0":
                        Console.WriteLine("You entered 0 to Quit");
                        keepGoing = false;
                        SetColor(ConsoleColor.Green);
                        Console.WriteLine("Goodbye");
                        Console.ResetColor();
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
