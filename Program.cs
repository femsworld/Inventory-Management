namespace InventoryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Item item1 = new Item("123", "Item 1", 5);
            Item item2 = new Item("456", "Item 2", 10);
            Item item3 = new Item("789", "Item 3", 2);

            Inventory inventory = new Inventory(10);
            inventory.AddItem(item1, 5);
            inventory.AddItem(item2, 8);
            inventory.AddItem(item3, 2);

            inventory.ViewInventory();

            inventory.IncreaseQuantity(3, "123");
            inventory.DecreaseQuantity(2, "456");

            Printer printer = new Printer();
            printer.PrintItem(item1);
            printer.PrintInventory(inventory);

            inventory.RemoveItem("123");

            inventory.ViewInventory();

            inventory.AddItem(item2, 5);
            inventory.AddItem(item3, 4);

            inventory.ViewInventory();

            inventory.AddItem(new Item("101", "Item 4", 3), 3);
            inventory.AddItem(new Item("202", "Item 5", 6), 6);

            inventory.ViewInventory();

            inventory.AddItem(new Item("303", "Item 6", 2), 2); // This will exceed the max capacity and not be added

            Console.ReadLine();
        }
    }
}
