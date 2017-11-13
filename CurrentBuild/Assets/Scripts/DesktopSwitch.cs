using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopSwitch : MonoBehaviour {
    public Vector3 desktopLocation;
    public BoxCollider2D colid;
    public SpriteRenderer sprite;
    public int thisNumber;
	// Use this for initialization
	void Start () {
        colid = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
	}
    private void FixedUpdate()
    {

        if (!(thisNumber == 3) && GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Master>().desktops[thisNumber] == 0)
        {
            colid.enabled = false;
            sprite.enabled = false;
        }
        else
        {
            colid.enabled = true;
            sprite.enabled = true;
        }
    }

    private void OnMouseDown()
    {
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>().position = desktopLocation;
        Destroy(transform.parent.transform.parent.GetChild(1).gameObject);
        Destroy(transform.parent.transform.parent.gameObject);
    }
}
