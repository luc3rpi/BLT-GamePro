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
    public bool uploadMode = false;
    public Document(bool bm, Sprite sp, string kw1, string kw2, string kw3, string dt)
    {
        bookmarked = bm; thisSprite = sp; keyword1 = kw1;
        keyword2 = kw2; keyword3 = kw3; DocText = dt;
    }
}
public class Files : MonoBehaviour {

    public GameObject cam;
    public bool bookmarked;
    public Sprite thisSprite;
    public bool mouseOver;
    public string keyword1;
    public string keyword2;
    public string keyword3;
    public string DocText;
    public bool uploadMode;
    public bool uploading;
    public bool textFile;
    public bool imageFile;
    public int desktopNumber;
    public string CodeName;
    public string FileName;
    public Sprite Picture;
    public Dictionary<string, string[]> DocumentsToPullFrom;
    Document doco;
	// Use this for initialization
	void Start () {
        DocText = null;
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        if (textFile) {
            if (desktopNumber == 2)
            {
                DocumentsToPullFrom = cam.GetComponent<Master>().dataOld;
            }
            else if (desktopNumber == 1)
            {
                DocumentsToPullFrom = cam.GetComponent<Master>().dataJaz;
            }
            else if (desktopNumber == 0) {
                DocumentsToPullFrom = cam.GetComponent<Master>().dataJournalist;
            }
            DocText = DocumentsToPullFrom[CodeName][5];
            FileName = DocumentsToPullFrom[CodeName][2];
        }
        uploading = false;
        mouseOver = false;
        if (!(transform.parent.tag == "Bookmarks")) bookmarked = false;
        thisSprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        uploadMode = false;
        doco = new Document(bookmarked, thisSprite, keyword1, keyword2, keyword3, DocText);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1)&& mouseOver)
        {
            if (!uploadMode)
            {
                if (!bookmarked)
                {
                    bookmarked = true;
                    cam.GetComponent<Master>().fileBook.Add(doco);

                }
                else
                {
                    bookmarked = false;
                    cam.GetComponent<Master>().fileBook.Remove(doco);
                    if (GameObject.FindGameObjectWithTag("Bookmarks"))
                    {
                        GameObject.FindGameObjectWithTag("Bookmarks").GetComponent<Bookmarks>().spawnObjects(); //Remove file and reload remaining files if in bookmark folder
                    }
                }
            }
            else {
                if (!uploading)
                {
                    GameObject.FindGameObjectWithTag("Upload").GetComponent<UploadFiles>().uploading.Add(doco);
                    GetComponent<Renderer>().material.color = Color.green;
                    uploading = true;
                }
                else {
                    GameObject.FindGameObjectWithTag("Upload").GetComponent<UploadFiles>().uploading.Remove(doco);
                    GetComponent<Renderer>().material.color = Color.white;
                    uploading = false;

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
