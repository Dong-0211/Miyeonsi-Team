using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    [SerializeField] private GameObject[] Slot;
    private StoreItem item;

    private void Awake()
    {
        item = Resources.Load<StoreItem>("ScriptableObject/Items");
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            if (item.items[i] != null)
            {
                Slot[i].transform.Find("ItemImage").GetComponent<Image>().sprite = item.items[i].ItemImage;
                Slot[i].transform.Find("BuyButton").Find("ItemPrice").GetComponent<Text>().text = item.items[i].Price.ToString() + "¿ø";
            }
            else
            {
                Slot[i].transform.Find("ItemImage").GetComponent<Image>().sprite = null;
                Slot[i].transform.Find("BuyButton").Find("ItemPrice").GetComponent<Text>().text = "0";

            }
        }
        
    }


}
