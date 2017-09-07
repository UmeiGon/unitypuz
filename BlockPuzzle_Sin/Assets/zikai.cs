using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zikai : MonoBehaviour {
    private float deathtimer;
    public float deathtime;
    public float speed=20.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        deathtimer += Time.deltaTime;
        if (deathtimer > deathtime)
        {
            Destroy(gameObject);
        }
        transform.Translate(0, 0, speed * Time.deltaTime);
	}
}
