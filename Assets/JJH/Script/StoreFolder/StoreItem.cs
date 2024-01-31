using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Items
{
    [SerializeField] private string itemName;
    [SerializeField] private int price;
    [SerializeField] private Sprite itemImage;
    [SerializeField] private int itemCode;
    public string ItemName { get { return itemName; } }
    public int Price { get { return price; } }
    public Sprite ItemImage { get { return itemImage; } }
    public int ItemCode { get { return itemCode; } }
}

[CreateAssetMenu(fileName = "Item", menuName = "Item/ScoreItem")]
public class StoreItem : ScriptableObject
{
    [SerializeField] public List<Items> items = new List<Items>();
}
