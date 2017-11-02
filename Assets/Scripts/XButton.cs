using UnityEngine;
using System.Collections;

public class XButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick(){
		Destroy (transform.parent.gameObject);
	}
}
