namespace DungeonMasterDTO_2022
{
    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? AttackModifier { get; set; }
        public int? DefenseModifier { get; set; }
        public string? Lore { get; set; }
        public bool? IsEnchanted { get; set; }
        public bool? IsBreakable { get; set; }

    }
}