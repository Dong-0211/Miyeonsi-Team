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
            return;
        }
        Exit_Window.alpha = 1.0f;
    }

    public void Window_Off()
    {
        Exit_Window.alpha = 0.0f;

    }

}
