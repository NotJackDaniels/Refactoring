using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyItem : MonoBehaviour {
    private Item itemAsset;
    // Use this for initialization
    public void Init(Item item)
    {
        itemAsset = item;
    }
    public void BuyClick()
    {
        if (money_player.money >= itemAsset.itemPrice)
        {
            GetComponentInParent<InventoryPanel>().BuyItem(itemAsset);
        }

    }
}
