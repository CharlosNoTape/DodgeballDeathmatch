﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text uiText;
    public int CounterStart = 99;
    public bool timerOn = false;

    private int counter;
    private float timer;

    public int Current 
    { 
        get
        {
            return counter;
        } 
        set
        {
            value = Math.Min(CounterStart, value);
            counter = Math.Max(0, value);
        } 
    }

    void Start()
    {
        uiText = GetComponent<Text>();
        Current = CounterStart;
        timer = 0f;
        uiText.text = CounterStart.ToString();
    }

    void Update()
    {
        UpdateCounter(Time.deltaTime);

        uiText.text = Current.ToString();
    }

    public void StartTimer(){
        if(!timerOn)
        {
            timer = 0f;
            timerOn = true;
        }
    }

    public void UpdateCounter(float seconds)
    {
        if (timerOn)
        {
            timer += seconds;

            Current = CounterStart - Mathf.CeilToInt(timer);

            if(timer <= 0f)
            {

                timerOn = false;

                // Insert screen saying both teams failed to kill their opponent. BOTH lose!
                //GameManager.instance.GameOver(0);
            }
            if (Current == 0)
            {
                GameManager.instance.GameOver(0);
                timerOn = false;
            }
        }
    }
}