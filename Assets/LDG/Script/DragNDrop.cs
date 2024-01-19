using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragNDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    //[SerializeField] Vector2 Default_Pos;
    [SerializeField] Vector3 Current_Pos;
    [SerializeField] GameObject Copy_To_Do;
    [SerializeField] GameObject Work1;
    [SerializeField] bool Drop_F;
    [SerializeField] RectTransform mRectTransform;

    DayBox_Function DayBox_Function;

    Ray ray;
    RaycastHit hit;

    [SerializeField] float RaySize =100.0f;

    void Start()
    {
        Work1 = Resources.Load<GameObject>("Prefab/Work1");
        mRectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        ray = new Ray(transform.position, transform.forward * RaySize);
        Debug.DrawRay(transform.position, transform.forward * RaySize, Color.yellow);

        if(Physics.Raycast(ray, out hit))
        {
            mRectTransform.sizeDelta = new Vector2(mRectTransform.sizeDelta.x, 25.0f);
        }

        
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
        //Current_Pos = eventData.position;
        Current_Pos = new Vector3(eventData.position.x, eventData.position.y, -12.0f);
        Copy_To_Do.transform.position = Current_Pos;

    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Copy_To_Do.transform.position = Current_Pos;
        //DayBox_Function.To_do_Pos = Current_Pos;
        Drop_F = true;
    }

    
}
