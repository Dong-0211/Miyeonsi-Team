using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StockUI : MonoBehaviour
{
    Stock stock;
    PlayerMoney player;
    public int stockNumber;

    public Image StockLog;
    public Text stockName;
    public Text currentPrice;
    public Text stockPercent;
    public Text myPrice;
    public Text myPercent;
    public Text sum;
    public Text holdingStocks;

    private int current;
    private float myAveragePrice;
    private float sumPrice;
    private float sumPercent;

    private void Awake()
    {
        stock = Resources.Load<Stock>("ScriptableObject/Stocks");
        player = FindObjectOfType<PlayerMoney>();
    }

    // Start is called before the first frame update
    void Start()
    {
        current = stock.Stocks[stockNumber].startPrice;
        ChangePrice();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            ChangePrice();

        }
    }

    public void ChangePrice()
    {
        int result = 0;
        int range = Random.Range(0, 100);
        //주가 상승 확률을 계산해서 상승 시 얼만큼 오르는지 하락시 얼만큼 떨어지는지 계산
        if (range < stock.Stocks[stockNumber].increacePricePercent)
        {
            result = current * Random.Range(0, stock.Stocks[stockNumber].increaceWidth) / 100;
        }
        else if (range > stock.Stocks[stockNumber].increacePricePercent)
        {
            result = - current * Random.Range(0, stock.Stocks[stockNumber].decreaceWidth) / 100;
            if (current + result < stock.Stocks[stockNumber].endPrice)
            {
                current = stock.Stocks[stockNumber].endPrice;
                ChangeUi(result);
                return;
            }
        }
        current += result;

        ChangeUi(result);
    }

    public void ChangeUi(int result)
    {
        stockName.text = stock.Stocks[stockNumber].stockName;
        currentPrice.text = current.ToString();
        if(result < 0)
        {
            stockPercent.text = result.ToString();
            stockPercent.color = Color.blue;
        }
        else if (result > 0)
        {
            stockPercent.text = result.ToString();
            stockPercent.color = Color.red;
        }
        //여기까지
        ChangeMyUi();
    }

    public void ChangeMyUi()
    {
        sumPercent = CalculationPercent();
        sumPrice = CalculationSum();

        holdingStocks.text = stock.Stocks[stockNumber].holdingValue.ToString();
        myPrice.text = myAveragePrice.ToString();
        myPercent.text = sumPercent.ToString();
        sum.text = sumPrice.ToString();
    }

    public void Buy()
    {
        if(player.Money > current)
        {
            player.Money = player.Money - current;
            stock.Stocks[stockNumber].holdingValue++;
            myAveragePrice = CalculationAverage();
            
            sumPercent = CalculationPercent();
            ChangeMyUi();
        }
    }

    public float CalculationAverage()
    {
        float result = 0;
        if (stock.Stocks[stockNumber].holdingValue == 0) return 0;
        result = (myAveragePrice * (stock.Stocks[stockNumber].holdingValue -1) + current) / (stock.Stocks[stockNumber].holdingValue);
        return result;
    }

    public float CalculationPercent()
    {
        if(myAveragePrice == 0) return 0;
        return (current - myAveragePrice) / myAveragePrice * 100;
    }

    public float CalculationSum()
    {
        return current * stock.Stocks[stockNumber].holdingValue;
    }

    public void Sell()
    {
        if(stock.Stocks[stockNumber].holdingValue > 0)
        {
            player.Money += current;
            --stock.Stocks[stockNumber].holdingValue;
            if (stock.Stocks[stockNumber].holdingValue == 0)
            {
                myAveragePrice = CalculationAverage();
                sumPercent = CalculationPercent();
            }
            ChangeMyUi();
        }
    }
}
