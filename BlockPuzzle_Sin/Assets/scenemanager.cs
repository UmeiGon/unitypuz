using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanager : MonoBehaviour {
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnClick(int stagetype)
    {
        switch (stagetype)
        {
            case 0:
                SceneManager.LoadScene("Title");
                break;
            case 1:
                SceneManager.LoadScene("stage1");
                break;
            case 2:
                SceneManager.LoadScene("stage2");
                break;
            case 3:
                SceneManager.LoadScene("stage3");
                break;
        }

    }
}
