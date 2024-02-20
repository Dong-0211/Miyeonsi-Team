using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryLoader : MonoBehaviour
{
    [SerializeField] private Transform[] Slot;
    private StoreItem item;

    private void Awake()
    {
        item = Resources.Load<StoreItem>("ScriptableObject/Items");
    }

    private void Start()
    {
        for(int i = 0; i < 8; i++)
        {
            int id = GameManager.Instance.data.inventory[i].itemCode;
            Slot[i].transform.Find("ItemImage").GetComponent<Image>().sprite = item.items[id].ItemImage;
            Slot[i].transform.Find("ItemName").GetComponent<Text>().text = item.items[id].ItemName;
            Slot[i].transform.Find("ItemCount").GetComponent<Text>().text = GameManager.Instance.data.inventory[i].itemCount.ToString();
        }
    }
    /*
     * for (int i = 0; i < 8; i++)
        {
            if (item.items[i] != null)
            {
                Slot[i].transform.Find("ItemImage").GetComponent<Image>().sprite = item.items[i].ItemImage;
                Slot[i].transform.Find("ItemPrice").GetComponent<Text>().text = item.items[i].Price.ToString();
                Slot[i].transform.Find("ItemName").GetComponent<Text>().text = item.items[i].ItemName;
            }
            else
            {
                Slot[i].transform.Find("ItemImage").GetComponent<Image>().sprite = null;
                Slot[i].transform.Find("ItemPrice").GetComponent<Text>().text = "0";
                Slot[i].transform.Find("ItemName").GetComponent<Text>().text = "�������� �����ϴ�";

            }
        }
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
    */
}
