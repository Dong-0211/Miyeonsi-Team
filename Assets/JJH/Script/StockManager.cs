using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StockManager : MonoBehaviour
{
    public Stock stock;

    private static StockManager instance;

    private void Awake()
    {
        stock = Resources.Load<Stock>("ScriptableObject/Stocks");

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static StockManager Instance
    {
        get
        {
            if (instance == null) return null;
            return instance;
        }
    }
}
