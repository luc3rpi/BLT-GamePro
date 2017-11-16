using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Decryption : MonoBehaviour {
	public string pass;
	public string current;
	public float delay;
	public GameObject column;
	public bool active=true;
	public Text con;
	public MultiDimStr[] characters;
	string[] tempHold;
	//string[][] characters;
	// Use this for initialization
	void Start () {
		tempHold=new string[characters[0].strArray.Length];
		for (int c = 0; c < characters.Length; c++) {
			characters [c].col = Instantiate (column) as GameObject;
			//characters [c].col.transform.parent = GameObject.FindWithTag ("Canvas").transform;
			characters [c].col.transform.SetParent(GameObject.FindWithTag("MainCanvas").transform);
			characters [c].col.GetComponent<ColumnManager>().Place ((c*1.0f+.5f)/characters.Length);
			characters [c].col.GetComponent<ColumnManager>().SetText (characters[c].strArray[0],characters[c].strArray[1],characters[c].strArray[2]);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (active && pass==current) {
			active = false;
			Invoke ("Success", delay);
		}
	}

	void Success () {
		print ("Test");
		for(int c=0;c<characters.Length;c++)
			Destroy(characters[c].col.gameObject);
		con.text = "CONGRATULATIONS";
	}

	public void SendToCheck(){
		string[] send=new string[characters.Length];
		for (int c = 0; c < characters.Length; c++)
			send[c] = characters [c].strArray[1];
		Check (send);
	}

	void Check (string[] s){
		current = "";
		for (int c = 0; c < s.Length; c++)
			current += s [c];
		if (active && pass==current) {
			active = false;
			Invoke ("Success", delay);
		}
	}

	public void scrollDown(){
		if (active) {
			int st = Convert.ToInt32 (Math.Round (Input.mousePosition.x / Screen.width * characters.Length - 0.5));
			Array.Copy (characters [st].strArray, 0, tempHold, 0, characters [st].strArray.Length);
			characters [st].strArray [0] = tempHold [tempHold.Length - 1];
			for (int c = 1; c < tempHold.Length; c++)
				characters [st].strArray [c] = tempHold [c - 1];
			characters [st].col.GetComponent<ColumnManager> ().SetText (characters [st].strArray [0], characters [st].strArray [1], characters [st].strArray [2]);
			SendToCheck ();
		}
	}

	public void scrollUp(){
		if (active) {
			int st = Convert.ToInt32 (Math.Round (Input.mousePosition.x / Screen.width * characters.Length - 0.5));
			Array.Copy (characters [st].strArray, 0, tempHold, 0, characters [st].strArray.Length);
			characters [st].strArray [tempHold.Length - 1] = tempHold [0];
			for (int c = 0; c < tempHold.Length - 1; c++)
				characters [st].strArray [c] = tempHold [c + 1];
			characters [st].col.GetComponent<ColumnManager> ().SetText (characters [st].strArray [0], characters [st].strArray [1], characters [st].strArray [2]);
			SendToCheck ();
		}
	}

}

[System.Serializable]
public class MultiDimStr{
	public string[] strArray;
	public GameObject col;
}
