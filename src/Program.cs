using Feature;

internal class Program
{
    private static void Main(string[] args)
    {
        var item1 = new Item("abc123", "Book", 30);
        var item2 = new Item("abc123", "BookReplace", 20);
        var item3 = new Item("abc125", "BookAddNew", 10);
        item1.IncreaseQuantity(20);
        Console.WriteLine("Quantity after the increase: " + item1.Quantity);
        var listItems = new Inventory(100);
        listItems.AddItem(item1, 30);
        Console.WriteLine(listItems[0].Name);
        listItems.AddItem(item2, 30);
        Console.WriteLine(listItems[0].Name);
        listItems.RemoveItem("abc123");
    }
}