using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;
//I know it's a kind of weird name.
public class SingleClick : MonoBehaviour, IPointerUpHandler
{
	public GameObject eM;
	public bool up;
	void Start(){
		//Make sure to put "Decrpytion" tag on GameObject with the Decryption script.
		eM = GameObject.FindWithTag ("Decryption");
	}
	public void OnPointerUp (PointerEventData eventData) 
	{
		if(up)
			eM.GetComponent<Decryption> ().scrollUp ();
		else
			eM.GetComponent<Decryption> ().scrollDown ();
	}
}
