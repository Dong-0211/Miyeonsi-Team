using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StockUI : MonoBehaviour
{
    public Stock stock;
    public int stockNumber;

    public Image StockLog;
    public Text stockName;
    public Text currentPrice;
    public Text stockPercent;
    public Text myPrice;
    public Text myPercent;
    public Text sum;

    private int current;

    
    // Start is called before the first frame update
    void Start()
    {
        current = stock.Stocks[stockNumber].startPrice;
        //stock = FindObjectOfType<Stock>();
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
        myPrice.text = stock.Stocks[stockNumber].stockName;
        myPercent.text = stock.Stocks[stockNumber].stockName;
        sum.text = stock.Stocks[stockNumber].stockName;
    }
}
