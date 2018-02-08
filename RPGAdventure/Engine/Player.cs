using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
   public class Player : LivingCreature
    {
        public int Gold { get; set; }
        public int ExperiencePoints { get; set; }
        public int Level { get; set; }
        public List<InventoryItem> Inventory { get; set; }
        public List<PlayerQuest> Quests { get; set; }
        public Location CurrentLocation { get; set; }
    

        public Player(int gold, int experiencePoints, int level, int currentHitPoints, int maximumHitPoints) : base(currentHitPoints, maximumHitPoints)
        {
            this.Gold = gold;
            this.ExperiencePoints = experiencePoints;
            this.Level = level;
            this.Inventory = new List<InventoryItem>();
            this.Quests = new List<PlayerQuest>();
        }

        public bool HasRequiredItemToEnterLocation(Location location)
        {
            if (location.ItemRequiredToEnter == null)
            {
                return true;
            }

            foreach (var inventoryItem in Inventory)
            {
                if (inventoryItem.Details.ID == location.ItemRequiredToEnter.ID)
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasThisQuest(Quest quest)
        {
            foreach (var playerQuest in Quests)
            {
                if (playerQuest.Details.ID == quest.ID)
                {
                    return true;
                }
            }

            return false;
        }

        public bool HasCompletedThisQuest(Quest quest)
        {
            foreach (var playerQuest in Quests)
            {
                if (playerQuest.Details.ID == quest.ID)
                {
                    return playerQuest.IsCompleted;
                }
            }
            return false;
        }

        public bool HasAllQuestCompletionItems(Quest quest)
        {
            foreach (var questCompletionItems in quest.QuestCompletionItems)
            {
                bool foundItemInPlayersInventory = false;

                foreach (var inventoryItem in Inventory)
                {
                    if (inventoryItem.Details.ID == questCompletionItems.Details.ID)
                    {
                        foundItemInPlayersInventory = true;

                        if (inventoryItem.Quantity < questCompletionItems.Quantity)
                        {
                            return false;
                        }
                    }
                }

                if (!foundItemInPlayersInventory)
                {
                    return false;
                }
            }
            return true;
        }

        public void RemoveQuestCompletionItems(Quest quest)
        {
            foreach (var questCompletionItem in quest.QuestCompletionItems)
            {
                foreach (var inventoryItem in Inventory)
                {
                    if (inventoryItem.Details.ID == questCompletionItem.Details.ID)
                    {
                        inventoryItem.Quantity -= questCompletionItem.Quantity;
                        break;
                    }
                }
            }
        }

        public void AddItemToInventory(Item item)
        {
            foreach (var inventoryItem in Inventory)
            {
                if (inventoryItem.Details.ID == item.ID)
                {
                    inventoryItem.Quantity++;
                    return;
                }
            }

            Inventory.Add(new InventoryItem(item, 1));
        }

        public void MarkQuestCompleted(Quest quest)
        {
           
            foreach (var playerQuest in Quests)
            {
                if (playerQuest.Details.ID == quest.ID)
                {
                    playerQuest.IsCompleted = true;
                }
                return;
                }
            }
        }
    }
}
