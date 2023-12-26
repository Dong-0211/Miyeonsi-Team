using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private int money;
    public int Money { get =>  money; set { money = value;} }

    public Text currentMoney;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentMoney.text = "Money : " + money.ToString();
    }
}
