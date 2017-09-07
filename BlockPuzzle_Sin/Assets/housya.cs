using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class housya : MonoBehaviour {
    private GameObject tama;
    public float speed=20.0f;
    public float deathtime=5.0f;
    public float atktime=2.0f;
    private float Atktimer;
	// Use this for initialization
	void Start () {
        tama = (GameObject)Resources.Load("prefab/houdan");
	}
	
	// Update is called once per frame
	void Update () {
        Atktimer += Time.deltaTime;
        if (Atktimer > atktime)
        {
            GameObject a=Instantiate(tama, transform);
            a.GetComponent<zikai>().speed = speed;
            a.GetComponent<zikai>().deathtime = deathtime;
            Atktimer = 0;
        }
	}
}
