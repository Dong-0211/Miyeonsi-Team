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
}
