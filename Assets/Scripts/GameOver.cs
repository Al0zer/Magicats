using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Threading.Tasks;
using System;

public class GameOver : MonoBehaviour
{
    public static event Action OnGameOver;

    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI hsText;
    public bool isDead = false;

    private ScoreManager theScoreManager;


    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
        {
            gameOverPanel.SetActive(true);
            finalScoreText.text = ((int)theScoreManager.score).ToString();
            hsText.text = ((int)PlayerPrefs.GetFloat("Highscore")).ToString();
            Time.timeScale = 0f;
            isDead = false;
            OnGameOver?.Invoke();
        }
    }

    public void Restart()
    {
        isDead = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        isDead = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
