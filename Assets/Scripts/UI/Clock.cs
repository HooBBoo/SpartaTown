using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Clock : MonoBehaviour
{
    public Text currentTime;

    public string GetCurrentTime()
    {
        return DateTime.Now.ToString(("HH:mm tt"));
    }

    public void Update()
    {
        currentTime.text = GetCurrentTime();
    }
}
