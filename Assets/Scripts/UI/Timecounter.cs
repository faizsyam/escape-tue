using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timecounter : MonoBehaviour
{
    public Text timeText;

    float time;

    public int getTime(){
        return (int)time;
    }
    void Start()
    {
        float time;
    }

    string convertFormat(int seconds){
        int minutes = (int) seconds/60;
        seconds = seconds%60;
        string minuteTxt = minutes.ToString();
        string secondTxt = seconds.ToString();
        if (minutes<10) minuteTxt = "0" + minuteTxt;
        if (seconds<10) secondTxt = "0" + secondTxt; 
        return minuteTxt+"m"+secondTxt+"s";
    }

    void Update()
    {
        time += Time.deltaTime;
        timeText.text = "Time " + convertFormat((int)time);
    }
}
