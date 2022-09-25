using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;


    private void LateUpdate()
    {
        if (target == null)
            return;

        transform.position = new Vector3(target.position.x + 2, transform.position.y, transform.position.z);
    }
}
