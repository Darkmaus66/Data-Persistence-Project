using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuHandler : MonoBehaviour
{
    public GameObject playerInput;
    private string playerName;

    public void StartNew()
    {
        playerName = playerInput.GetComponent<TMP_InputField>().text;
        if (ScoreController.Instance != null)
        {
            ScoreController.Instance.PlayerName = playerName;
        }
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
