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
    [SerializeField] GameObject Final_Work;
    [SerializeField] RectTransform mRectTransform;
    [SerializeField] bool Drop_F;
    [SerializeField] string Click_Work_Name;
    [SerializeField] string Drop_Box_Name;

    Ray ray;
    RaycastHit hit;

    [SerializeField] float RaySize = 100.0f;

    void Start()
    {
        mRectTransform = GetComponent<RectTransform>();
        Click_Work_Name = this.gameObject.name;
    }

    void Update()
    {
        ray = new Ray(transform.position, transform.forward * RaySize);
        Debug.DrawRay(transform.position, transform.forward * RaySize, Color.yellow);

        if (Drop_F == true) 
        {
            if (Physics.Raycast(ray, out hit))
            {
                RectTransform Hit_rectTransform = hit.collider.gameObject.GetComponent<RectTransform>();
                //Debug.Log("∫Œµ˙ƒ£ ø…¡ß¿Ã∏ß : " + hit.collider.gameObject.name);
                Drop_Box_Name = hit.collider.gameObject.name;

                Set_Work(Drop_Box_Name, Hit_rectTransform);

                mRectTransform.GetChild(0).gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
                mRectTransform.GetChild(0).gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(104.0f, 26.0f);

                //this.GetComponent<DragNDrop>().enabled = false;
                Destroy(this.GetComponent<DragNDrop>());
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
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Click_Work_Name = eventData.pointerDrag.name;
            //Debug.Log("≈¨∏Ø«— ¿Ã∏ß¿∫ : " + Click_Work_Name);
            GameObject final_Work = Resources.Load<GameObject>("Prefab/" + Click_Work_Name);

            Copy_To_Do = Instantiate(final_Work);
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
            Copy_To_Do.GetComponent<DragNDrop>().Drop_F = true;
            Copy_To_Do.AddComponent<DropNDelete>();
            Copy_To_Do.GetComponent<BoxCollider2D>().size = new Vector2(95.0f, 26.0f); 
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

    void Set_Work(string Hit_box, RectTransform hitRect)
    {
        //if (hitRect.parent.childCount > 3)
        //{
        //    Debug.Log("¿¿ æ»µ≈ µπæ∆∞•!!!!!!!!!!!!!!!!");
        //    Destroy(this.gameObject);
        //}
        if (Hit_box == "Box1" && Click_Work_Name == "Convenience_Work(Clone)")
        {
            mRectTransform.SetParent(hitRect.transform);
            mRectTransform.anchoredPosition = new Vector2( 59.0f, 0.0f);
            mRectTransform.sizeDelta = new Vector2(213.0f, hitRect.sizeDelta.y);
        }
        else if (Hit_box == "Box2" && Click_Work_Name == "PC_Work(Clone)")
        {
            mRectTransform.SetParent(hitRect.transform);
            mRectTransform.anchoredPosition = new Vector2(0.0f, -13.8f);
            mRectTransform.sizeDelta = new Vector2(hitRect.sizeDelta.x, 53.5f);
        }
        else if (Hit_box == "Box2" && Click_Work_Name == "LAU_Work(Clone)")
        {
            mRectTransform.SetParent(hitRect.transform);
            mRectTransform.anchoredPosition = new Vector2(0.0f, 0.0f);
            mRectTransform.sizeDelta = hitRect.sizeDelta;
        }
        else if (Hit_box == "Box3" && Click_Work_Name == "Movie_Work(Clone)") 
        {
            mRectTransform.SetParent(hitRect.transform);
            mRectTransform.anchoredPosition = new Vector2(59.0f, 0.0f);
            mRectTransform.sizeDelta = new Vector2(213.0f, hitRect.sizeDelta.y);
        }
        else if(Hit_box == "Box1" && Click_Work_Name == "FoodDelivery_Work(Clone)")
        {
            mRectTransform.SetParent(hitRect.transform);
            mRectTransform.anchoredPosition = new Vector2(0.0f, 0.0f);
            mRectTransform.sizeDelta = hitRect.sizeDelta;
        }
        else
        {
            Debug.Log("¿¿ æ»µ≈ µπæ∆∞°22");
            Destroy(this.gameObject);
        }
    }
}
