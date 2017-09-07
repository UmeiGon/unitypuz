using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour {
    
    public int horusuu = 3;
   private int maxhorusuu;
    public const int BLUE = 0;
    public const int GREEN = 1;
    public const int RED = 2;
    public int nowCube;
    public int[] hakosuu=new int[3];
    public Text[] txt=new Text[3];
    private GameObject[] Ores;
    public Text horutxt;
    public Slider horubar;
    public GameObject cursor;
    public GameObject player;
    private GameObject horuOre;
    public GameObject clearImg;
    // Use this for initialization
    void Start () {
        maxhorusuu = horusuu;
        Ores = GameObject.FindGameObjectsWithTag("ore");
    }
	
	// Update is called once per frame
	void Update () {
        //123キーで設置するブロックを洗濯。
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            nowCube = BLUE;
            cursor.GetComponent<RectTransform>().localPosition = new Vector3(-65, -3.5f, 0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            nowCube = GREEN;
            cursor.GetComponent<RectTransform>().localPosition = new Vector3(19,-3.5f,0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            nowCube = RED;
            cursor.GetComponent<RectTransform>().localPosition = new Vector3(102,-3.5f,0);
        }
        if (Input.GetKeyDown(KeyCode.E)&&horusuu>0)
        {
            for(int i = 0; i < Ores.Length; i++)
            {
                if (Ores[i]&&(player.transform.position - Ores[i].transform.position).magnitude < 8.5f)
                {
                    horuOre = Ores[i];
                    PlayerMove pm = player.GetComponent<PlayerMove>();
                    pm.eisyo = true;
                    pm.child.transform.LookAt(new Vector3(horuOre.transform.position.x,pm.child.transform.position.y,horuOre.transform.position.z));
                }
            }
        }
    
        if (player.GetComponent<PlayerMove>().eisyo)
        {
            if(!((player.transform.position - horuOre.transform.position).magnitude < 8.5f)){
                player.GetComponent<PlayerMove>().eisyo = false;
            }
            if (player.GetComponent<PlayerMove>().eisyoTimer>=1.0f)
            {
                hakosuu[horuOre.GetComponent<getHako>().tag]++;
                horuOre.GetComponent<getHako>().zansu--;
                horusuu--;
                player.GetComponent<PlayerMove>().eisyo = false;
            }
        }
        horutxt.text = horusuu + "/" + maxhorusuu;
        horubar.value = (float)horusuu / (float)maxhorusuu;
        txt[BLUE].text= "x"+hakosuu[BLUE].ToString();
        txt[GREEN].text = "x" + hakosuu[GREEN].ToString();
        txt[RED].text = "x" + hakosuu[RED].ToString();

        if (clearImg.activeSelf&&Input.GetKeyDown(KeyCode.Return))
        {
            GetComponent<scenemanager>().OnClick(0);
        }
	}

}
