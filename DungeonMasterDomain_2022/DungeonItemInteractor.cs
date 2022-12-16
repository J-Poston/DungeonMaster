using DungeonMasterDTO_2022;
using DungeonMasterRepository_2022;

namespace DungeonMasterDomain_2022
{
    public class DungeonItemInteractor
    {
        private DungeonItemRepository _repository;

        public DungeonItemInteractor()
        {
            _repository = new DungeonItemRepository();
        }
        public bool AddNewItem(Item itemToAdd)
        {
            if (string.IsNullOrEmpty(itemToAdd.Name) || string.IsNullOrEmpty(itemToAdd.Description))
            {
                throw new ArgumentException("Name and Description must contain valid text.");
            }
            return _repository.AddItem(itemToAdd);
        }


        public List<Item> GetAllItems()
        {
            return _repository.GetAllItems();
        }

        public bool GetItemIfExists(int itemId, out Item itemToReturn)
        {
            Item item = _repository.GetItemById(itemId);
            itemToReturn = item;
            return itemToReturn != null;
        }

        public bool UpdateItem(Item itemToUpdate)
        {
            if (string.IsNullOrEmpty(itemToUpdate.Name) || string.IsNullOrEmpty(itemToUpdate.Description))
            {
                throw new ArgumentException("Name and Description must contain valid text.");
            }

            Item item = _repository.GetItemById(itemToUpdate.ID);

            if (item == null)
            {
                // The item does not exits
                return false;
            }
            _repository.UpdateItem(itemToUpdate);
            return true;
        }
        public bool DeleteItem(int itemId)
        {
            Item item = _repository.GetItemById(itemId);
            if (item == null)
            {
                // The item does not exits
                return false;
            }
            _repository.DeleteItem(item);
            return true;
        }


    }
}