using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide_UI : MonoBehaviour
{
    private GameObject[] Hide_UIs = new GameObject[2];
    private bool flags;
    
    void Start()
    {
        flags = false;
        Hide_UIs[0] = GameObject.Find("SpriteCanvas");
        Hide_UIs[1] = GameObject.Find("Dialogue System_Copy");

        foreach( GameObject i in Hide_UIs)
        {
            if (i == null)
            {
                Debug.Log("숨길 UI오브젝트를 찾지 못했습니다.");
                return;
            }
        }
    }

    void Update()
    {
        PressRightMouse();
    }

    private void PressRightMouse()
    {
        Transform tmp_canvas = Hide_UIs[1].transform.GetChild(0);
        Transform tmp_Button = Hide_UIs[0].transform.GetChild(2);
        if (Input.GetMouseButtonDown(1))
        {
            flags = true;
            for(int i = 0; i < 3; i++)
            {
                GameObject Canvas_Child = tmp_canvas.transform.GetChild(i).gameObject;
                if (Canvas_Child.activeSelf==true)
                {
                    Canvas_Child.SetActive(false);
                }
            }
            if (tmp_Button.gameObject.activeSelf == true)
            {
                tmp_Button.gameObject.SetActive(false);
            }
        }
        if (Input.GetMouseButtonDown(0) && flags==true)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject Canvas_Child = tmp_canvas.transform.GetChild(i).gameObject;
                if (Canvas_Child.activeSelf == false)
                {
                    Canvas_Child.SetActive(true);
                }
            }
            if (tmp_Button.gameObject.activeSelf == false)
            {
                tmp_Button.gameObject.SetActive(true);
            }
            flags = false;
        }
    }
}
