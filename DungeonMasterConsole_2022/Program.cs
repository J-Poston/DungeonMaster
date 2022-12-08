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
