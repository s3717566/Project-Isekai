public interface IItemContainer
{
        int ItemCount(Item item);

    bool ContainsItem(Item item);
    bool RemoveItem(Item item);
    
    bool AddItem(Item item);
    bool IsFull();

    //     int ItemCount (string itemID);
    // Item RemoveItem (string itemID);
    // bool RemoveItem (Item item);
    // bool AddItem (Item item);
    // bool IsFull ();
}
