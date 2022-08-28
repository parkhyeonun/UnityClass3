using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    float rotSpeed = 0;
    float v3 = 0;
    bool bsw = true;

    // Start is called before the first frame update
    void Start()
    {

        


    }

    // Update is called once per frame
    void Update()
    {
        //클릭하면 회전 
        if (Input.GetMouseButtonDown(0))
        {
            bsw = true;
            rotSpeed = 10;
        }

        rotSpeed *= 0.98f;

        gameObject.transform.Rotate(0,0,rotSpeed);

        //멈췄을때 
        if( rotSpeed < 0.001f && bsw)
        {
            v3 =  gameObject.transform.eulerAngles.z;
            bsw = false;

            if (v3 >= -30 && v3 <= 30)
            {
                Debug.Log("운수나쁨");
            }
            else if(v3 >= 30 && v3 <= 90)
            {
                Debug.Log("운수대통");
            }
            else if (v3 >= 90 && v3 <= 150)
            {
                Debug.Log("운수매우나쁨");
            }
            else if (v3 >= 150 && v3 <= 210)
            {
                Debug.Log("운수보통");
            }
            else if (v3 >= 210 && v3 <= 270)
            {
                Debug.Log("운수조심");
            }
            else if (v3 >= 270 && v3 <= 330)
            {
                Debug.Log("운수좋음");
            }
        }

    }
}
