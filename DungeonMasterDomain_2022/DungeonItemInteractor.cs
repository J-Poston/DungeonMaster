using DungeonMasterDTO_2022;
using DungeonMasterRepository_2022;

namespace DungeonMasterDomain_2022
{
    public class DungeonItemInteractor
    {
        private DungeonItemRepository _respository;

        public DungeonItemInteractor()
        {
            _respository = new DungeonItemRepository();
        }
        public bool AddNewItem(Item itemToAdd)
        {
            if (string.IsNullOrEmpty(itemToAdd.Name) || string.IsNullOrEmpty(itemToAdd.Description))
            {
                throw new ArgumentException("Name and Description must contain valid text.");
            }
            return _respository.AddItem(itemToAdd);
        }

    }
}