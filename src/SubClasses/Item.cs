namespace Inventory;

class Item
{
    private string _barcode;
    private string _name;
    private int _quantity;

    public string Barcode
    {
        get
        {
            return _barcode;
        }
        set
        {
            if (value.Length == 0)
            {
                throw new Exception("Barcode cannot be empty!");
            }
            else
            {
                _barcode = value;
            }
        }
    }

    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            if (value.Length == 0)
            {
                throw new Exception("Name cannot be empty!");
            }
            else
            {
                _name = value;
            }
        }
    }

    public int Quantity
    {
        get
        {
            return _quantity;
        }
        set
        {
            if (value < 0)
            {
                throw new Exception("Quantity cannot be negative!");
            }
            else
            {
                _quantity = value;
            }
        }
    }

    public Item(string barcode, string name, int quantity)
    {
        _barcode = barcode;
        _name = name;
        _quantity = quantity;
    }

    static public void PrintItem(Item item)
    {
        Console.WriteLine($"Barcode: {item.Barcode}, Item Name: {item.Name}, Quantity: {item.Quantity}");
    }

    public void IncreaseQuantity(int value)
    {
        Quantity += value;
    }

    public void DecreaseQuantity(int value)
    {
        Quantity -= value;
    }
}