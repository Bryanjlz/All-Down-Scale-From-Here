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

    public GameObject windowsUpdateObject;
    public DialogueTrigger[] dayScripts;

    [ContextMenu("nextDay")]
    public void nextDay ()
    {
        FindObjectOfType<AudioManager>().Play("morning");
        currentDay += 1;
        dateTextObject.GetComponent<DateTextDisplay>().updateDateText(currentDay);
        noteTextObject.GetComponent<NoteTextDIsplay>().updateNoteText(currentDay);
        weatherDisplayObject.GetComponent<WeatherLogic>().updateWeatherSprite(currentDay);
        birdDisplayObject.GetComponent<Birdwatch>().updateBirdSprite(currentDay);
        wordDisplayObject.GetComponent<DisplayDailyText>().updateTextDisplay(currentDay);
        descriptionDisplayObject.GetComponent<DisplayDailyText>().updateTextDisplay(currentDay);
        windowsUpdateObject.GetComponent<WindowsUpdate>().updateUpdateButton(currentDay);
        
        if (dayScripts[currentDay % 8] != null) {
            dayScripts[currentDay % 8].triggerDialogue();
        }
    }
}
