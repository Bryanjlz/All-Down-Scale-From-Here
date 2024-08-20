using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DateTextDisplay : MonoBehaviour
{
    private string[] dates = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday", "mOnDAy" };
    public TMP_Text dateText;

    private void Start()
    {
        dateText = GetComponent<TextMeshProUGUI>();
        dateText.SetText(dates[0]);
    }
    public void updateDateText(int currentDateIndex)
    {
        dateText.SetText(dates[currentDateIndex % 8]);
    }
}
