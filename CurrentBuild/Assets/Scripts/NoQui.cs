using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoQui : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        Destroy(transform.parent.gameObject);
    }
}
