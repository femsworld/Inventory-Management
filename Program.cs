using System;
using System.Collections.Generic;
namespace InventoryManagement
{
public class Item
{
    private string barcode;
    private string name;
    private int quantity;

    public string Barcode
    {
        get { return barcode; }
    }

    public string Name
    {
        get { return name; }
    }

    public int Quantity
    {
        get { return quantity; }
    }

    public Item(string barcode, string name, int quantity)
    {
        this.barcode = barcode;
        this.name = name;
        this.quantity = quantity;
    }

    public void IncreaseQuantity(int amount)
    {
        if (amount > 0)
        {
            quantity += amount;
        }
    }

    public void DecreaseQuantity(int amount)
    {
        if (amount > 0 && quantity >= amount)
        {
            quantity -= amount;
        }
    }
}

public class Inventory
{
    private Dictionary<string, Item> items;
    private int maxCapacity;

    public int MaxCapacity
    {
        get { return maxCapacity; }
    }
    public Dictionary<string, Item> Items
    {
        get { return items; }
    }

    public Inventory(int maxCapacity)
    {
        this.maxCapacity = maxCapacity;
        items = new Dictionary<string, Item>();
    }

    public bool AddItem(Item item, int quantity)
    {
        if (items.Count >= maxCapacity)
        {
            return false;
        }

        if (items.ContainsKey(item.Barcode))
        {
            items[item.Barcode].IncreaseQuantity(quantity);
        }
        else
        {
            item.IncreaseQuantity(quantity);
            items.Add(item.Barcode, item);
        }

        return true;
    }

    public bool RemoveItem(string barcode)
    {
        if (items.ContainsKey(barcode))
        {
            items.Remove(barcode);
            return true;
        }

        return false;
    }

    public void IncreaseQuantity(int amount, string barcode)
    {
        if (items.ContainsKey(barcode))
        {
            items[barcode].IncreaseQuantity(amount);
        }
    }

    public void DecreaseQuantity(int amount, string barcode)
    {
        if (items.ContainsKey(barcode))
        {
            items[barcode].DecreaseQuantity(amount);
        }
    }

    public void ViewInventory()
    {
        foreach (var item in items.Values)
        {
            Console.WriteLine($"Barcode: {item.Barcode}, Name: {item.Name}, Quantity: {item.Quantity}");
        }
    }

    ~Inventory()
    {
        Console.WriteLine("Inventory destroyed.");
    }
}

public class Printer
{
    public void PrintItem(Item item)
    {
        Console.WriteLine($"Name: {item.Name}, Barcode: {item.Barcode}");
    }

    public void PrintInventory(Inventory inventory)
    {
        int uniqueItems = inventory.Items.Count;
        int totalItems = 0;

        foreach (var item in inventory.Items.Values)
        {
            totalItems += item.Quantity;
        }

        Console.WriteLine($"Unique Items: {uniqueItems}, Total Items: {totalItems}");
    }
}

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
