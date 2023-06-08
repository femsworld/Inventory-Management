namespace InventoryManagement
{
    public class Item
    {
        private string _barcode;
        private string _name;
        private int _quantity;

        public string Barcode
        {
            get { return _barcode; }
        }

        public string Name
        {
            get { return _name; }
        }

        public int Quantity
        {
            get { return _quantity; }
        }

        public Item(string barcode, string name, int quantity)
        {
            this._barcode = barcode;
            this._name = name;
            this._quantity = quantity;
        }

        public void IncreaseQuantity(int amount)
        {
            if (amount > 0)
            {
                _quantity += amount;
            }
        }

        public void DecreaseQuantity(int amount)
        {
            if (amount > 0 && _quantity >= amount)
            {
                _quantity -= amount;
            }
        }
    }
}
