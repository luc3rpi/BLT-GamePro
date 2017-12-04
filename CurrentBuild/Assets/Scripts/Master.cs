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
    public TextAsset OldManInfo;
    public TextAsset TechGuyInfo;
    public TextAsset JournalistInfo;
    public TextAsset supers;
    //public TextAsset OldManFolders;
    public Dictionary<string, string[]> dataOld;
    public Dictionary<string, string[]> dataJournalist;
    public Dictionary<string, string[]> dataJaz;
    public Dictionary<string, string[]> SupervisorEmails;

    private void Awake()
    {
        //    dataOld = CSVReader.Read("OldManFolders");
        //   dataJaz = CSVReader.Read("TechGuyFolders");
        //    dataJournalist = CSVReader.Read("JournalistFolders");
        //List<string> keyList = new List<string>(this.dataOld[1].Keys);
        //foreach (string i in keyList) {
        //     print(i);
        //   }
        dataOld = ToDict(OldManInfo);
        dataJaz = ToDict(TechGuyInfo);
        dataJournalist = ToDict(JournalistInfo);
        SupervisorEmails = ToDict(supers);
     //   foreach (string i in dataJournalist.Keys) {
       //     print(i);
         //   print(dataOld[i][1]);
        //    print(dataOld[i][2]);
  //      }
        fileBook = new List<Document>();
        desktops = new int[4];
        desktops[0] = Earl; desktops[1] = Ozzy; desktops[2] = Journalist; desktops[3] = MainComputer;
    }
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
        public Dictionary<string, string[]> ToDict(TextAsset asset)
    {

        string indexer = "";
        bool inQuotes = false;
        bool firstWord = true; ;
        Dictionary<string, string[]> returner = new Dictionary<string, string[]>();
        string file = asset.ToString();
        string tempStore = "";
        string[] a = new string[100];
        int index = 0;
        foreach (char i in file)
        {
            if (i == '\"')
            {
                inQuotes = !inQuotes;
            }
            else
            {
                if (!inQuotes && i == ',' && firstWord)
                {
                    indexer = tempStore;
                    firstWord = false;
                    index++;
                    tempStore = "";
                }
                else if (!inQuotes && i == '\n' && !firstWord)
                {
                    a[index] = (tempStore);
                    tempStore = "";
                    firstWord = true;
                    returner[indexer] = a;
                    a = new string[100];
                    index = 0; 
                }
                else if (!inQuotes && i == ',')
                {
                    a[index] = (tempStore);
                    tempStore = "";
                    index++;
                }
                else
                {
                    tempStore += i;
                }

            }
        }
        return returner;
    }
}
