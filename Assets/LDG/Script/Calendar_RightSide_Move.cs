using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar_RightSide_Move : MonoBehaviour
{
    [SerializeField] GameObject Second_Background;

    [SerializeField] Vector3 Start_Pos;
    [SerializeField] Vector3 End_Pos;
    [SerializeField] bool RightSideOn;
    [SerializeField] float Move_Duration;
    [SerializeField] float MoveTimer;
    // Start is called before the first frame update
    void Start()
    {
        Second_Background = this.transform.GetChild(0).gameObject;

        Start_Pos = new Vector3(Second_Background.transform.localPosition.x, Second_Background.transform.localPosition.y, 0.0f); 

        End_Pos = new Vector3(383.0f, -22.0f, 0.0f);
        RightSideOn = false;

        Move_Duration = 0.5f;
        MoveTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (RightSideOn)
        {
            if (MoveTimer < Move_Duration)
            {
                MoveTimer += Time.deltaTime;
                float Left_Time = MoveTimer / Move_Duration;
                Second_Background.transform.localPosition = Vector3.Lerp(Start_Pos, End_Pos, Left_Time);
            }

            if (Vector3.Distance(Second_Background.transform.localPosition, End_Pos) < 0.01f)
            {
                RightSideOn = false;
                MoveTimer = 0.0f;
            }
        }
    }

    public void RightSide_Toggle()
    {
        RightSideOn = !RightSideOn;
    }
}
