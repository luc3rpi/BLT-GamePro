using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour {
    public List<Document> fileBook; //master list
    public bool[] desktops;

    //public TextAsset OldManFolders;
    public List<Dictionary<string, object>> dataOld;
    public List<Dictionary<string, object>> dataJournalist;
    public List<Dictionary<string, object>> dataJaz;

    private void Awake()
    {
        dataOld = CSVReader.Read("OldManFolders");
     //   dataJaz = CSVReader.Read("TechGuyFolders");
    //    dataJournalist = CSVReader.Read("JournalistFolders");
        fileBook = new List<Document>();
        desktops = new bool[4];
        desktops[0] = true; desktops[1] = false; desktops[2] = false; desktops[3] = false;
    }
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    static int SortByKey(Dictionary<string, object> a, Dictionary<string, object> b) {
        return a["Codename"].ToString().CompareTo(b["Codename"].ToString());
    }
}
