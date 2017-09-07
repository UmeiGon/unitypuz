using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxfunc : MonoBehaviour {
    float livetimer = 0;
    float tenmetuTimer=0;
    Color defcol;
	// Use this for initialization
	void Start () {
        defcol =GetComponent<MeshRenderer>().material.color;
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
                GetComponent<MeshRenderer>().material.color = defcol;
                tenmetuTimer = 0;
            }
            else if (tenmetuTimer > 0.1f)
            {

                GetComponent<MeshRenderer>().material.color=new Color(0,0,0,0f);
 
            }
            
        }
        
	}
}
