using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Clock : MonoBehaviour {

    public float startTime = 300f;
    CanvasGroup startBttn;
    CanvasGroup stopBttn;
    Text clockText;
    CanvasGroup clock;
    GameObject panelObject;

    private void Start()
    {
        GameObject startBttnObject = GameObject.Find("StartBttn");
        startBttn = startBttnObject.GetComponent<CanvasGroup>();
        GameObject stopBttnObject = GameObject.Find("StopBttn");
        stopBttn = stopBttnObject.GetComponent<CanvasGroup>();

        GameObject clockObject = GameObject.Find("Clock");
        clockText = clockObject.GetComponent<Text>();
        clock = clockObject.GetComponent<CanvasGroup>();

        panelObject = GameObject.Find("Panel");
    }

    private void Update()
    {
        stopBttn.interactable = false;
        startBttn.interactable = false;
        startBttn.alpha = 0;
        stopBttn.alpha = 0;
        clock.alpha = 1;
        startTime -= Time.deltaTime;
        string timeToShow = string.Format("{0}:{1:00}", (int)startTime / 60, (int)startTime % 60);
        clockText.text = timeToShow;

        if (startTime <= 0.0f)
        {
            clockText.text = "GAME\nOVER";
        }

        if (startTime <= -5.0f)
        {
            clock.alpha = 0;
            startBttn.alpha = 1;
            stopBttn.alpha = 1;
            startBttn.interactable = true;
            stopBttn.interactable = true;
            panelObject.GetComponent<Clock>().enabled = false;
        }
    }
}
