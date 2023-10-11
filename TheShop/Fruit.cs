namespace TheShop
{
    internal class Fruit
    {
        //This is the parent class of ShopItem, even though it sounds like it should be the child
        //But this has fewer variables and I didn't know how to remove a variable in the child class so I did it this way.


        //Attributes
        public string item;
        public int cost;
        public int quantity = 1;


        //Constructor
        public Fruit(string item, int cost)
        {
            this.item = item;
            this.cost = cost;
        }


        //Prints which item the customer added to the cart
        public virtual void printAddedItem()
        {
            Console.WriteLine("You added " + quantity + " " + item.ToLower() + " to your shopping cart.");
        }


    }
}

