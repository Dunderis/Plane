using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    public GameObject scoreBoard;
    public Image medal;
    public Sprite[] medals;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    
    void Start()
    {
        scoreBoard.SetActive(false);
    }

    public void ShowScoreBoard(int score)
    {
        scoreBoard.SetActive(true);
        scoreText.text = score.ToString("D4");

        var best = PlayerPrefs.GetInt("HighScore", 0);
        var secondBest =PlayerPrefs.GetInt("SecondBest",0);
        if(score> best && score> secondBest){
            PlayerPrefs.SetInt("HighScore", score);
            PlayerPrefs.SetInt("SecondBest", best);
            PlayerPrefs.Save();
            highScoreText.text = score.ToString("D4");
            medal.sprite = medals[0];
        }
        else if(score> secondBest)
        {
            
            PlayerPrefs.SetInt("SecondBest", score);
            PlayerPrefs.Save();
            highScoreText.text = best.ToString("D4");
            medal.sprite = medals[1];
        }
        else{
            highScoreText.text = best.ToString("D4");
            medal.sprite = medals[2];
        }
    }


}
