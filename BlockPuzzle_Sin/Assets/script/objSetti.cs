using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objSetti : MonoBehaviour
{
    GameObject[] Cube = new GameObject[3];  
    
    public gamemanager gm;
    // Use this for initialization
    void Start()
    {
        
        Cube[0] = (GameObject)Resources.Load("prefab/BlueCube", typeof(GameObject));
        Cube[1] = (GameObject)Resources.Load("prefab/GreenCube", typeof(GameObject));
        Cube[2] = (GameObject)Resources.Load("prefab/RedCube", typeof(GameObject));
    }

    // Update is called once per frame
    void Update()
    {
       
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Input.GetKeyDown(KeyCode.Mouse0) && gm.hakosuu[gm.nowCube] > 0 && Physics.Raycast(ray, out hit, 100))
        {
            gm.player.GetComponent<PlayerMove>().eisyoTimer = 1.0f;
            gm.hakosuu[gm.nowCube]--;
            GameObject a = Instantiate(Cube[gm.nowCube]);
            a.transform.position = hit.point;
            if (gm.nowCube == 2)
            {
                a.transform.rotation= gm.player.transform.rotation;
                a.transform.Rotate(new Vector3(0,1,0), 90);
            }
        }

    }


}
