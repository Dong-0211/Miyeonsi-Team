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
    [SerializeField] RectTransform mRectTransform;
    [SerializeField] bool Drop_F;
    
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

        if (Drop_F)
        {
            if (Physics.Raycast(ray, out hit))
            {
                RectTransform Hit_rectTransform = hit.collider.gameObject.GetComponent<RectTransform>();
                mRectTransform.SetParent(Hit_rectTransform.parent.transform);
                mRectTransform.anchoredPosition = Hit_rectTransform.anchoredPosition;
                mRectTransform.sizeDelta = Hit_rectTransform.sizeDelta;

                mRectTransform.GetChild(0).gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(Hit_rectTransform.anchoredPosition.x, 0.0f);
            }
            else
            {
                Debug.Log("¿¿ æ»µ≈ µπæ∆∞°!");
                Destroy(this.gameObject);
            }
        }

        
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            Copy_To_Do = Instantiate(Work1);
            if (Copy_To_Do.GetComponent<DragNDrop>().Drop_F == false)
            {
                Drop_F = Copy_To_Do.GetComponent<DragNDrop>().Drop_F;
                Copy_To_Do.transform.SetParent(GameObject.Find("Canvas").transform);
                Copy_To_Do.GetComponent<Image>().color = new Color(1.0f, 0.0627f, 0.0627f, 1.0f);
            }
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
            Debug.Log("æ»µ 1!");
            return;
        }
        else if (eventData.button== PointerEventData.InputButton.Right)
        {
            Debug.Log("æ»µ 2!");
            return;
        }
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Current_Pos = new Vector3(eventData.position.x, eventData.position.y, -12.0f);
            Copy_To_Do.transform.position = Current_Pos;
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
            Debug.Log("æ»µ 1!");
            return;
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("æ»µ 2!");
            return;
        }
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Copy_To_Do.transform.position = Current_Pos;
            //DayBox_Function.To_do_Pos = Current_Pos;
            Copy_To_Do.GetComponent<DragNDrop>().Drop_F = true;
            Copy_To_Do.AddComponent<DropNDelete>();
            Destroy(Copy_To_Do.transform.GetChild(1).gameObject);
            Debug.Log("≈¨∏Ø ≥°!");
        }
        else if (eventData.button == PointerEventData.InputButton.Middle)
        {
            Debug.Log("æ»µ 1!");
            return;
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("æ»µ 2!");
            return;
        }
    }
}
