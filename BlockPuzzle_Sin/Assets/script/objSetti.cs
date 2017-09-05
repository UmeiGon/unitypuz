using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objSetti : MonoBehaviour {

    GameObject blueCube;
    public gamemanager gm;
	// Use this for initialization
	void Start () {
        blueCube = (GameObject)Resources.Load("prefab/BlueCube", typeof(GameObject));

    }
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Input.GetKeyDown(KeyCode.Mouse0)&&gm.bluehako>0&&Physics.Raycast(ray,out hit, 100))
        {
            gm.bluehako--;
            GameObject a = Instantiate(blueCube);
            a.transform.position = hit.point;
        }
	}
}
