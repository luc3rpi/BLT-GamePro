using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class SingleClick : MonoBehaviour, IPointerUpHandler
{
    //public GameObject eM;
    public string tagMatch;
    public Decryption d;
	public bool up;
	void Start(){
		d = GameObject.FindWithTag (tagMatch).GetComponent<Decryption>();
	}
	public void OnPointerUp (PointerEventData eventData) 
	{
        if (up)
            //eM.GetComponent<Decryption> ().scrollUp ();
            d.scrollUp();
        else
            //eM.GetComponent<Decryption> ().scrollDown ();
            d.scrollDown();
	}
}