using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {
    public bool ContinueGame;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        if (ContinueGame)
        {
            if (Directory.Exists(Application.dataPath + "/saves")) {
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SaveLoad>().Load();
            }
        }
        GameObject.FindGameObjectWithTag("MainCamera").transform.position = new Vector3(0, 0, -10);
    }
}
