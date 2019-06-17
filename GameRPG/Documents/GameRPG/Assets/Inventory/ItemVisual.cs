using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemVisual : MonoBehaviour{
    private Item itemAsset;
    bool mous;
	public void Init(Item item)
    {
        itemAsset = item;
        GetComponent<Image>().sprite = item.ItemImage;  
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
         {
            GetComponentInParent<InventoryPanel>().ShowInfo(itemAsset);
        }
    }
    void OnMouseEnter()
    {
        mous = true;
    }
    void OnMouseExit()
    {
        mous = false;
    }
}
