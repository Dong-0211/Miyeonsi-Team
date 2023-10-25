using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Stock", menuName = "Stock/StockValue")]
public class Stock : ScriptableObject
{
    public List<ManagerStock> StockInt = new List<ManagerStock>();
   
}
