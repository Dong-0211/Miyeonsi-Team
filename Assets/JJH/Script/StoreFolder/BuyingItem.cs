using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyingItem : MonoBehaviour
{
    private StoreManager Item;

    private void Awake()
    {
        Item = FindObjectOfType<StoreManager>();
        //int number = Item.CurrentItem[1];
    }

    //������ �ڵ��� Item.currentItem�� �迭�� ���ͼ� ���� ���� ������ �ľ�
    public void BuyItem()
    {
        string itemName = this.gameObject.name;
        Transform itemPrice = transform.Find("ItemPrice");
        float price = float.Parse(itemPrice.GetComponent<Text>().text);
        int itemNumber = int.Parse(itemName.Substring(5, 1));


        if (price < GameManager.Instance.data.abilities.Money)
        {
            GameManager.Instance.data.abilities.Money -= price;

            for(int i = 0; i < 8; i++)
            {
                if (GameManager.Instance.data.inventory[i].itemCode == 63)
                {
                    
                    GameManager.Instance.data.inventory[i].itemCode = itemNumber;
                    GameManager.Instance.data.inventory[i].itemCount++;
                    return;
                }
                else if (GameManager.Instance.data.inventory[i].itemCode != 63)
                {
                    if (GameManager.Instance.data.inventory[i].itemCode == itemNumber)
                    {
                        GameManager.Instance.data.inventory[i].itemCount++;
                        return;
                    }
                }

            }
            
        }

    }
}
