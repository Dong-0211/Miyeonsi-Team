using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyingItem : MonoBehaviour
{
    private StoreManager Item;
    private int buyItemCode;

    private void Awake()
    {
        Item = FindObjectOfType<StoreManager>();
        //int number = Item.CurrentItem[1];
    }

    //������ �ڵ��� Item.currentItem�� �迭�� ���ͼ� ���� ���� ������ �ľ�
    public void BuyItem()
    {
        string itemName = this.gameObject.name;
        Transform itemPrice = transform.Find("BuyButton").Find("ItemPrice");
        string priceText = itemPrice.GetComponent<Text>().text;
        float price = float.Parse(priceText.Substring(0, priceText.IndexOf('��')));
        int itemNumber = int.Parse(itemName.Substring(5, 1));

        buyItemCode = Item.CurrentItem[itemNumber];

        if (price < GameManager.Instance.data.abilities.Money)
        {
            GameManager.Instance.data.abilities.Money -= price;
            Item.SoldOut(itemNumber);

            for(int i = 0; i < 8; i++)
            {
                if (GameManager.Instance.data.inventory[i].itemCode == 63)
                {
                    
                    GameManager.Instance.data.inventory[i].itemCode = buyItemCode;
                    GameManager.Instance.data.inventory[i].itemCount++;
                    return;
                }
                else if (GameManager.Instance.data.inventory[i].itemCode != 63)
                {
                    if (GameManager.Instance.data.inventory[i].itemCode == buyItemCode)
                    {
                        GameManager.Instance.data.inventory[i].itemCount++;
                        return;
                    }
                }

            }
            
        }

    }
}
