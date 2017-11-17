using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour {
    public bool startOpened;
    public GameObject StartMenu;
    public int deskNum;
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
            StartMenu = Instantiate(StartMenu);
            StartMenu.transform.position = new Vector3(StartMenu.transform.position.x +40*deskNum, StartMenu.transform.position.y, StartMenu.transform.position.z);
            startOpened = true;
        }

    }
}
