namespace GroceryShopping
{
    class Food{
        public string Name;
        public int OnHandQty;
        public int OrderThreshold;
        public int OrderQty;

        public Food(string name, int onHandQty, int orderThreshold, int orderQty)
        {
            Name = name;
            OnHandQty = onHandQty;
            OrderThreshold = orderThreshold;
            OrderQty = orderQty;
        }

        // public Food(string name, int onHandQty)
        // {
        //     Name = name;
        //     OnHandQty = onHandQty;
        // }
        
    }
}
