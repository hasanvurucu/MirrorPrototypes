using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCylinder : MonoBehaviour
{
    private Vector2 mouseFirstPos;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mouseFirstPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            Quaternion rot = gameObject.transform.rotation;
            rot.y = (mouseFirstPos.x - Input.mousePosition.x)/100;
            gameObject.transform.rotation = rot;
        }
    }
}
