using System.Collections;
using System.Collections.Generic;
using System.Threading;
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

    public AudioManager audioManager;

    public GameObject monitor;

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
        
        if (currentDay >= 4)
        {
            audioManager.DownPitch("bgm", 0.04f);
        }

        if (currentDay == 7)
        {
            monitor.GetComponent<SpriteRenderer>().color = new Color(1, 0.5f, 0.5f);
        }

        if (dayScripts[currentDay % 8] != null) {
            dayScripts[currentDay % 8].triggerDialogue();
        }
    }
}
