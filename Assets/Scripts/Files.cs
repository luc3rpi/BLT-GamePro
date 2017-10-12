using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Files : MonoBehaviour {
    public bool bookmarked;
    public bool mouseOver;
	// Use this for initialization
	void Start () {
        mouseOver = false;
        bookmarked = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1)&& mouseOver)
        {
            if (!bookmarked)
            {
                bookmarked = true;
                GameObject.FindGameObjectWithTag("Bookmark").GetComponent<Bookmarks>().fileBook.Add(gameObject);

            }
            else {
                bookmarked = false;
                GameObject.FindGameObjectWithTag("Bookmark").GetComponent<Bookmarks>().fileBook.Remove(gameObject);
            }
           
        }
	}
    private void OnMouseEnter()
    {
        mouseOver = true;
    }
    private void OnMouseExit()
    {
        mouseOver = false;
    }
}
