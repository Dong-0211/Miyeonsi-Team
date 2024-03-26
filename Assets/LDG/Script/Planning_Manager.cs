using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Calendar
{
    public List<GameObject> First_Day;
    public List<GameObject> Second_Day;
    public List<GameObject> Third_Day;
    public List<GameObject> Fourth_Day;
    public List<GameObject> Fifth_Day;
    public List<GameObject> Sixth_Day;
    public List<GameObject> Seventh_Day;
}

public class Planning_Manager : MonoBehaviour
{
    //[SerializeField] GameObject[] tmp_Week;
    //[SerializeField] GameObject[] tmp_Day;
    [SerializeField] Calendar[] Week;

    void Start()
    {
        Week = new Calendar[5];
        for(int i = 0; i < 5; i++)
        {
            Week[i] = new Calendar();
            GameObject tmp_Week = this.gameObject.transform.GetChild(i).gameObject;
            Week[i].First_Day = new List<GameObject>(new GameObject[3]);
            for (int k = 0; k < 7; k++)
            {
                GameObject tmp_Day = tmp_Week.transform.GetChild(k).gameObject;
                for(int j = 0; j < 3; j++)
                {
                    Week[i].First_Day.Add(tmp_Day.transform.GetChild(j).gameObject);
                }
            }
        }
    }

    void Update()
    {
        
    }
}
