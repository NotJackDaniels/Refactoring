using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanel : MonoBehaviour {
    public Button button;
    public Text itemName, bonusName,bonusCount,itemPrice,price,plus,buttonText;
    public Image itemPicture;
    private Item item;

    public void GetItem(Item itemAsset)
    {
        item = itemAsset;
        ShowInfo();
    }
    public void ShowInfo()
    {
        if (item.itemName == "HPbottle")
        {
            itemName.enabled = true;
            bonusName.enabled = true;
            bonusCount.enabled = true;
            itemPicture.enabled = true;
            itemPrice.enabled = true;
            price.enabled = true;
            plus.enabled = true;
            buttonText.enabled = true;
            itemName.text = item.itemName;
            bonusName.text = item.bonusName;
            bonusCount.text = item.itemHP.ToString();
            itemPicture.sprite = item.ItemImage;
            itemPrice.text = "Price";
            price.text = item.itemPrice.ToString();
        }
        if (item.itemName == "Beer")
        {
            itemName.enabled = true;
            bonusName.enabled = true;
            bonusCount.enabled = true;
            itemPicture.enabled = true;
            itemPrice.enabled = true;
            price.enabled = true;
            plus.enabled = true;
            buttonText.enabled = true;
            itemName.text = item.itemName;
            bonusName.text = item.bonusName;
            bonusCount.text = item.itemDamage.ToString();
            itemPicture.sprite = item.ItemImage;
            itemPrice.text = "Price";
            price.text = item.itemPrice.ToString();
        }
        if (item.itemName == "Wine")
        {
            itemName.enabled = true;
            bonusName.enabled = true;
            bonusCount.enabled = true;
            itemPicture.enabled = true;
            itemPrice.enabled = true;
            price.enabled = true;
            plus.enabled = true;
            buttonText.enabled = true;
            itemName.text = item.itemName;
            bonusName.text = item.bonusName;
            bonusCount.text = item.itemHP.ToString();
            itemPicture.sprite = item.ItemImage;
            itemPrice.text = "Price";
            price.text = item.itemPrice.ToString();
        }
    }
    public void OnClick()
    {
        if (item.itemName == "HPbottle" && money_player.money >= item.itemPrice)
        {
            money_player.money -= item.itemPrice;
            GameObject.FindGameObjectWithTag("Player").GetComponent<money_player>().TextMoney.text = money_player.money.ToString();
            hpBottle_player.hp += 1;
            GameObject.FindGameObjectWithTag("Player").GetComponent<hpBottle_player>().TextHP.text = hpBottle_player.hp.ToString();
            return;
        }
        if (item.itemName == "Beer" && money_player.money >= item.itemPrice)
        {
            money_player.money -= item.itemPrice;
            GameObject.FindGameObjectWithTag("Player").GetComponent<money_player>().TextMoney.text = money_player.money.ToString();
            AxeDamage.damage += item.itemDamage;
            return;
        }
        if (item.itemName == "Wine" && money_player.money >= item.itemPrice)
        {
            money_player.money -= item.itemPrice;
            GameObject.FindGameObjectWithTag("Player").GetComponent<money_player>().TextMoney.text = money_player.money.ToString();
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerstat>().stats.HP += item.itemHP;
            return;
        }
    }
}
