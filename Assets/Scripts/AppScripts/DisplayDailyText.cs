using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayDailyText : MonoBehaviour
{
    public TMP_Text textDisplay;
    public string[] textArray;

    public void updateTextDisplay(int currentDay)
    {
        textDisplay.SetText(textArray[currentDay % 8]);
    }
}
