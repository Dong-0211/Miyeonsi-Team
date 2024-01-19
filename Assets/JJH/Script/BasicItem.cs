using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "Item/MakeItem")]
public class BasicItem : ScriptableObject
{
    public Sprite ItemImage;
    public int itemCode;
    public string itemName;
    public int itemCost;
}
