using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform tuizyuObj;
    private Vector3 offset;
    private Vector3 tanioffset;
    private Transform childCamera;
    void Start()
    {
        childCamera = transform.Find("Main Camera");
        offset = transform.position - childCamera.transform.position;
        tanioffset = offset;
        Vector3.Normalize(tanioffset);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Mouse1))
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * Time.deltaTime * 120f, 0);
        }
        float wheel = Input.GetAxis("Mouse ScrollWheel");
        Vector3 a = transform.position;
        Vector3 b = childCamera.transform.position;
        a.y = 0;
        b.y = 0;
        float dis = Vector3.Distance(a, b);
        if (!(dis<35&&wheel>0)&&!(dis>50&&wheel<0))
        {
            childCamera.transform.Translate(0, 0, wheel * Time.deltaTime * 5000);
        }

        transform.position = tuizyuObj.position;
    }
}
