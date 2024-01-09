using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

[System.Serializable]
public class Calendar_Manager : MonoBehaviour
{
    [SerializeField] GameObject First_Background;
    [SerializeField] GameObject Second_Background;
    [SerializeField] GameObject PartTimeJob_Square;
    [SerializeField] GameObject tmp_to_do;
    [SerializeField] Text Month;
    [SerializeField] Text Day;
    [SerializeField] GameObject To_do;
    [SerializeField] RectTransform tmpRectTransform;


    [SerializeField] DateTime Today;

    void Start()
    {
        First_Background = this.transform.GetChild(0).gameObject;
        Second_Background = First_Background.transform.GetChild(3).gameObject;
        PartTimeJob_Square = Second_Background.transform.GetChild(0).gameObject;
        if (First_Background == null || Second_Background == null || PartTimeJob_Square == null)  
        {
            Debug.Log("캘린더 버그발생!");
            return;
        }

        To_do = PartTimeJob_Square.transform.GetChild(0).gameObject;

        Month = First_Background.transform.GetChild(1).gameObject.GetComponent<Text>();

    }

    public void RightSide_On()
    {
        if (Second_Background != null && Second_Background.activeSelf == false) { Second_Background.SetActive(true); }
        else if (Second_Background.activeSelf == true) { Second_Background.SetActive(false); }
        else { return; }
    }

    public void Close_Calendar()
    {
        if (First_Background.activeSelf == true) 
        {
            Second_Background.SetActive(false);
            First_Background.SetActive(false); 
        }
    }

    public void Open_Calendar()
    {
        if (First_Background.activeSelf == false) { First_Background.SetActive(true); }
        //Month.text = GameManager.Instance.data.abilities.Month.ToString() + " 월";

        Today = DateTime.Now;

        Debug.Log(Today.ToString());
    }
}
