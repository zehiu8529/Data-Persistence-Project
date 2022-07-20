using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI highestScoreText;
    public TMP_InputField nameInput;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        DataManager.Instance.SavePlayerName(nameInput.text);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
