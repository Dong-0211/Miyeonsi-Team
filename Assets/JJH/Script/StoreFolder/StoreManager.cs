using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Slot;
    private StoreItem item;
    private int[] currentIItem;
    public int[] CurrentItem
    {
        get { return currentIItem; }
    }

    private void Awake()
    {
        currentIItem = new int[6];
        item = Resources.Load<StoreItem>("ScriptableObject/Items");
    }
    // Start is called before the first frame update
    void Start()
    {
        ItemRestock();
        DrawScrence();
    }

    public void ItemRestock()
    {
        for (int i = 0; i < 6; i++)
        {
            currentIItem[i] = Random.Range(0, 10);

        }
    }

    public void DrawScrence()
    {
        for (int i = 0; i < 6; i++)
        {
            if (item.items[i] != null)
            {
                Slot[i].transform.Find("ItemImage").GetComponent<Image>().sprite = item.items[currentIItem[i]].ItemImage;
                Slot[i].transform.Find("BuyButton").Find("ItemPrice").GetComponent<Text>().text = item.items[currentIItem[i]].Price.ToString() + "¿ø";
            }
            else
            {
                Slot[i].transform.Find("ItemImage").GetComponent<Image>().sprite = null;
                Slot[i].transform.Find("BuyButton").Find("ItemPrice").GetComponent<Text>().text = "0";

            }
        }
    }

    public void SoldOut(int ItemNumber)
    {
        Debug.Log("SoldOut");
        Slot[ItemNumber].transform.Find("BuyButton").Find("ItemPrice").GetComponent<Text>().text = "¸ÅÁø";

    }
}
