using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gamemanager : MonoBehaviour {
    public int bluehako=0;
    public int redhako = 0;
    public int greenhako = 0;
    public int horusuu = 3;
    public Text txt;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        txt.text = "x"+bluehako.ToString();
	}
}
