using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour {
    public List<Document> fileBook; //master list
    public int[] desktops;  
    // Use this for initialization
    private void Awake()
    {
        fileBook = new List<Document>();
        desktops = new int[4];
        desktops[0] = 0; desktops[1] = 0; desktops[2] = 0; desktops[3] = 0;
    }
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
