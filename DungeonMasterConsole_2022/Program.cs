// See https://aka.ms/new-console-template for more information
using DungeonMasterDomain_2022;
using DungeonMasterDTO_2022;

DungeonItemInteractor _dungeonItemInteractor = new DungeonItemInteractor();
LoadStartUpData();
Console.ReadKey();

void LoadStartUpData()
{
    foreach (Item item in BuildItemCollection())
    {
        if (_dungeonItemInteractor.AddNewItem(item) == true)
        {
            Console.WriteLine($"{item.Name} was added to the database.");
        }
        else
        {
            Console.WriteLine($"{item.Name} was NOT added to the database.");
            Console.WriteLine("test");
        }
    }
}


List<Item> BuildItemCollection()
{
    List<Item> initialItems = new List<Item>();
    initialItems.Add(new Item() { Name = "Common Arrow", Description = "A cheap wood arrow" });
    initialItems.Add(new Item() { Name = "Dull Sword", Description = "A very old sword" });
    initialItems.Add(new Item() { Name = "Ragged Tunic", Description = "It barely covers the important bits" });
    initialItems.Add(new Item() { Name = "Common Arrow", Description = "A cheap wood arrow" });
    initialItems.Add(new Item() { Name = "Dented Helm", Description = "What happened to the previous owner" });
    return initialItems;
}

void DisplayAllItems()
{
    Console.WriteLine();
    Console.WriteLine("The following items are in the database");
    foreach (Item item in _dungeonItemInteractor.GetAllItems())
    {
        Console.WriteLine($" - {item.Name}, {item.Description}");
    }
}
void DisplayItemInformation(int itemId)
{
    Console.WriteLine();
    Console.WriteLine($"Searching for item ID {itemId}");
    bool doesItemExist = _dungeonItemInteractor.GetItemIfExists(itemId, out Item returnedItem);
    if (doesItemExist)
    { Console.WriteLine($"Name: {returnedItem.Name}: {returnedItem.Description}"); }
    else
    { Console.WriteLine("That item does not exist"); }
}

DisplayAllItems();
DisplayItemInformation(1);
DisplayItemInformation(10);
Console.WriteLine();
Console.WriteLine("Press any key to exit");
Console.ReadKey();

void UpdateItemModifiers(int itemId, int attackModifier, int defenseModifier)
{
    // Get the item to update
    if (_dungeonItemInteractor.GetItemIfExists(itemId, out Item returnedItem))
    {
        returnedItem.AttackModifier = attackModifier;
        returnedItem.DefenseModifier = defenseModifier;
        _dungeonItemInteractor.UpdateItem(returnedItem);
        Console.WriteLine($"{returnedItem.Name} was successfully updated to the database.");
    }
    else
    {
        Console.WriteLine($"There was a problem updating the record for Id {itemId}.");
    }
}

UpdateItemModifiers(1, 0, 5);
UpdateItemModifiers(2, 10, -1);
UpdateItemModifiers(defenseModifier: 10, attackModifier: 10, itemId: 20);

void DeleteItem(int itemId)
{
    // Get the item to update
    if (_dungeonItemInteractor.DeleteItem(itemId))
    {
        Console.WriteLine($"Item ID {itemId} was successfully deleted from the database.");
    }
    else
    {
        Console.WriteLine($"There was a problem deleting the record for Id {itemId}.");
    }
}
