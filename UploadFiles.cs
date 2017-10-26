using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UploadFiles : MonoBehaviour {
    bool mouseOver;
    public bool uploadMode;
    public GameObject mainCam;
    public List<Document> uploading;
	// Use this for initialization
	void Start () {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera");

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)&& mouseOver) {
            if (!uploadMode)
            {
                uploading.Clear();
                foreach (Document i in mainCam.GetComponent<Master>().fileBook)
                {
                    i.uploadMode = true;
                }
                if (GameObject.FindGameObjectWithTag("Bookmarks"))
                {
                    GameObject.FindGameObjectWithTag("Bookmarks").GetComponent<Bookmarks>().spawnObjects();
                }
            }
            else {
                if (uploading.Count > 0) //see if uploading is empty  In the future add cancel button
                {
                    //Analyze keywords and perform action according to writers.
                }
                else {
                    uploadMode = false;
                }
            }
        }
	}

    private void OnMouseEnter()
    {
        mouseOver = true;
    }
    private void OnMouseExit()
    {
        mouseOver = false;
    }
}
