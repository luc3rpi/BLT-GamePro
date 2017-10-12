using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desktop : MonoBehaviour {
    GameObject startButton;
    // Use this for initialization
    private void Awake()
    {
        startButton = GameObject.FindGameObjectWithTag("StartButton");
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        if (startButton.GetComponent<StartButton>().startOpened) {
            Destroy(GameObject.FindGameObjectWithTag("StartMenu"));
            startButton.GetComponent<StartButton>().startOpened = false;
        }
    }
}
