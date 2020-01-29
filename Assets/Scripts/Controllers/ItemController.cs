using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController
{
    
    List<Item> itemList = new List<Item>();

    public ItemController () {
        Debug.Log("item controller has awoken.");
    }

    public void populateItems () {
        // itemList.Add (new Item { itemType = Item.ItemType.Weapon, amount = 1 });
        // itemList.Add (new Item { itemType = Item.ItemType.Weapon, amount = 1 });
        // itemList.Add (new Item { itemType = Item.ItemType.Weapon, amount = 1, sprite = IconController.Instance.castleSprite });
        // itemList.Add (new Item { itemType = Item.ItemType.Helmet, amount = 1, sprite = IconController.Instance.helmetSprite });
        // itemList.Add (new Item { itemType = Item.ItemType.Chestplate, amount = 1, sprite = IconController.Instance.chestplateSprite });
        // itemList.Add (new Item { itemType = Item.ItemType.Leggings, amount = 1, sprite = IconController.Instance.leggingsSprite });
        // itemList.Add (new Item { itemType = Item.ItemType.Boots, amount = 1, sprite = IconController.Instance.bootsSprite });
        // itemList.Add (new Item { itemType = Item.ItemType.Weapon, amount = 1 });
        // itemList.Add (new Item { itemType = Item.ItemType.Weapon, amount = 1 });
        // itemList.Add (new Item { itemType = Item.ItemType.Weapon, amount = 1 });
        // itemList.Add (new Item { itemType = Item.ItemType.Weapon, amount = 1 });
        // itemList.Add (new Item { itemType = Item.ItemType.Weapon, amount = 1 });

        int i = 0;
                // itemList.Add (new Item { id = 0, itemType = Item.ItemType.Weapon, amount = 1, sprite = IconController.Instance.castleSprite });


        Item item;
                Debug.Log(Item.ItemType.Weapon);
                Debug.Log(IconController.Instance.swordSprite);

        item = new Item (i++, "a huge fucking stick", "exact what it says it is. Thing has to be at least 3m long.", Item.ItemType.Weapon, 1, IconController.Instance.swordSprite);
        Debug.Log(item.ToString());
        itemList.Add (new Item (i++, "a huge fucking stick", "exact what it says it is. Thing has to be at least 3m long.", Item.ItemType.Weapon, 1, IconController.Instance.swordSprite));
        itemList.Add (new Item (i++, "a medium fucking stick", "exact what it says it is. Thing has to be at least 3m long.", Item.ItemType.Weapon, 1, IconController.Instance.castleSprite));
        itemList.Add (new Item (i++, "a small fucking stick", "exact what it says it is. Thing has to be at least 3m long.", Item.ItemType.Weapon, 1, IconController.Instance.chestplateSprite));
        itemList.Add (new Item (i++, "a decent fucking stick", "exact what it says it is. Thing has to be at least 3m long.", Item.ItemType.Weapon, 1, IconController.Instance.leggingsSprite));
        itemList.Add (new Item (i++, "a enormous fucking stick", "exact what it says it is. Thing has to be at least 3m long.", Item.ItemType.Weapon, 1, IconController.Instance.bootsSprite));
        itemList.Add (new Item (i++, "a fucking stick", "exact what it says it is. Thing has to be at least 3m long.", Item.ItemType.Weapon, 1, IconController.Instance.helmetSprite));

        Debug.Log ("itemlist count" + itemList.Count);
    }

    public List<Item> getItemList () {
        return itemList;
    }

    public Item getRandomItem () {
        System.Random random = new System.Random ();
        int index = random.Next (itemList.Count);
        Debug.Log (itemList[index].getName ());
        return itemList[index];
    }

    public Item getItem () {
        return itemList[0];
    }

        public Item getItem (int i) {
        return itemList[i];
    }
}
