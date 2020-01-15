using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ItemController : MonoBehaviour
{
     public Item[] itemList;

     public Text itemDisplayText;

     public void getItem() {
         Item item = itemList[Random.Range(0, itemList.Length)].name;
         InventoryController.instance.AddItemToInventory(new ItemStack(item, 1));
         itemDisplayText.text = item.name;
     }
}
