using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayBox_Function : MonoBehaviour
{
    public Vector2 To_do_Pos;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Work")
        {
            Debug.Log("잘 들어오네연");
        }
        Debug.Log("Collision detected with: " + collision.gameObject.name);
    }
}
