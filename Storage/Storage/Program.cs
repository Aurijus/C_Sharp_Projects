using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Xml.Linq;

internal class Program
{
    private static void Main(string[] args)
    {
        Network storageNetwork = new Network()
        {
            network = new List<Storage>() { }
        };

        Storage FirstWarehouse = new Storage()
        {
            items = new List<Item>()
    {
        new Item() { Name = "F", Price = 25, Quantity = 4},
        new Item() { Name = "G", Price = 37, Quantity = 5},
        new Item() { Name = "A", Price = 83, Quantity = 2},
        new Item() { Name = "E", Price = 86, Quantity = 10},
    }
        };

        Storage SecondWarehouse = new Storage()
        {
            items = new List<Item>()
    {
        new Item() { Name = "K", Price = 75, Quantity = 78},
        new Item() { Name = "Z", Price = 35, Quantity = 6},
        new Item() { Name = "V", Price = 73, Quantity = 42},
        new Item() { Name = "F", Price = 21, Quantity = 12},
        new Item() { Name = "I", Price = 18, Quantity = 65},
    }
        };


        Storage ThirdhWarehouse = new Storage()
        {
            items = new List<Item>()
    {
        new Item() { Name = "S", Price = 85, Quantity = 4},
        new Item() { Name = "B", Price = 22, Quantity = 6},
        new Item() { Name = "A", Price = 75, Quantity = 8},
    }
        };

        Storage FourthWarehouse = new Storage()
        {
            items = new List<Item>()
    {
        new Item() { Name = "K", Price = 75, Quantity = 78},
        new Item() { Name = "Z", Price = 35, Quantity = 6},
        new Item() { Name = "V", Price = 73, Quantity = 42},
        new Item() { Name = "F", Price = 21, Quantity = 12},
        new Item() { Name = "I", Price = 18, Quantity = 65},
    }
        };

        storageNetwork.AddWarehouse(FirstWarehouse);
        storageNetwork.AddWarehouse(SecondWarehouse);
        storageNetwork.AddWarehouse(ThirdhWarehouse);
        storageNetwork.AddWarehouse(FourthWarehouse);


        //IEnumerable<Item> sortedItems2 = storageNetwork.network.Skip(3).First().SortByQuantity();
        Storage tempStorage = SecondWarehouse;
        tempStorage.GetProductsByPriceRange(10, 20);
        IEnumerable<Item> sorted = SecondWarehouse.SortByName();
        //foreach (Item i in sorted)
        //    Console.WriteLine("{0}: {1} ({2})", i.Name, i.Price, i.Quantity);
        Item? abc = storageNetwork.GetMostExpensiveProduct();
        Console.WriteLine("{0}, {1}, {2}", abc.Name, abc.Price, abc.Quantity);
        /*

        foreach (Item item in FourthWarehouse)
        {
            Console.WriteLine("{0}: {1} ({2})", item.Name, item.Price, item.Quantity);
        }


        IEnumerable<Item> sortedItems = storageNetwork.network.Skip(1).First().SortByName();

        foreach (Item item in sortedItems)
        {
            Console.WriteLine("{0}: {1} ({2})", item.Name, item.Price, item.Quantity);
        }

        IEnumerable<Item> sortedItems1 = storageNetwork.network.First().SortByPrice();
        foreach (Item item in sortedItems1)
        {
            Console.WriteLine("{0}: {1} ({2})", item.Name, item.Price, item.Quantity);
        }


        IEnumerable<Item> sortedItems2 = storageNetwork.network.Skip(1).First().SortByQuantity();
        foreach (Item item in sortedItems2)
        {
            Console.WriteLine("{0}: {1} ({2})", item.Name, item.Price, item.Quantity);
        }
        */

        string? methodChoice = null;
        string? methodClassChoice = null;
        string? storageChoice = null;
        bool breakWhile = true;
        bool selectDone = true;
        Storage? temp = null;
        IEnumerable<Item>? afterMethodStorage = null;
        Item? afterMethodItem = null;
        decimal rangeMinPrice;
        decimal rangeMaxPrice;
        int rangeMinQuantity;
        int rangeMaxQuantity;
        string nameInput;
        decimal? totalValue = null;
        int? totalQuantity = null;

        while (breakWhile)
        {
            Console.WriteLine("Choose which methods to call:" +
"\n\tInput 1 to call out Storage extensions;" +
"\n\tInput 2 to call out Storage extensions;" +
"\n\tInput 'exit' to exit.\n");

            Console.Write("Enter your choice: ");
            methodClassChoice = Console.ReadLine();

            if (methodClassChoice == "1")
            {
                while (methodChoice != "exit")
                {
                    Console.WriteLine("Choose which method to call:" +
            "\n\tInput 1 to call out SortByName;" +
            "\n\tInput 2 to call out SortByPrice;" +
            "\n\tInput 3 to call out SortByQuantity;" +
            "\n\tInput 4 to call out GetCheapestProduct;" +
            "\n\tInput 5 to call out GetMostExpensiveProduct;" +
            "\n\tInput 6 to call out GetProductsByPriceRange;" +
            "\n\tInput 7 to call out GetProductsByQuantity;" +
            "\n\tInput 8 to call out GetProductsByName;" +
            "\n\tInput 9 to call out GetProductsByPriceLessThan;" +
            "\n\tInput 10 to call out GetProductsByPriceGreaterThan;\n");

                    Console.Write("Enter your choice: ");
                    methodChoice = Console.ReadLine();

                    if (methodChoice != "exit")
                    {

                        Console.WriteLine("Select warehouse:" +
                "\n\tInput 1 for First Warehouse;" +
                "\n\tInput 2 for Second Warehouse;" +
                "\n\tInput 3 for Third Warehouse;" +
                "\n\tInput 4 for Fourth Warehouse;\n");

                        Console.Write("Enter your choice: ");
                        storageChoice = Console.ReadLine();

                        if (storageChoice == "1")
                            temp = FirstWarehouse;
                        else if (storageChoice == "2")
                            temp = SecondWarehouse;
                        else if (storageChoice == "3")
                            temp = ThirdhWarehouse;
                        else if (storageChoice == "4")
                            temp = FourthWarehouse;
                        else
                        {
                            Console.WriteLine("Wrong choice.\n");
                            methodChoice = "-2";
                        }
                    }

                    switch (methodChoice)
                    {
                        case "1":
                            Console.WriteLine("You selected SortByName.");
                            afterMethodStorage = temp.SortByName();
                            foreach (Item item in afterMethodStorage)
                                Console.WriteLine("Item name: {0}\n\tPrice: {1}\n\tQuantity: {2}\n", item.Name, item.Price, item.Quantity);
                            break;
                        case "2":
                            Console.WriteLine("You selected SortByPrice.");
                            afterMethodStorage = temp.SortByPrice();
                            foreach (Item item in afterMethodStorage)
                                Console.WriteLine("Item name: {0}\n\tPrice: {1}\n\tQuantity: {2}\n", item.Name, item.Price, item.Quantity);
                            break;
                        case "3":
                            Console.WriteLine("You selected SortByQuantity.");
                            afterMethodStorage = temp.SortByQuantity();
                            foreach (Item item in afterMethodStorage)
                                Console.WriteLine("Item name: {0}\n\tPrice: {1}\n\tQuantity: {2}\n", item.Name, item.Price, item.Quantity);
                            break;
                        case "4":
                            Console.WriteLine("You selected GetCheapestProduct.");
                            afterMethodItem = temp.GetCheapestProduct();
                            Console.WriteLine("Item name: {0}\n\tPrice: {1}\n\tQuantity: {2}\n", afterMethodItem.Name, afterMethodItem.Price, afterMethodItem.Quantity);
                            break;
                        case "5":
                            Console.WriteLine("You selected GetMostExpensiveProduct.");
                            afterMethodItem = temp.GetMostExpensiveProduct();
                            Console.WriteLine("Item name: {0}\n\tPrice: {1}\n\tQuantity: {2}\n", afterMethodItem.Name, afterMethodItem.Price, afterMethodItem.Quantity);
                            break;
                        case "6":
                            Console.WriteLine("You selected GetProductsByPriceRange.");
                            Console.WriteLine("Input minimum price range:\t");
                            rangeMinPrice = Convert.ToDecimal(Console.ReadLine());
                            Console.WriteLine("\nInput maximum price range:\t");
                            rangeMaxPrice = Convert.ToDecimal(Console.ReadLine());
                            afterMethodStorage = temp.GetProductsByPriceRange(rangeMinPrice, rangeMaxPrice);
                            foreach (Item item in afterMethodStorage)
                                Console.WriteLine("Item name: {0}\n\tPrice: {1}\n\tQuantity: {2}\n", item.Name, item.Price, item.Quantity);
                            break;
                        case "7":
                            Console.WriteLine("You selected GetProductsByQuantity");
                            Console.WriteLine("Input minimum quantity range:\t");
                            rangeMinQuantity = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\nInput maximum quantity range:\t");
                            rangeMaxQuantity = Convert.ToInt32(Console.ReadLine());
                            afterMethodStorage = temp.GetProductsByQuantity(rangeMinQuantity, rangeMaxQuantity);
                            foreach (Item item in afterMethodStorage)
                                Console.WriteLine("Item name: {0}\n\tPrice: {1}\n\tQuantity: {2}\n", item.Name, item.Price, item.Quantity);
                            break;
                        case "8":
                            Console.WriteLine("You selected GetProductsByName");
                            Console.WriteLine("Input item name:\t");
                            nameInput = Console.ReadLine();
                            afterMethodStorage = temp.GetProductsByName(nameInput);
                            foreach (Item item in afterMethodStorage)
                                Console.WriteLine("Item name: {0}\n\tPrice: {1}\n\tQuantity: {2}\n", item.Name, item.Price, item.Quantity);
                            break;
                        case "9":
                            Console.WriteLine("You selected GetProductsByPriceLessThan");
                            Console.WriteLine("Input maximum price range:\t");
                            rangeMaxPrice = Convert.ToDecimal(Console.ReadLine());
                            afterMethodStorage = temp.GetProductsByPriceLessThan(rangeMaxPrice);
                            foreach (Item item in afterMethodStorage)
                                Console.WriteLine("Item name: {0}\n\tPrice: {1}\n\tQuantity: {2}\n", item.Name, item.Price, item.Quantity);
                            break;
                        case "10":
                            Console.WriteLine("You selected GetProductsByPriceGreaterThan");
                            Console.WriteLine("\nInput minimum price range:\t");
                            rangeMinPrice = Convert.ToDecimal(Console.ReadLine());
                            afterMethodStorage = temp.GetProductsByPriceGreaterThan(rangeMinPrice);
                            foreach (Item item in afterMethodStorage)
                                Console.WriteLine("Item name: {0}\n\tPrice: {1}\n\tQuantity: {2}\n", item.Name, item.Price, item.Quantity);
                            break;
                        case "exit":
                            Console.WriteLine("Bye bye!");
                            breakWhile = false;
                            break;
                        case "-2":
                            Console.WriteLine("Choose the correct warehouse.");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number from 1 to 10, or 'exit' to quit.");
                            break;
                    }
                }
            }
            else if (methodClassChoice == "2")
            {
                while (methodChoice != "exit")
                {
                    Console.WriteLine("Choose which method to call:" +
            "\n\tInput 1 to call out GetTotalValue;" +
            "\n\tInput 2 to call out GetTotalQuantity;" +
            "\n\tInput 3 to call out GetProductsByWarehouse;" +
            "\n\tInput 4 to call out GetProductsByPriceLessThan;" +
            "\n\tInput 5 to call out GetProductsByPriceGreaterThan;" +
            "\n\tInput 6 to call out GetProductsByQuantity;" +
            "\n\tInput 7 to call out GetProductsByName;" +
            "\n\tInput 8 to call out GetCheapestProduct;" +
            "\n\tInput 9 to call out GetMostExpensiveProduct;" +
            "\n\tInput 10 to call out GetProductsByPriceRange;" +
            "\n\tInput 11 to call out GetProductsByQuantity;" +
            "\n\tInput 12 to call out GetProductsByName;" +
            "\n\tInput 13 to call out GetProductsByPriceLessThan;" +
            "\n\tInput 14 to call out GetProductsByPriceGreaterThan;\n");

                    Console.Write("Enter your choice: ");
                    methodChoice = Console.ReadLine();

                    switch (methodChoice)
                    {
                        case "1":
                            Console.WriteLine("You selected GetTotalValue.\n");
                            totalValue = storageNetwork.network.GetTotalValue();
                            Console.WriteLine("Warehouse network total value: {0}\n", totalValue); 
                            break;
                        case "2":
                            Console.WriteLine("You selected GetTotalQuantity.\n");
                            totalQuantity = storageNetwork.network.GetTotalQuantity();
                            Console.WriteLine("Warehouse network total item quantity: {0}\n", totalQuantity);
                            break;
                        case "3":
                            Console.WriteLine("You selected GetProductsByWarehouse.");
                            selectDone = true;
                            while (selectDone)
                            {
                                Console.WriteLine("Select warehouse:" +
                "\n\tInput 1 for First Warehouse;" +
                "\n\tInput 2 for Second Warehouse;" +
                "\n\tInput 3 for Third Warehouse;" +
                "\n\tInput 4 for Fourth Warehouse;\n");

                            Console.Write("Enter your choice: ");
                            storageChoice = Console.ReadLine();

                                if (storageChoice == "1")
                                {
                                    temp = FirstWarehouse;
                                    selectDone = false;
                                }
                                else if (storageChoice == "2")
                                {
                                    temp = SecondWarehouse;
                                    selectDone = false;
                                }
                                else if (storageChoice == "3")
                                {
                                    temp = ThirdhWarehouse;
                                    selectDone = false;
                                }
                                else if (storageChoice == "4")
                                {
                                    temp = FourthWarehouse;
                                    selectDone = false;
                                }
                                else
                                    Console.WriteLine("Wrong choice.\n");
                            }

                            afterMethodStorage = storageNetwork.network.GetProductsByWarehouse(temp);
                            foreach (Item item in afterMethodStorage)
                                Console.WriteLine("Item name: {0}\n\tPrice: {1}\n\tQuantity: {2}\n", item.Name, item.Price, item.Quantity);
                            break;
                        case "4":
                            Console.WriteLine("You selected GetProductsByPriceLessThan.");
                            Console.WriteLine("\nInput maximum price range:\t");
                            rangeMaxPrice = Convert.ToDecimal(Console.ReadLine());
                            selectDone = true;
                            while (selectDone)
                            {
                                Console.WriteLine("Select warehouse:" +
                "\n\tInput 1 for First Warehouse;" +
                "\n\tInput 2 for Second Warehouse;" +
                "\n\tInput 3 for Third Warehouse;" +
                "\n\tInput 4 for Fourth Warehouse;\n");

                                Console.Write("Enter your choice: ");
                                storageChoice = Console.ReadLine();

                                if (storageChoice == "1")
                                {
                                    temp = FirstWarehouse;
                                    selectDone = false;
                                }
                                else if (storageChoice == "2")
                                {
                                    temp = SecondWarehouse;
                                    selectDone = false;
                                }
                                else if (storageChoice == "3")
                                {
                                    temp = ThirdhWarehouse;
                                    selectDone = false;
                                }
                                else if (storageChoice == "4")
                                {
                                    temp = FourthWarehouse;
                                    selectDone = false;
                                }
                                else
                                    Console.WriteLine("Wrong choice.\n");
                            }
                            afterMethodStorage = storageNetwork.network.GetProductsByPriceLessThan(rangeMaxPrice, temp);
                            foreach (Item item in afterMethodStorage)
                                Console.WriteLine("Item name: {0}\n\tPrice: {1}\n\tQuantity: {2}\n", item.Name, item.Price, item.Quantity);
                            break;
                        case "5":
                            Console.WriteLine("You selected GetProductsByPriceGreaterThan.");
                            Console.WriteLine("\nInput minimum price range:\t");
                            rangeMinPrice = Convert.ToDecimal(Console.ReadLine());
                            selectDone = true;
                            while (selectDone)
                            {
                                Console.WriteLine("Select warehouse:" +
                "\n\tInput 1 for First Warehouse;" +
                "\n\tInput 2 for Second Warehouse;" +
                "\n\tInput 3 for Third Warehouse;" +
                "\n\tInput 4 for Fourth Warehouse;\n");

                                Console.Write("Enter your choice: ");
                                storageChoice = Console.ReadLine();

                                if (storageChoice == "1")
                                {
                                    temp = FirstWarehouse;
                                    selectDone = false;
                                }
                                else if (storageChoice == "2")
                                {
                                    temp = SecondWarehouse;
                                    selectDone = false;
                                }
                                else if (storageChoice == "3")
                                {
                                    temp = ThirdhWarehouse;
                                    selectDone = false;
                                }
                                else if (storageChoice == "4")
                                {
                                    temp = FourthWarehouse;
                                    selectDone = false;
                                }
                                else
                                    Console.WriteLine("Wrong choice.\n");
                            }
                            afterMethodStorage = storageNetwork.network.GetProductsByPriceGreaterThan(rangeMinPrice, temp);
                            foreach (Item item in afterMethodStorage)
                                Console.WriteLine("Item name: {0}\n\tPrice: {1}\n\tQuantity: {2}\n", item.Name, item.Price, item.Quantity);
                            break;
                        case "6":
                            Console.WriteLine("You selected GetProductsByQuantity.");
                            Console.WriteLine("Input item quantity:\t");
                            rangeMinQuantity = Convert.ToInt32(Console.ReadLine());

                            selectDone = true;
                            while (selectDone)
                            {
                                Console.WriteLine("Select warehouse:" +
                "\n\tInput 1 for First Warehouse;" +
                "\n\tInput 2 for Second Warehouse;" +
                "\n\tInput 3 for Third Warehouse;" +
                "\n\tInput 4 for Fourth Warehouse;\n");

                                Console.Write("Enter your choice: ");
                                storageChoice = Console.ReadLine();

                                if (storageChoice == "1")
                                {
                                    temp = FirstWarehouse;
                                    selectDone = false;
                                }
                                else if (storageChoice == "2")
                                {
                                    temp = SecondWarehouse;
                                    selectDone = false;
                                }
                                else if (storageChoice == "3")
                                {
                                    temp = ThirdhWarehouse;
                                    selectDone = false;
                                }
                                else if (storageChoice == "4")
                                {
                                    temp = FourthWarehouse;
                                    selectDone = false;
                                }
                                else
                                    Console.WriteLine("Wrong choice.\n");
                            }

                            afterMethodStorage = storageNetwork.network.GetProductsByQuantity(rangeMinQuantity, temp);
                            foreach (Item item in afterMethodStorage)
                                Console.WriteLine("Item name: {0}\n\tPrice: {1}\n\tQuantity: {2}\n", item.Name, item.Price, item.Quantity);
                            break;
                        case "7":
                            Console.WriteLine("You selected GetProductsByName.");
                            Console.WriteLine("Input item name:\t");
                            nameInput = Console.ReadLine();

                            selectDone = true;
                            while (selectDone)
                            {
                                Console.WriteLine("Select warehouse:" +
                "\n\tInput 1 for First Warehouse;" +
                "\n\tInput 2 for Second Warehouse;" +
                "\n\tInput 3 for Third Warehouse;" +
                "\n\tInput 4 for Fourth Warehouse;\n");

                                Console.Write("Enter your choice: ");
                                storageChoice = Console.ReadLine();

                                if (storageChoice == "1")
                                {
                                    temp = FirstWarehouse;
                                    selectDone = false;
                                }
                                else if (storageChoice == "2")
                                {
                                    temp = SecondWarehouse;
                                    selectDone = false;
                                }
                                else if (storageChoice == "3")
                                {
                                    temp = ThirdhWarehouse;
                                    selectDone = false;
                                }
                                else if (storageChoice == "4")
                                {
                                    temp = FourthWarehouse;
                                    selectDone = false;
                                }
                                else
                                    Console.WriteLine("Wrong choice.\n");
                            }

                            afterMethodStorage = storageNetwork.network.GetProductsByName(nameInput, temp);
                            foreach (Item item in afterMethodStorage)
                                Console.WriteLine("Item name: {0}\n\tPrice: {1}\n\tQuantity: {2}\n", item.Name, item.Price, item.Quantity);
                            break;
                        case "8":
                            Console.WriteLine("You selected GetCheapestProduct.");
                            afterMethodItem = storageNetwork.GetCheapestProduct();
                            Console.WriteLine("Item name: {0}\n\tPrice: {1}\n\tQuantity: {2}\n", afterMethodItem.Name, afterMethodItem.Price, afterMethodItem.Quantity);
                            break;
                        case "9":
                            Console.WriteLine("You selected GetMostExpensiveProduct.");
                            afterMethodItem = storageNetwork.GetMostExpensiveProduct();
                            Console.WriteLine("Item name: {0}\n\tPrice: {1}\n\tQuantity: {2}\n", afterMethodItem.Name, afterMethodItem.Price, afterMethodItem.Quantity);
                            break;
                        case "10":
                            Console.WriteLine("You selected GetProductsByPriceRange.");
                            Console.WriteLine("Input minimum price range:\t");
                            rangeMinPrice = Convert.ToDecimal(Console.ReadLine());
                            Console.WriteLine("\nInput maximum price range:\t");
                            rangeMaxPrice = Convert.ToDecimal(Console.ReadLine());
                            afterMethodStorage = storageNetwork.network.GetProductsByPriceRange(rangeMinPrice, rangeMaxPrice);
                            foreach (Item item in afterMethodStorage)
                                Console.WriteLine("Item name: {0}\n\tPrice: {1}\n\tQuantity: {2}\n", item.Name, item.Price, item.Quantity);
                            break;
                        case "11":
                            Console.WriteLine("You selected GetProductsByQuantity.");
                            Console.WriteLine("Input minimum quantity range:\t");
                            rangeMinQuantity = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("\nInput maximum quantity range:\t");
                            rangeMaxQuantity = Convert.ToInt32(Console.ReadLine());
                            afterMethodStorage = storageNetwork.network.GetProductsByQuantity(rangeMinQuantity, rangeMaxQuantity);
                            foreach (Item item in afterMethodStorage)
                                Console.WriteLine("Item name: {0}\n\tPrice: {1}\n\tQuantity: {2}\n", item.Name, item.Price, item.Quantity);
                            break;
                        case "12":
                            Console.WriteLine("You selected GetProductsByName.");
                            Console.WriteLine("Input item name:\t");
                            nameInput = Console.ReadLine();
                            afterMethodStorage = storageNetwork.network.GetProductsByName(nameInput);
                            foreach (Item item in afterMethodStorage)
                                Console.WriteLine("Item name: {0}\n\tPrice: {1}\n\tQuantity: {2}\n", item.Name, item.Price, item.Quantity);
                            break;
                        case "13":
                            Console.WriteLine("You selected GetProductsByPriceLessThan.");
                            Console.WriteLine("Input maximum price range:\t");
                            rangeMaxPrice = Convert.ToDecimal(Console.ReadLine());
                            afterMethodStorage = storageNetwork.network.GetProductsByPriceLessThan(rangeMaxPrice);
                            foreach (Item item in afterMethodStorage)
                                Console.WriteLine("Item name: {0}\n\tPrice: {1}\n\tQuantity: {2}\n", item.Name, item.Price, item.Quantity);
                            break;
                        case "14":
                            Console.WriteLine("You selected GetProductsByPriceGreaterThan.");
                            Console.WriteLine("Input minimum price range:\t");
                            rangeMinPrice = Convert.ToDecimal(Console.ReadLine());
                            afterMethodStorage = storageNetwork.network.GetProductsByPriceGreaterThan(rangeMinPrice);
                            foreach (Item item in afterMethodStorage)
                                Console.WriteLine("Item name: {0}\n\tPrice: {1}\n\tQuantity: {2}\n", item.Name, item.Price, item.Quantity);
                            break;
                        case "exit":
                            Console.WriteLine("Bye bye!");
                            breakWhile = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number from 1 to 10, or 'exit' to quit.");
                            break;
                    }
                }
            }
            else if (methodClassChoice == "exit")
            {
                Console.WriteLine("Bye Bye!");
                breakWhile = false;
            }
            else
            {
                Console.WriteLine("Wrong choice.");
            }
        }


    }
}