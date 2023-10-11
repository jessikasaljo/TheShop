namespace TheShop
{
    internal class ShopItem : Fruit
    {

        //Added attribute
        public string unit;

        //Changed constructor
        public ShopItem(string item, int cost, string unit) : base(item, cost)
        {
            this.unit = unit;
        }

        //Prints which item the customer added to the cart
        public override void printAddedItem()
        {
            Console.WriteLine("You added " + quantity + " " + unit + " " + item.ToLower() + " to your shopping cart.");
        }

    }
}

