using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class erebe_ta : MonoBehaviour
{
    public float startY;
    public float endY;
    public float speed;
    private bool up;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (up)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
            if(transform.localPosition.y >= endY)
            {
                transform.localPosition = new Vector3(0, endY-0.01f, 0);
                up = false;
            }
        }
        else
        {
            transform.Translate(0, Time.deltaTime * -speed, 0);
            if (transform.localPosition.y <= startY)
            {
                transform.localPosition=new Vector3(0,startY+0.01f,0);
                up = true;
            }
        }

    }
}
