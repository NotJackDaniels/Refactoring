using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour {
    public Button BuyButton;
    public Text itemName, bonusName,bonusCount;
    public Image itemPicture;
    public void ShowInfo(Item item)
    {
        itemName.enabled = true;
        bonusName.enabled = true;
        bonusCount.enabled = true;
        itemPicture.enabled = true;
        itemName.text = item.itemName;
        bonusName.text = item.bonusName;
        bonusCount.text = item.itemDamage.ToString();
        itemPicture.sprite = item.ItemImage;
    }
    public void BuyItem(Item item)
    {
        money_player.money -= item.itemPrice;
        GameObject.FindGameObjectWithTag("Player").GetComponent<money_player>().TextMoney.text = money_player.money.ToString(); // вывод количеста монет на экран
        AxeDamage.damage += item.itemDamage;
    }
}
