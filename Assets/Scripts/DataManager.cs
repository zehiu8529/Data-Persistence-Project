using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    string playerName;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SavePlayerName(string name)
    {
        playerName = name;
        Debug.Log("Player name: " + playerName);
    }
}
