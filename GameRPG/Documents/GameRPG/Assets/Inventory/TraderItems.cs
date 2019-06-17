using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraderItems : MonoBehaviour {

    public Item[] initialItems;
    public Trade inventoryVisual;

    private List<Item> inventoryItems = new List<Item>();
    private void Start()
    {
        foreach(Item item in initialItems)
        {
            AddItem(item);
        }
    }
    private void AddItem(Item item)
    {
        inventoryItems.Add(item);
        inventoryVisual.AddItem(item);
    }
}
