using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMousePosition : MonoBehaviour
{
    private float objRotateX;
    private static int width = Screen.width;
    private static int height = Screen.height;

    private void Start()
    {
        objRotateX = transform.localEulerAngles.x;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationY;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
    }

    void OnMouseDrag()
    {
        Vector3 objPos = Camera.main.WorldToScreenPoint(transform.position);

        double x = (double)Input.mousePosition.x;
        double y = (double)Input.mousePosition.y;
        int radius = (int)Math.Floor(265 * (height/600f));
        
        if (y < height / 2 && Math.Pow(x - width/2, 2) + Math.Pow(y - height/2, 2) < Math.Pow(radius,2)) {    // 下半分かつスタジアム内
            Vector3 mousePos = new Vector3((float)x, (float)y, 180);          // 180 = カメラ位置(250) - 表示したい位置(70)
            transform.position = Camera.main.ScreenToWorldPoint(mousePos);
        }
    }

    private void Update()
    {
        float wheelValue = Input.GetAxis("Mouse ScrollWheel");

        if (wheelValue == 0)
        {
            return;
        }

        objRotateX += wheelValue;

        transform.rotation = Quaternion.Euler(objRotateX, 0f, 0f);
    }
}
