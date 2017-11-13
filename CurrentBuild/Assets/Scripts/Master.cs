using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Master : MonoBehaviour {
    public List<Document> fileBook; //master list
    public int[] desktops;
    public int MainComputer;
    public int Earl;
    public int Ozzy;
    public int Journalist;
    //public TextAsset OldManFolders;
    public List<Dictionary<string, object>> dataOld;
    public List<Dictionary<string, object>> dataJournalist;
    public List<Dictionary<string, object>> dataJaz;

    private void Awake()
    {
        dataOld = CSVReader.Read("OldManFolders");
        //   dataJaz = CSVReader.Read("TechGuyFolders");
        //    dataJournalist = CSVReader.Read("JournalistFolders");
        //List<string> keyList = new List<string>(this.dataOld[1].Keys);
        //foreach (string i in keyList) {
       //     print(i);
     //   }
        fileBook = new List<Document>();
        desktops = new int[4];
        desktops[0] = Earl; desktops[1] = Ozzy; desktops[2] = Journalist; desktops[3] = MainComputer;
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
