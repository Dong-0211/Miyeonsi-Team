using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MonitorSceneMove()
    {
        SceneManager.LoadScene("Monitor_Screen");
    }

    public void Album_SceneMove()
    {
        SceneManager.LoadScene("Album_Scene");
    }

    public void Calendar_SceneMove()
    {
        SceneManager.LoadScene("Calendar_Scene");
    }

    public void Messenger_SceneMove()
    {
        SceneManager.LoadScene("Messenger_Scene");
    }

    public void Broadcast_SceneMove()
    {
        SceneManager.LoadScene("Broadcast_Scene");
    }

    public void Stock_SceneMove()
    {
        SceneManager.LoadScene("Stock_Scene");
    }

    public void MyPC_SceneMove()
    {
        SceneManager.LoadScene("MyPC_Scene");
    }

    public void TitleScenesMove()
    {
        SceneManager.LoadScene("TitleScenes");
    }

    public void StoryScenesMove()
    {
        SceneManager.LoadScene("Story_Scene");
    }
}
