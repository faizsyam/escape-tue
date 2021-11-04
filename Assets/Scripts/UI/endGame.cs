using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class endGame : MonoBehaviour
{
    public Text titleTxt;
    public Text scoreText;
    public Text bestText;

    string convertFormat(int seconds){
        int minutes = (int) seconds/60;
        seconds = seconds%60;
        string minuteTxt = minutes.ToString();
        string secondTxt = seconds.ToString();
        if (minutes<10) minuteTxt = "0" + minuteTxt;
        if (seconds<10) secondTxt = "0" + secondTxt; 
        return minuteTxt+"m"+secondTxt+"s";
    }

    void Start()
    {
        int levelEnded = PlayerPrefs.GetInt("levelEnded");
        titleTxt.text = "Level " + levelEnded.ToString() + " Completed";
        int timeSpent = PlayerPrefs.GetInt("Room"+levelEnded.ToString()+"Time");
        scoreText.text = "Your Time: " + convertFormat(timeSpent);
        int bestTime;
        if (!PlayerPrefs.HasKey("bestTimeLevel"+levelEnded.ToString())) bestTime = 999999;
        else bestTime = PlayerPrefs.GetInt("bestTimeLevel"+levelEnded.ToString());
        if (timeSpent<bestTime){
            PlayerPrefs.SetInt("bestTimeLevel"+levelEnded.ToString(),timeSpent);
            bestTime = timeSpent;
        }
        bestText.text = "Best Time: " + convertFormat(bestTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
