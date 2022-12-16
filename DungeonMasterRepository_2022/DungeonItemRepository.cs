
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using DungeonMasterDTO_2022;

namespace DungeonMasterRepository_2022
{
    public class DungeonItemRepository
    {
        private IConfigurationRoot _configuration;
        private DbContextOptionsBuilder<ApplicationDbContext> _optionsBuilder;

        public DungeonItemRepository()
        {
            BuildOptions();
        }
        public void BuildOptions()
        {
            _configuration = ConfigurationBuilderSingleton.ConfigurationRoot;
            _optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            _optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DungeonManager"));
        }
        public bool AddItem(Item itemToAdd)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_optionsBuilder.Options))
            {
                //determine if item exists
                Item existingItem = db.Items.FirstOrDefault(x => x.Name.ToLower() == itemToAdd.Name.ToLower());

                if (existingItem == null)
                {
                    // doesn't exist, add it
                    db.Items.Add(itemToAdd);
                    db.SaveChanges();
                    return true;
                }

                return false;
            }
        }

        public List<Item> GetAllItems()
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_optionsBuilder.Options))
            {
                return db.Items.ToList();
            }
        }

        public Item GetItemById(int itemId)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_optionsBuilder.Options))
            {
                return db.Items.FirstOrDefault(x => x.Id == itemId);
            }
        }

        public void UpdateItem(Item itemToUpdate)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_optionsBuilder.Options))
            {
                db.Items.Update(itemToUpdate);
                db.SaveChanges();
            }
        }

        public void DeleteItem(Item itemToDelete)
        {
            using (ApplicationDbContext db = new ApplicationDbContext(_optionsBuilder.Options))
            {
                db.Items.Remove(itemToDelete);
                db.SaveChanges();
            }
        }

    }

}
