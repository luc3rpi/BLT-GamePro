using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desktop : MonoBehaviour {
    GameObject startButton;
    public bool locked;
    public AudioClip Bing;
    // Use this for initialization
    private void Awake()
    {
        locked = false;
        startButton = GameObject.FindGameObjectWithTag("StartButton");
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        if (locked) {

            GetComponent<AudioSource>().PlayOneShot(Bing);

        }
        else if (startButton.GetComponent<StartButton>().startOpened) {
            Destroy(GameObject.FindGameObjectWithTag("StartMenu"));
            startButton.GetComponent<StartButton>().startOpened = false;
        }
    }
}
