using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Document //class to store files
{
    public bool bookmarked;
    public Sprite thisSprite;
    public string keyword1;
    public string keyword2;
    public string keyword3;
    public string DocText;

    public Document(bool bm, Sprite sp, string kw1, string kw2, string kw3, string dt)
    {
        bookmarked = bm; thisSprite = sp; keyword1 = kw1;
        keyword2 = kw2; keyword3 = kw3; DocText = dt;
    }
}
public class Files : MonoBehaviour {

    public bool bookmarked;
    public Sprite thisSprite;
    public bool mouseOver;
    public string keyword1;
    public string keyword2;
    public string keyword3;
    public string DocText;
    Document doco;
	// Use this for initialization
	void Start () {
        mouseOver = false;
        bookmarked = false;
        thisSprite = gameObject.GetComponent<Sprite>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1)&& mouseOver)
        {
            if (!bookmarked)
            {
                bookmarked = true;
                doco = new Document(bookmarked, thisSprite, keyword1, keyword2, keyword3, DocText);
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Master>().fileBook.Add(doco);

            }
            else {
                bookmarked = false;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Master>().fileBook.Remove(doco);
                if (GameObject.FindGameObjectWithTag("Bookmarks")) {
                    GameObject.FindGameObjectWithTag("Bookmarks").GetComponent<Bookmarks>().spawnObjects(); //Remove file and reload remaining files if in bookmark folder
                }
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
