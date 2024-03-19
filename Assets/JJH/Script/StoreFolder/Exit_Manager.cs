using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_Manager : MonoBehaviour
{
    private CanvasGroup Exit_Window;
    // Start is called before the first frame update
    void Start()
    {
        Exit_Window = transform.Find("Exit_Window").gameObject.GetComponent<CanvasGroup>();
    }

    public void Window_On()
    {
        if(Exit_Window.alpha == 1.0f)
        {
            Exit_Window.alpha = 0.0f;
            Exit_Window.interactable = false;
            Exit_Window.blocksRaycasts = false;
            return;
        }
        Exit_Window.alpha = 1.0f;
        Exit_Window.interactable = true;
        Exit_Window.blocksRaycasts = true;
    }

    public void Window_Off()
    {
        Exit_Window.alpha = 0.0f;
        Exit_Window.interactable = false;
        Exit_Window.blocksRaycasts = false;
    }

}
