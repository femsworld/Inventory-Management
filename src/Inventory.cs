namespace InventoryManagement
{
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
}
