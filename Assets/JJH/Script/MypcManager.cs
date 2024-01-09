using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MypcManager : MonoBehaviour
{
    [SerializeField] private Text health;
    [SerializeField] private Text stress;
    [SerializeField] private Text appearance;
    [SerializeField] private Text sociAbility;
    [SerializeField] private Text morality;
    [SerializeField] private Text intelligence;
    [SerializeField] private Text luck;

    // Start is called before the first frame update
    void Start()
    {
        health.text = "health : " + GameManager.Instance.data.abilities.Health.ToString();
        stress.text = "stress : " + GameManager.Instance.data.abilities.Stress.ToString();
        appearance.text = "appearance : " + GameManager.Instance.data.abilities.Appearance.ToString();
        sociAbility.text = "sociAbility : " + GameManager.Instance.data.abilities.SociAbility.ToString();
        morality.text = "morality : " + GameManager.Instance.data.abilities.Morality.ToString();
        intelligence.text = "intelligence : " + GameManager.Instance.data.abilities.Intelligence.ToString();
        luck.text = "Luck : " + GameManager.Instance.data.abilities.Luck.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
