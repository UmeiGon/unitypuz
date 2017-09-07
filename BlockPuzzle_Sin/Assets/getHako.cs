using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getHako : MonoBehaviour
{
    gamemanager gm;
    public int zansu;
    public int tag;
    // Use this for initialization
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<gamemanager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (zansu <= 0)
        {
            Destroy(gameObject);
        }

    }
}
