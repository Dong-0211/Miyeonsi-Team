using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragNDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] Vector2 Default_Pos;
    [SerializeField] Vector2 Current_Pos;
    //[SerializeField] Vector2 Mouse_Pos;
    [SerializeField] GameObject Copy_To_Do;

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        //Default_Pos = this.transform.position;
        Copy_To_Do = Instantiate(this.gameObject);
        Copy_To_Do.transform.parent = GameObject.Find("Canvas").transform;
        Copy_To_Do.GetComponent<Image>().color = new Color(1.0f, 0.0627f, 0.0627f, 1.0f);
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Current_Pos = eventData.position;
        //this.transform.position = Current_Pos;
        Copy_To_Do.transform.position = Current_Pos;

    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        //Mouse_Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //this.transform.position = Current_Pos;
        Copy_To_Do.transform.position = Current_Pos;
    }
}
