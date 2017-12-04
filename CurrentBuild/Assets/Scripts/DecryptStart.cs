using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DecryptStart : MonoBehaviour, IPointerUpHandler {

    public string pass;
    public string tg = "MainCanvas";
    public Decryption dec;
    public MultiDimStr[] chars;
    public GameObject window;
    public float xPos, yPos, wid, hei;
    public GameObject go;
    public int Desktop;
    public int location;
    public bool DesktopSwitcher;
    //Files fls;
    bool done=false;

    public void OnPointerUp(PointerEventData eventData)
    {
        if (!done)
        {
            dec.pass = pass;
            dec.characters = chars;
            dec.enabled = true;
        }
        else if (eventData.clickCount == 1)
        {
            if (!go)
            {
                switch (Desktop)
                {
                    case 3:
                        location = 0;
                        break;
                    case 2:
                        location = 1;
                        break;
                    case 1:
                        location = 2;
                        break;
                    case 0:
                        location = 3;
                        break;
                    default:
                        location = 0;
                        break;
                }
                go = Instantiate(window, new Vector3(xPos + 40 * location, yPos, -2), Quaternion.identity) as GameObject;
                go.transform.localScale = new Vector3(wid, hei, 1);
                if (go.tag == "StartMenu")
                {
                    go.transform.GetChild(0).Find("QuitGame").gameObject.GetComponent<StartButton>().deskNum = location;
                }
                if (DesktopSwitcher)
                {
                    go.transform.GetChild(0).GetChild(Desktop).GetComponent<SpriteRenderer>().color = Color.red;
                }
                if (GetComponent<Files>() != null)
                {
                    if (GetComponent<Files>().textFile == true)
                    {
                        go.transform.Find("Canvas").transform.Find("Text").GetComponent<Text>().text = GetComponent<Files>().DocText;
                    }
                    else if (GetComponent<Files>().imageFile == true)
                    {
                        //print("NO");
                        go.GetComponentInChildren<SpriteRenderer>().sprite = GetComponent<Files>().Picture;
                    }
                }
                eventData.clickCount = 0;
            }
        }
    }

	// Use this for initialization
	void Start () {
        dec = GameObject.FindGameObjectWithTag(tg).GetComponent<Decryption>();
        //fls = GetComponent<Files>();
	}
	
	// Update is called once per frame
	void Update () {
        if (dec.enabled && dec.active==false)
        {
            done = true;
        }
	}

}
