using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropNDelete : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            Destroy(this.gameObject);
        }
    }

}
