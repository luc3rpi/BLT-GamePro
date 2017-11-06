using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class SingleClick : MonoBehaviour, IPointerUpHandler
{
	public GameObject eM;
	public bool up;
	void Start(){
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