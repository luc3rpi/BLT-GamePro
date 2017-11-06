using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bookmarks : MonoBehaviour {
    public List<Document> fileBook;
    public List<GameObject> baseFile;
    public GameObject file;
    // Use this for initialization
    private void Awake()
    {
        fileBook = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Master>().fileBook; //get master list
    }
    void Start () {
        spawnObjects();
	}
	
	// Update is called once per frame
	void Update () {

	}
   public void spawnObjects() {
        foreach (GameObject j in baseFile) {
            Destroy(j.gameObject);
        }
        foreach (Document i in fileBook) //Spawn each bookmarked file in folder Once I have folder size i can put them in right positions
        {
            GameObject gb = Instantiate(file);
            gb.transform.parent = this.transform;
            gb.GetComponent<Files>().bookmarked = i.bookmarked;
            gb.GetComponent<Files>().DocText = i.DocText;
            gb.GetComponent<Files>().thisSprite = i.thisSprite;
            gb.GetComponent<Files>().keyword1 = i.keyword1;
            gb.GetComponent<Files>().keyword2 = i.keyword2;
            gb.GetComponent<Files>().keyword3 = i.keyword3;
            gb.GetComponent<SpriteRenderer>().sprite = gb.GetComponent<Files>().thisSprite;
            baseFile.Add(gb);
        }
    }
}
