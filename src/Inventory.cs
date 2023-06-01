using Feature;

class Inventory
{
    private List<Item> _items;
    private int _maxCapacity;

    public int MaxCapacity
    {
        get
        {
            return _maxCapacity;
        }

        set
        {
            if (value <= 0)
            {
                throw new Exception("Invalid value. The maximum capacity must be positive");
            }
            else
            {
                _maxCapacity = value;
            }
        }
    }

    public Item this[int index]
    {
        get
        {
            if (index >= 0 && index < _items.Count)
            {
                return _items[index];
            }
            else
            {
                throw new Exception("Index is out of range.");
            }
        }
    }

    public int GetTotalQuantity()
    {
        int totalQuantity = 0;

        foreach (Item item in _items)
        {
            totalQuantity += item.Quantity;
        }
        return totalQuantity;
    }

    private bool isBarcodeUnique(string barcode)
    {
        bool isUnique = true;

        foreach (Item item in _items)
        {
            if (item.Barcode != barcode)
            {
                isUnique = true;
            }
            else
            {
                return isUnique = false;
            }
        }

        return isUnique;
    }


    public Inventory(int maxCapacity)
    {
        _items = new List<Item>();
        _maxCapacity = maxCapacity;
    }

    public void AddItem(Item item, int quantity)
    {
        int totalQuantity = GetTotalQuantity();
        bool isItemAvailable = !isBarcodeUnique(item.Barcode);

        Item addedItem = new Item(item.Barcode, item.Name, quantity);

        if (totalQuantity + quantity > MaxCapacity)
        {
            throw new Exception("Cannot add item! The inventory reached maximum capacity.");
        }
        else
        {
            if (isItemAvailable)
            {
                int availableItemIndex = _items.FindIndex(Item => Item.Barcode == item.Barcode);
                _items[availableItemIndex] = addedItem;
                Console.WriteLine("Item replaced successfully!");
            }
            else
            {
                _items.Add(addedItem);
                Console.WriteLine("Item added successfully!");
            }
        }
    }

    public void RemoveItem(string barcode)
    {
        bool isItemAvailable = !isBarcodeUnique(barcode);

        if (!isItemAvailable)
        {
            throw new Exception("The item is not existed.");
        }
        else
        {
            int deletedItemIndex = _items.FindIndex(Item => Item.Barcode == barcode);
            _items.RemoveAt(deletedItemIndex);
            Console.WriteLine("Item deleted successfully!");
        }
    }
}