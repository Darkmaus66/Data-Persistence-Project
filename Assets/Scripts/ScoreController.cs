using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance;
    public TextMeshProUGUI highScoreText;

    public string PlayerName;
    public string HighScorePlayer = "Player X";
    public int HighScore = 5;

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
        highScoreText.text = $"{HighScorePlayer}\n{HighScore} points";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
