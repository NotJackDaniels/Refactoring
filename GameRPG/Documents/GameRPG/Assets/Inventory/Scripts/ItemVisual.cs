using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemVisual : MonoBehaviour,IPointerEnterHandler{
    private Item itemAsset;
	public void Init(Item item)
    {
        itemAsset = item;
        GetComponent<Image>().sprite = item.ItemImage;  
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponentInParent<InventoryPanel>().GetItem(itemAsset);
    }

}
