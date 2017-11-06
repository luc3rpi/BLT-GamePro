using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoQuit : MonoBehaviour {
    public GameObject Wallpaper;
	// Use this for initialization
	void Start () {
        Wallpaper = GameObject.FindGameObjectWithTag("Wallpaper");
        Wallpaper.GetComponent<Desktop>().locked = true;
        if (GameObject.FindGameObjectWithTag("QuitButton"))
        {
            GameObject.FindGameObjectWithTag("QuitButton").GetComponent<StartButton>().startOpened = true;
        }	
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnMouseDown()
    {
        if   ( GameObject.FindGameObjectWithTag("QuitButton")){
            GameObject.FindGameObjectWithTag("QuitButton").GetComponent<StartButton>().startOpened = false;
        }
        Wallpaper.GetComponent<Desktop>().locked = false;
        Destroy(transform.parent.gameObject);
    }
}
