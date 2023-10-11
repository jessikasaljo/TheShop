namespace TheShop
{
    internal class ShopProgram
    {

        //Creates new objects from the ShopItem & Fruit class
        Fruit apple = new Fruit("APPLE", 7);
        Fruit banana = new Fruit("BANANA", 8);
        ShopItem milk = new ShopItem("MILK", 16, "carton of");
        ShopItem butter = new ShopItem("BUTTER", 48, "packet of");
        ShopItem catfood = new ShopItem("CATFOOD", 24, "can of");
        ShopItem rice = new ShopItem("RICE", 30, "bag of");
        ShopItem soap = new ShopItem("SOAP", 19, "bar of");
        ShopItem bread = new ShopItem("BREAD", 35, "loaf of");


        //Creates a list from the Fruit class, function adds the objects to the list
        List<Fruit> ItemList = new List<Fruit>();
        public void ItemsToItemList()
        {
            ItemList.Add(apple);
            ItemList.Add(banana);
            ItemList.Add(milk);
            ItemList.Add(butter);
            ItemList.Add(catfood);
            ItemList.Add(rice);
            ItemList.Add(soap);
            ItemList.Add(bread);
        }


        //Creates a lists which contains the customer's cart. Objects will be added later by customer
        List<Fruit> ShoppingCart = new List<Fruit>();


        //Declares variables used in Run()
        int budget;
        int originalBudget;
        double totalCost = 0;
        string useDiscount;


        //Function that calls the printAddedItem function from the fruit class, without having to specify for which object so it works in the loop
        public void PrintAddedItem(Fruit fruit)
        {
            fruit.printAddedItem();
        }


        //Function to print shopping cart
        public void printShoppingCart()
        {
            Console.Clear();
            Console.WriteLine("\nYour shopping cart contains:");

            foreach (Fruit _item in ShoppingCart)
            {
                if (_item is ShopItem)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("\t" + _item.quantity + " " + _item.item.ToLower());
                }
            }
            foreach (ShopItem _item in ShoppingCart.OfType<ShopItem>())
            {
                Console.WriteLine("\t" + _item.quantity + " " + _item.unit + " " + _item.item.ToLower());
            }

            Console.WriteLine("for a total of " + totalCost + " kr\n\nYou have an option to use a discount coupon to get 20% off today. Enter 'YES' if you would like to use the coupon, or enter anything else if you do not want to use the coupon.");
            useDiscount = Console.ReadLine().ToUpper();
        }


        //Function for discount code
        public void discountCode()
        {
            if (useDiscount == "YES")
            {
                totalCost = Math.Round(totalCost * 0.8, 1);
                Console.Write("\nYou used the discount coupon! Your new total is " + totalCost + " kr. ");
            }
            else
            {
                Console.Write("Your total amount remains " + totalCost + " kr. ");
            }
        }


        //Function to end shopping
        public void endShopping()
        {
            Console.WriteLine("This leaves you with " + (originalBudget - Math.Round(totalCost)) + " kr after paying.\nThank you for shopping with us today! Press 'Enter' to exit The Shop.");
        }


        //Program logic
        public void Run()
        {
            Console.WriteLine("Welcome to The Shop! We offer the following items (the item names are written in capital letters):");


            //Loops through ItemList printing the prices
            foreach (Fruit _item in ItemList)
            {
                if (_item is ShopItem)
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("\t" + _item.quantity + " " + _item.item + " " + _item.cost + " kr");
                }

            }
            foreach (ShopItem _item in ItemList.OfType<ShopItem>())
            {
                Console.WriteLine("\t" + _item.quantity + " " + _item.unit + " " + _item.item + " " + _item.cost + " kr");
            }


            //Adds value to budget and catches invalid input
            Console.WriteLine("\nHow many SEK can you shop for today?");


            while (true)
            {
                try
                {
                    budget = int.Parse(Console.ReadLine());
                    originalBudget = budget;
                    break;
                }
                catch
                {
                    Console.WriteLine("Invalid input. Please enter a valid number (no letters).");
                }
            }


            //Code that makes the customer leave the store if their budget is lower than the cheapest item, which costs 7 kr
            if (budget >= 7)
            {
                Console.WriteLine("\nGreat! Your budget allows you to shop for " + budget + " kr today.");
            }
            else
            {
                Console.WriteLine("\nYou can't afford to buy anything. Leave our shop immediately, you abonimable peasant. Press 'Enter' to exit.");
                Console.ReadLine();
                return;
            }


            //Declares variables used in the coming loops
            string input;
            bool firstLoop = true;


            // Allows the customer to add items to their shopping cart
            while (budget >= 7)
            {
                bool itemFound = false; //Resets at the beginning of each iteration, so unvalid input can still be caught after user has added an item to their shopping cart
                switch (firstLoop)
                {
                    case true:
                        Console.WriteLine("What would you like to buy? Please enter an item name.");
                        firstLoop = false;
                        break;
                    case false:
                        Console.WriteLine("\nWould you like to buy anything else? Enter another item name or, if you're finished shopping, enter 'DONE'.");
                        break;
                }

                //Reads user's input
                input = Console.ReadLine().ToUpper();


                //Output after the customer has chosen an item to add to their cart
                for (int i = 0; i < ItemList.Count; i++)
                {
                    if (input == ItemList[i].item && budget >= ItemList[i].cost)
                    {
                        PrintAddedItem(ItemList[i]);
                        ShoppingCart.Add(ItemList[i]);
                        budget = budget - ItemList[i].cost;
                        totalCost = totalCost + ItemList[i].cost;
                        itemFound = true;
                    }
                    else if (input == ItemList[i].item && budget < ItemList[i].cost)
                    {
                        Console.WriteLine("You cannot afford this item today. Choose another item.");
                        itemFound = true;
                    }
                }


                //Breaks the while-loop if the customer is finished shopping. Catches invalid input
                if (input == "DONE" && ShoppingCart.Count > 0)
                {
                    printShoppingCart();
                    discountCode();
                    endShopping();
                    break;
                }
                else if (input == "DONE" && ShoppingCart.Count <= 0) //This condition shouldn't be met as the customer doesn't know about the option "done" after adding at least one item to their cart, but just in case
                {
                    Console.Clear();
                    Console.WriteLine("\nYou didn't buy anything today, but we thank you for visiting us anyway. Press 'Enter' to exit The Shop.");
                    break;
                }
                else if (itemFound == false && input != "DONE")
                {
                    Console.WriteLine("Unvalid item. Please enter one of the shop's listed items.");
                }
            }


            //If the customer's budget has reduced so they can't afford anything else
            if (budget < 7)
            {
                Console.WriteLine("\nYou don't have enough money left to buy anything else and can't add any more items. Press 'Enter' to view your shopping cart.");
                Console.ReadLine();
                printShoppingCart();
                discountCode();
                endShopping();
            }


            //Waits for the customer to exit the program by pressing a key
            Console.ReadLine();


        }
    }
}

