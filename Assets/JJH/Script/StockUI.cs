using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StockUI : MonoBehaviour
{
    private Stock stock;
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

    private Ability Data;

    private void Awake()
    {
        stock = Resources.Load<Stock>("ScriptableObject/Stocks");
        Data = GameManager.Instance.data.abilities;
    }

    // Start is called before the first frame update
    void Start()
    {
        current = stock.Stocks[stockNumber].startPrice;
        ChangePrice();
    }

    void Update()
    {
        if(stock.upDate != 0)
        {
            ChangePrice();
            stock.upDate -= 1;
        }
    }

    public void ChangePrice()
    {
        int result = 0;
        int range = Random.Range(0, 100);
        //�ְ� ��� Ȯ���� ����ؼ� ��� �� ��ŭ �������� �϶��� ��ŭ ���������� ���
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
        //�������
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
        if(Data.Money > current)
        {
            Data.Money = Data.Money - current;
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
            Data.Money += current;
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
