using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Icon : MonoBehaviour, IPointerUpHandler {
	public GameObject window;
	public float xPos, yPos, wid, hei;
	GameObject go;
	public void OnPointerUp (PointerEventData eventData) 
	{
		//Debug.Log ("Click Count = "+eventData.clickCount);
		if(eventData.clickCount == 2){
			go = Instantiate (window, new Vector3 (xPos, yPos, 0), Quaternion.identity) as GameObject;
			go.transform.localScale = new Vector3 (wid, hei, 1);
			eventData.clickCount = 0;
		}
	}
}
