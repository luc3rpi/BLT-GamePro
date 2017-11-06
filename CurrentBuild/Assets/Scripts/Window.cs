using UnityEngine;
using System.Collections;

public class Window : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//Called by button attached to canvas attached to window
	public void X(){
		Destroy (gameObject);
	}
}
