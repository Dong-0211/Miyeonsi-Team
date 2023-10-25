using UnityEngine;

[System.Serializable]
public class ManagerStock 
{

    [SerializeField] public string stockName;
    [SerializeField] public int stockNumber;
    [SerializeField] public float startPrice;
    [SerializeField] public float endPrice;
    [SerializeField] public float increacePricePercent;
    [SerializeField] public int increaceWidth;
    [SerializeField] public int decreaceWidth;


}
