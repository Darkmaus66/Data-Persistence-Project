using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance;
    public TextMeshProUGUI highScoreText;

    public string PlayerName;
    public string HighScorePlayer;
    public int HighScore;

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

    [System.Serializable]
    class SaveData
    {
        public string HighScorePlayer;
        public int HighScore;
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadHighScore();
        if (!(HighScorePlayer.Length > 0)) { HighScorePlayer = "---"; };
        if (!(HighScore > 0)) { HighScore = 0; };
        highScoreText.text = $"{HighScorePlayer}\n{HighScore} points";
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.HighScorePlayer = HighScorePlayer;
        data.HighScore = HighScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/highscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            HighScorePlayer = data.HighScorePlayer;
            HighScore = data.HighScore;
        }
    }

}
