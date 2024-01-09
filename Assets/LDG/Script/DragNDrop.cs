using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragNDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //[SerializeField] Vector2 Default_Pos;
    [SerializeField] Vector2 Current_Pos;
    [SerializeField] GameObject Copy_To_Do;
    [SerializeField] GameObject Work1;

    DayBox_Function DayBox_Function;

    void Start()
    {
        Work1 = Resources.Load<GameObject>("Prefab/Work1");
    }

    void Update()
    {
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        Copy_To_Do = Instantiate(Work1);
        //Copy_To_Do.GetComponent<DragNDrop>().enabled = false;
        Copy_To_Do.transform.SetParent(GameObject.Find("Canvas").transform);
        Copy_To_Do.GetComponent<Image>().color = new Color(1.0f, 0.0627f, 0.0627f, 1.0f);
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Current_Pos = eventData.position;
        Copy_To_Do.transform.position = Current_Pos;

    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Copy_To_Do.transform.position = Current_Pos;
        //DayBox_Function.To_do_Pos = Current_Pos;
    }

    
}
