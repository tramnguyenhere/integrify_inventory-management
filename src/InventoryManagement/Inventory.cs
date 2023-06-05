using System.Text;
namespace InventoryManagement;

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



    public Inventory(int maxCapacity)
    {
        _items = new List<Item>();
        _maxCapacity = maxCapacity;
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

    public int GetTotalNumberOfItems()
    {
        int totalItems = 0;

        foreach (Item item in _items)
        {
            totalItems += 1;
        }
        return totalItems;
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
                _items[availableItemIndex].Quantity += addedItem.Quantity;
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

    public void IncreaseQuantity(int quantity, string barcode)
    {
        int itemIndex = _items.FindIndex(item => item.Barcode == barcode);

        if (itemIndex >= 0)
        {
            _items[itemIndex].Quantity += quantity;
            Console.WriteLine("The quantity has been updated!");
        }
        else
        {
            throw new Exception("The item cannot be found!");
        }
    }

    public void DecreaseQuantity(int quantity, string barcode)
    {
        int itemIndex = _items.FindIndex(item => item.Barcode == barcode);

        if (itemIndex >= 0 && _items[itemIndex].Quantity > quantity)
        {
            if (_items[itemIndex].Quantity > quantity)
            {
                _items[itemIndex].Quantity -= quantity;
                Console.WriteLine("The quantity has been updated!");
            }
            else
            {
                throw new Exception("The decrease amount cannot be over the actual quantity!");
            }
        }
        else
        {
            throw new Exception("The item cannot be found !");
        }
    }

    public void ViewInventory()
    {
        Console.WriteLine("List of items:\n---");
        foreach (var item in _items)
        {
            Console.WriteLine($"Barcode: {item.Barcode}\nName: {item.Name}\nQuantity: {item.Quantity}\n");
            Console.WriteLine("---");
        }
    }

    ~Inventory()
    {
        Console.WriteLine("Inventory is destroyed.");
    }
}