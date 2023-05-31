using Feature;

internal class Program
{
    private static void Main(string[] args)
    {
        var item1 = new Item("abc123", "Book", 30);
        item1.IncreaseQuantity(20);
        Console.WriteLine("Quantity after the increase: " + item1.Quantity);
        var listItems = new Inventory(100);
        listItems.AddItem("abc", "Book", 30);
        Console.WriteLine(listItems.Items[0].Name);
        listItems.AddItem("abc", "BookNew", 30);
        Console.WriteLine(listItems.Items[0].Name);
        listItems.RemoveItem("abc");
    }
}