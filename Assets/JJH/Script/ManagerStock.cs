using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class ManagerStock 
{

    [SerializeField] public string stockName;
    [SerializeField] public int stockNumber;
    [SerializeField] public int startPrice;
    [SerializeField] public float endPrice;
    [SerializeField] public float increacePricePercent;
    [SerializeField] public int increaceWidth;
    [SerializeField] public int decreaceWidth;

}

[CreateAssetMenu(fileName = "Stock", menuName = "Stock/StockValue")]
public class Stock : ScriptableObject
{
    public List<ManagerStock> Stocks = new List<ManagerStock>();

}
