using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    string playerName;
    public Color ballColor;
    public Color paddleColor;
    public Color borderColor;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SavePlayerName(string name)
    {
        playerName = name;
        Debug.Log("Player name: " + playerName);
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int score;        
    }

    [System.Serializable]
    class ColorData
    {
        public Color ballColor;
        public Color paddleColor;
        public Color borderColor;
    }

    public void SaveHighestScore(int points)
    {
        string path = Application.persistentDataPath + "/highestscore.json";

        if (!File.Exists(path))
        {
            SaveJsonFile(DataManager.Instance.playerName, points);
        }
        else
        {
            SaveData data = ReadJsonFile(path);

            if (points > data.score)
            {
                SaveJsonFile(DataManager.Instance.playerName, points);
            }
            else
            {
                return;
            }
        }
    }

    public void LoadHighestScore(TextMeshProUGUI highestScoreText)
    {
        string path = Application.persistentDataPath + "/highestscore.json";

        if (File.Exists(path))
        {
            SaveData data = ReadJsonFile(path);
            highestScoreText.text = "Best score: " + data.playerName + ": " + data.score;
        }
        else
        {
            highestScoreText.text = "Best score: " + ": 0";
        }
    }

    SaveData ReadJsonFile(string path)
    {
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        return data;
    }

    void SaveJsonFile(string playerName, int score)
    {
        SaveData data = new SaveData();
        data.score = score;
        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/highestscore.json", json);
    }

    public void SaveJsonFileColor()
    {
        ColorData data = new ColorData();
        data.ballColor = ballColor;
        data.paddleColor = paddleColor;
        data.borderColor = borderColor;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/color.json", json);
    }

    public void LoadJsonFileColor()
    {
        string path = Application.persistentDataPath + "/color.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            ColorData data = JsonUtility.FromJson<ColorData>(json);

            ballColor = data.ballColor;
            paddleColor = data.paddleColor;
            borderColor = data.borderColor;
        }        
    }

    public void ChangeObjectsColor(GameObject ball, GameObject paddle, GameObject[] borders)
    {
        ball.GetComponent<MeshRenderer>().material.color = ballColor;
        paddle.GetComponent<MeshRenderer>().material.color = paddleColor;
        foreach (GameObject border in borders)
        {
            border.GetComponent<MeshRenderer>().material.color = borderColor;
        }
    }
}
