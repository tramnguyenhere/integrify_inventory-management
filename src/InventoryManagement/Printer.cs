using System;
using System.Collections.Generic;

namespace InventoryManagement;

class Printer
{
    static public void PrintItem(Item item)
    {
        Console.WriteLine($"Barcode: {item.Barcode}\nName: {item.Name}\nQuantity: {item.Quantity}");
    }

    static public void PrintInventory(Inventory inventory)
    {
        int totalItems = inventory.GetTotalNumberOfItems();
        int totalQuantity = inventory.GetTotalQuantity();
        Console.WriteLine($"Inventory information:\n---\nTotal items: {totalItems}\nTotal quantity of items: {totalQuantity}\nMaximum capacity: {inventory.MaxCapacity}\n---");
        inventory.ViewInventory();
    }
}