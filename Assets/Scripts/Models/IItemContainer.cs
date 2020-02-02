public interface IItemContainer {
    	bool CanAddItem(Item item, int amount = 1);

    int ItemCount (string itemID);
    Item RemoveItem (string itemID);
    bool RemoveItem (Item item);
    bool AddItem (Item item);
    bool IsFull ();
}