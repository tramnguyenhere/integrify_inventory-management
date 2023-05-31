using Feature;

public class Inventory
{
    private List<Item> _items;
    private int _maxCapacity;

    public List<Item> Items
    {
        get
        {
            return _items;
        }

        set
        {
            _items = value;
        }
    }

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

    private int GetTotalQuantity()
    {
        int totalQuantity = 0;

        foreach (Item item in Items)
        {
            totalQuantity += item.Quantity;
        }
        return totalQuantity;
    }

    private bool CheckUniqueBarcode(string barcode)
    {
        bool isUnique = true;

        foreach (Item item in Items)
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

    public void AddItem(string barcode, string item, int quantity)
    {
        int totalQuantity = GetTotalQuantity();
        bool isItemAvailable = !CheckUniqueBarcode(barcode);

        Item addedItem = new Item(barcode, item, quantity);

        if (totalQuantity + quantity > MaxCapacity)
        {
            throw new Exception("Cannot add item! The inventory reached maximum capacity.");
        }
        else
        {
            if (isItemAvailable)
            {
                int availableItemIndex = Items.FindIndex(Item => Item.Barcode == barcode);
                Items[availableItemIndex] = addedItem;
                Console.WriteLine("Item replaced successfully!");
            }
            else
            {
                Items.Add(addedItem);
                Console.WriteLine("Item added successfully!");
            }
        }
    }

    public void RemoveItem(string barcode)
    {
        bool isItemAvailable = !CheckUniqueBarcode(barcode);

        if (!isItemAvailable)
        {
            throw new Exception("The item is not existed.");
        }
        else
        {
            int deletedItemIndex = Items.FindIndex(Item => Item.Barcode == barcode);
            Items.RemoveAt(deletedItemIndex);
            Console.WriteLine("Item deleted successfully!");
        }
    }
}