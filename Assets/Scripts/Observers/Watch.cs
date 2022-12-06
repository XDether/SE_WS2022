using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Watch : Observer
{
    private float spentTime, startTime;
    private TextMeshProUGUI uiElement;
    public Watch(float startTime, TextMeshProUGUI uiElement){
        this.startTime = startTime;
        this.spentTime = startTime - startTime;
        this.uiElement = uiElement;

        uiElement.text = uiElement.text = "Time:" + spentTime + "s";
    }

    public float getSpentTime(){
        return spentTime;
    }

    public override void OnNotify()
    {
        spentTime = Time.time - startTime;
        uiElement.text = "Time:" + spentTime + " s";
    }

}

