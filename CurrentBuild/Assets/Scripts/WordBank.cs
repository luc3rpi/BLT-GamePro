using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordBank : MonoBehaviour {
    public Text txt;
    public string blank;
    public string applied;
    public int currentPos;
    bool submit;
    public string[] entries;
	// Use this for initialization
	void Start () {
        entries = new string[11];
        currentPos = 0;
        submit = false;
        for (int i = 0; i < 11; i++) {
            entries[i] = " CHOOSE ";
        }
	}
	
	// Update is called once per frame
	void Update () {
        applied = entries[0] + " is a " + entries[1] + " who has been looking into the " + entries[2] + " of " + entries[3] + ". " +  entries[0] + " has " + entries[4] + "connecting " +
            entries[5] + " to the " + entries[2] +". " + entries[6] + ", a " + entries[7] +", " + entries[8] + entries[0]+" about the " + entries[9] +". If people believe this, there will be panic among our citizens. " + entries[0] + " will be brought in for questioning immediately. With " + entries[10] +" silenced we’ll be able to preserve the peace of the nation.";
        txt.text = applied;

	}
    public void AddString(string str) {
        entries[currentPos] = str;
        currentPos++;
        if (currentPos == 10) {
            currentPos = 0;
            submit = true;
            if (entries[0] == "Oswald Porter")
            {
                txt.text = "A day before his trial, Oswald was found hanging in his cell and the coroner ruled his death as a suicide.Although it was declared as a suicide, there were signs of struggle in his cell and defensive wounds were recorded in the official autopsy report. Without someone spearheading the spread of the conspiracy, the theory’s presence in the media has faded.";
            }
            else if (entries[0] == "Earl Falkov")
            {
                txt.text = "A SWAT team was sent to Earl’s home while his grandchildren were visiting. During the breach he suffered from a heart attack. His grandchildren witnessed the entire ordeal. He is now in a medically induced coma and there are no signs of him ever making a full recovery.";
            }
            else if (entries[0] == "Tamara Glass")
            {
                txt.text = "Tamara is taken from a private interview with an article subject. She is blatantly confused and so is the subject. News breaks out that a journalist was involved with such a ridiculous conspiracy. Her career is over and all publishing companies refuse to publish her articles. Her social media accounts have been spammed with hate messages. She may have to flee the country to live her life normally again. ";
            }
            else {
                Start();
            }
        }
    }
}
