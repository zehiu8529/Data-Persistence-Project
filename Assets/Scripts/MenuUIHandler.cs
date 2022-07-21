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
    public GameObject settingMenu;

    private void Start()
    {        
        DataManager.Instance.LoadHighestScore(highestScoreText);
    }

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

    public void Done()
    {
        settingMenu.gameObject.SetActive(false);
    }

    public void OpenSetting()
    {
        settingMenu.gameObject.SetActive(true);
    }

    public void SaveColor()
    {
        DataManager.Instance.SaveJsonFileColor();
    }

    public void LoadColor()
    {
        DataManager.Instance.LoadJsonFileColor();
    }
}
