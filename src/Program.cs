using Inventory;

internal class Program
{
    private static void Main(string[] args)
    {
        var item1 = new Item("abc123", "Book", 30);
        item1.IncreaseQuantity(20);
        Console.WriteLine("Quantity after the increase: " + item1.Quantity);
        Item.PrintItem(item1);
    }
}