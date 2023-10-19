using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScreen : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    void Start()
    {
        var score = PlayerPrefs.GetInt("Score");
        scoreText.text = score.ToString();

        var best = PlayerPrefs.GetInt("HighScore");
        if (score > best)
        {
            best = score;
            PlayerPrefs.SetInt("HighScore", best);
        }
        highScoreText.text = best.ToString();
    }
}
