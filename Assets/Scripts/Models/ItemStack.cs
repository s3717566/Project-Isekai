using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStack
{
public void item;
public int amount;

public ItemStack(Item item, int amount) {
    this.item = item;
    this.amount = amount;
}
