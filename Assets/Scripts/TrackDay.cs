using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackDay : MonoBehaviour
{
    public int currentDay = 0;
    public GameObject dateTextObject;
    public GameObject noteTextObject;
    public GameObject weatherDisplayObject;
    public GameObject birdDisplayObject;

    public GameObject wordDisplayObject;
    public GameObject descriptionDisplayObject;
    public DialogueTrigger[] dayScripts;

    public void nextDay ()
    {
        currentDay += 1;
        dateTextObject.GetComponent<DateTextDisplay>().updateDateText(currentDay);
        noteTextObject.GetComponent<NoteTextDIsplay>().updateNoteText(currentDay);
        weatherDisplayObject.GetComponent<WeatherLogic>().updateWeatherSprite(currentDay);
        birdDisplayObject.GetComponent<Birdwatch>().updateBirdSprite(currentDay);
        wordDisplayObject.GetComponent<DisplayDailyText>().updateTextDisplay(currentDay);
        descriptionDisplayObject.GetComponent<DisplayDailyText>().updateTextDisplay(currentDay);
        if (dayScripts[currentDay % 7] != null) {
            dayScripts[currentDay % 7].triggerDialogue();
        }
    }
}
