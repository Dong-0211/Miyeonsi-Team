using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    public TextMeshProUGUI currentMoney;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentMoney.text = GameManager.Instance.data.abilities.Money.ToString();
    }
}
