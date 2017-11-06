using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {
    public bool startOpened;
    public GameObject StartMenu;
    // Use this for initialization
    private void Awake()
    {
        startOpened = false;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        if (!startOpened)
        {
            Instantiate(StartMenu);
            startOpened = true;
        }

    }
}
