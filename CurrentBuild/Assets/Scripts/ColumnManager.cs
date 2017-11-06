using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColumnManager : MonoBehaviour {
	public Text zero,one,two;
	public float scale,place,back;

	// Update is called once per frame
	/*void Update () {
		transform.localPosition = new Vector3 ((place - back)* scale, 0, 0);
	}*/
	public void Place(float p){
		transform.localPosition = new Vector3 ((p - .5f) * scale, 0, 0);
		transform.localScale = new Vector3 (1, 1, 1);
	}
	public void SetText(string a,string b,string c){
		zero.text = a;
		one.text = b;
		two.text = c;
	}
}
