using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropNDelete : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            Destroy(this.gameObject);
            Debug.Log("삭제!");
        }
    }

    //void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    //{


    //    if (eventData.button == PointerEventData.InputButton.Right)
    //    {
    //        Destroy(this.gameObject);
    //        Debug.Log("삭제!");
    //    }
    //}

}
