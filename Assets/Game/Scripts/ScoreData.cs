using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreData : MonoBehaviour
{
    [HideInInspector] public int _score;
    
    public void Score(Cube cube) // skor
    {
        _score += cube.CubeNumber;
       
        UIManager.instance.scoreText.text = _score.ToString();
        UIManager.instance.scoreGameOverText.text = _score.ToString();

        if (_score > PlayerPrefs.GetInt("highScore"))  //skor kaydetme
        {
            PlayerPrefs.SetInt("highScore", _score);
        }

        UIManager.instance.highScoreText.text = "rekor : " + PlayerPrefs.GetInt("highScore").ToString();
        UIManager.instance.hsGameOverText.text =  PlayerPrefs.GetInt("highScore").ToString();
    }
}
