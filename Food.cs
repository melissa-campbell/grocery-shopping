namespace GroceryShopping
{
    class Food{

        public Food(string name, int onHandQty, int orderThreshold, int orderQty)
        {
            Name = name;
            OnHandQty = onHandQty;
            OrderThreshold = orderThreshold;
            OrderQty = orderQty;
        }

        public string Name {get; set;}
        public int OnHandQty {get; set;}
        public int OrderThreshold { get; set; }
        public int OrderQty {get; set;}
  
        
    }
}
