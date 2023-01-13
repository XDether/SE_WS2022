using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Starts a time count
/// </summary>
public class Watch : Observer
{
    private float spentTime, startTime;
    private TextMeshProUGUI uiElement;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="startTime">Start Time</param>
    /// <param name="uiElement"> UI Element to wright the time in</param>
    public Watch(float startTime, TextMeshProUGUI uiElement)
    {
        this.startTime = startTime;
        this.spentTime = startTime - startTime;
        this.uiElement = uiElement;

        uiElement.text = uiElement.text = "Time: " + spentTime.ToString("0.#") + " s";
    }

    /// <summary>
    /// Returns the spent time
    /// </summary>
    /// <returns></returns>
    public float getSpentTime()
    {
        return spentTime;
    }

    /// <summary>
    /// On Notify updates the time
    /// </summary>
    public override void OnNotify()
    {
        spentTime = Time.time - startTime;
        uiElement.text = "Time: " + spentTime.ToString("0.#") + " s";
    }

}

