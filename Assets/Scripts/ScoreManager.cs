using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float score;

    private int difficulty = 1;
    private int maxDifficulty = 5;
    private int scoreToNextLevel = 1000;

    // Update is called once per frame
    void Update()
    {
        //if player has not died yet
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            score += 1 * Time.deltaTime;
            scoreText.text = "score: " + ((int)score).ToString();
        }

        if (PlayerPrefs.GetFloat("Highscore") < score)
        {
            PlayerPrefs.SetFloat("Highscore", score);
        }

        if(score >= scoreToNextLevel)
        {
            LevelUp();
        }
    }

    public void AddScore(int points)
    {
        score += points;
    }

    void LevelUp()
    {
        if(difficulty == maxDifficulty)
        {
            return;
        }

        scoreToNextLevel *= 2;
        difficulty++;
        FindObjectOfType<LoopingBackground>().IncreaseSpeed();
        FindObjectOfType<CameraMovement>().IncreaseSpeed();
        FindObjectOfType<SpawnObstacles>().IncreaseSpawn();
    }
}
