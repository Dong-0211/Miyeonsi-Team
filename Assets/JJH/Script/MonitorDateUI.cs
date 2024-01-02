using UnityEngine;
using UnityEngine.UI;

public class MonitorDateUI : MonoBehaviour
{
    public Text date;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        date.text = GameManager.Instance.data.abilities.Month.ToString() + "/" + GameManager.Instance.data.abilities.Day.ToString();

    }
}
