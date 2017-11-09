using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class Icon : MonoBehaviour, IPointerUpHandler {
	public GameObject window;
	public float xPos, yPos, wid, hei;
	public GameObject go;
    public int Desktop;
    public bool DesktopSwitcher;

	public void OnPointerUp (PointerEventData eventData) 
	{
		//Debug.Log ("Click Count = "+eventData.clickCount);
		if(eventData.clickCount == 1){
            if ( !go)
            {
                go = Instantiate(window, new Vector3(xPos, yPos, 0), Quaternion.identity) as GameObject;
                go.transform.localScale = new Vector3(wid, hei, 1);
                if (DesktopSwitcher) {
                    go.transform.GetChild(0).GetChild(Desktop).GetComponent<SpriteRenderer>().color = Color.red;
                }
                eventData.clickCount = 0;
            }
		}
	}
}
