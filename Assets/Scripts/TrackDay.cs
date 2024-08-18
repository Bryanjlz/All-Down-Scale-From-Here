using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackDay : MonoBehaviour
{
    public int currentDay = 0;
    public GameObject dateTextObject;
    public GameObject noteTextObject;
    public GameObject weatherDisplayObject;

    public void nextDay ()
    {
        currentDay += 1;
        dateTextObject.GetComponent<DateTextDisplay>().updateDateText(currentDay);
        noteTextObject.GetComponent<NoteTextDIsplay>().updateNoteText(currentDay);
        weatherDisplayObject.GetComponent<WeatherLogic>().updateWeatherSprite(currentDay);
    }
}
