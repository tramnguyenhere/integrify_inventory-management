using InventoryManagement;

internal class Program
{
    private static void Main(string[] args)
    {
        var item1 = new Item("abc123", "Book", 30);
        var item2 = new Item("abc124", "BookReplace", 20);
        var item3 = new Item("abc125", "BookAddNew", 10);

        var listItems = new Inventory(100);

        listItems.AddItem(item1, 30);
        listItems.AddItem(item1, 20);
        listItems.AddItem(item2, 30);
        listItems.AddItem(item3, 20);

        listItems.DecreaseQuantity(10, "abc123");
        listItems.RemoveItem("abc125");

        listItems.ViewInventory();

        Printer.PrintItem(item1);
        Printer.PrintInventory(listItems);
    }
}