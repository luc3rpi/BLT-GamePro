using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class TimeDisplay : MonoBehaviour {
	public Text text;
	DateTime dt;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		dt = System.DateTime.Now;
		//text.text = dt.ToString ("HH:mm MM/dd/yyyy");
		text.text = dt.ToString ("g");
	}
}
