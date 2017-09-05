using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxfunc : MonoBehaviour {
    float livetimer = 0;
    float tenmetuTimer=0;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        livetimer += Time.deltaTime;
        tenmetuTimer += Time.deltaTime;
        if (3 < livetimer)
        {
            Destroy(transform.parent.gameObject);
        }
        else if (2 < livetimer)
        {
            if (tenmetuTimer > 0.15f)
            {
                Color alp = GetComponent<Renderer>().material.color;
                alp.a = 255;
                GetComponent<Renderer>().material.color = alp;
                tenmetuTimer = 0;
            }
            else if (tenmetuTimer > 0.1f)
            {
                Color alp = GetComponent<Renderer>().material.color;
                alp.a = 0;
                GetComponent<Renderer>().material.color=alp;
 
            }
            
        }
        
	}
}
