using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Calendar_Manager : MonoBehaviour
{
    [SerializeField] GameObject First_Background;
    [SerializeField] GameObject Second_Background;
    [SerializeField] Text Month;
    [SerializeField] Text Day;
    [SerializeField] GameObject To_do;
    void Start()
    {
        First_Background = this.transform.GetChild(0).gameObject;
        Second_Background = First_Background.transform.GetChild(3).gameObject;
        if (First_Background == null || Second_Background == null) 
        {
            Debug.Log("캘린더 버그발생!");
            return;
        }
        Transform PartTimeJob_Square = Second_Background.transform.GetChild(0);
        To_do = PartTimeJob_Square.transform.GetChild(0).gameObject;
    }

    void Update()
    {
        
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
    }

    public void Test_event()
    {
        GameObject tmp_to_do = Instantiate(To_do);
    }

}
