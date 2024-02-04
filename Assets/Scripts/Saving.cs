using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Saving : MonoBehaviour
{

    public static Saving Instance;

    public string Name;
    public string HighScore;
    public int S;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }


    [System.Serializable]
    class SaveData
    {
        public string HighScore;
        public int S;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.HighScore = HighScore;
        data.S = S;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            HighScore = data.HighScore;
            S = data.S;

        }
        else
        {
            HighScore = $"Best Score: : 0";
            S = 0;
        }
        

    }



}
