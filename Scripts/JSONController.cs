using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class JSONController : MonoBehaviour
{
    public string SavePath;

    SaveData data = new SaveData();

    public Text playText;

    private void Start()
    {
        Events.textSaved += Save;
        SavePath = Application.persistentDataPath + "/text.gamedata";

        if (File.Exists(SavePath))
        {
            string fileData = File.ReadAllText(SavePath);
            SaveData data = JsonUtility.FromJson<SaveData>(fileData);

            playText.text = data.text;
        }
    }

    public void Save()
    {
        data.text = playText.text;
        string jsonString = JsonUtility.ToJson(data);
        File.WriteAllText(SavePath , jsonString);
    }
}

[System.Serializable]
public class SaveData
{
    public string text; 
}
