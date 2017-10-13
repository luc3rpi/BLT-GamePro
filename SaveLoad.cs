using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour {
    public List<GameObject> bookmarks;
    public int profiles;
    public int conversation;
    public List<GameObject> encrypted;
    private savedata data;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void Save() {
        if (!Directory.Exists(Application.dataPath + "/saves")) {
            Directory.CreateDirectory(Application.dataPath + "/saves");
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.dataPath + "/saves/Savedata.dat");

        CopySaveData();
        bf.Serialize(file, data);
        file.Close();
    }
    public void CopySaveData() {
        data.bookmarks.Clear();
        data.encrypted.Clear();
        foreach (GameObject i in bookmarks) {
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
        foreach (GameObject i in data.bookmarks) {
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
        }
    }
}

[System.Serializable]
public class savedata
{
    public List<GameObject> bookmarks = new List<GameObject>();
    public int profiles;
    public int conversation;
    public List<GameObject> encrypted = new List<GameObject>();
}
