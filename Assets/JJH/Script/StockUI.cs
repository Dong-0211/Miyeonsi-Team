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
        //�ְ� ��� Ȯ���� ����ؼ� ��� �� ��ŭ �������� �϶��� ��ŭ ���������� ���
        if(Random.Range(0,100) < stock.Stocks[stockNumber].increacePricePercent)
        {
            result = current * Random.Range(0, stock.Stocks[stockNumber].increaceWidth) / 100;
        }
        else if (Random.Range(0, 100) > stock.Stocks[stockNumber].increacePricePercent)
        {
            result = - current * Random.Range(0, stock.Stocks[stockNumber].decreaceWidth) / 100;
        }
        current += result;

        ChangeUi(result);
    }

    public void ChangeUi(int result)
    {
        stockName.text = stock.Stocks[stockNumber].stockName;
        currentPrice.text = current.ToString();
        if(result > 0)
        {
            stockPercent.color = new Color(59.0f, 62.0f, 255.0f);
            stockPercent.text = result.ToString();
        }
        else if (result < 0)
        {
            stockPercent.color = new Color(255.0f, 62.0f, 35.0f);
            stockPercent.text = result.ToString();
        }
        //�������
        myPrice.text = stock.Stocks[stockNumber].stockName;
        myPercent.text = stock.Stocks[stockNumber].stockName;
        sum.text = stock.Stocks[stockNumber].stockName;
    }
}
