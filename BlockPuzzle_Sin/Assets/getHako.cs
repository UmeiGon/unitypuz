using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getHako : MonoBehaviour {
    GameObject player;
    gamemanager gm;
    public int zansu;
    public float getdis;
    public int tag;
	// Use this for initialization
	void Start () {
        gm = GameObject.Find("GameManager").GetComponent<gamemanager>();
        player = GameObject.Find("Player");	
	}
	
	// Update is called once per frame
	void Update () {
        float distance = (transform.position - player.transform.position).sqrMagnitude;
        if (Input.GetKeyDown(KeyCode.E)&&gm.horusuu>0&&distance < getdis*getdis)
        {
            switch (tag)
            {
                case 0:
                    gm.bluehako++;
                    break;
                case 1:
                    gm.redhako++;
                    break;
                case 2:
                    gm.greenhako++;
                    break;
            }
            zansu--;
            gm.horusuu--;
            if (zansu <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
