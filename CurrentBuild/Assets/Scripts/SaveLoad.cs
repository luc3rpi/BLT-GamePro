using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour { //link each thing with Main file
    public List<Document> bookmarks;
    public int[] profiles;
    public int conversation;
    public List<GameObject> encrypted;
    private savedata data;

	// Use this for initialization
	void Start () {
        data = new savedata();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q)) { Save(); }
        if (Input.GetKeyDown(KeyCode.W)) { Load(); }
    }
    public void Save() {
        if (!Directory.Exists(Application.dataPath + "/saves")) {
            Directory.CreateDirectory(Application.dataPath + "/saves");
        }
        BinaryFormatter bf = new BinaryFormatter();
        profiles = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Master>().desktops;
        bookmarks = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Master>().fileBook;
        FileStream file = File.Create(Application.dataPath + "/saves/SaveData.dat");

        CopySaveData();
        bf.Serialize(file, data);
        file.Close();
    }
    public void CopySaveData() {
        if(data.bookmarks.Count > 0)
        data.bookmarks.Clear();
        if(data.encrypted.Count > 0)
        data.encrypted.Clear();
        foreach (Document i in bookmarks) {
            data.bookmarks.Add(i);
        }
        foreach (GameObject i in encrypted)
        {
            data.encrypted.Add(i);
        }
        data.conversation = conversation;
        data.profiles = profiles;

    }
    public void CopyLoadData() {
        bookmarks.Clear();
        encrypted.Clear();
        foreach (Document i in data.bookmarks) {
            bookmarks.Add(i);
        }
        foreach (GameObject i in data.encrypted) {
            encrypted.Add(i);
        }
        conversation = data.conversation;
        profiles = data.profiles;
        
    }
    public void Load() {
        if (File.Exists(Application.dataPath + "/saves.SaveData.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.dataPath + "/saves/SaveData.dat", FileMode.Open);
            data = (savedata)bf.Deserialize(file);
            CopyLoadData();
            file.Close();
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Master>().desktops = profiles;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Master>().fileBook = bookmarks;
        }
    }
}

[System.Serializable]
public class savedata
{
    public List<Document> bookmarks = new List<Document>();
    public int[] profiles;
    public int conversation;
    public List<GameObject> encrypted = new List<GameObject>();
}
