using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PatchNotesUpdater : MonoBehaviour {
    string[] dailyPatchNotes = {
        "Game release day!",
        "Due to low stock, bullets have been moved to DLC.",
        "Our intern didn't get the license for the ground assets, " +
        "so it has been moved to DLC to pay for our lawsuit",
        "Guns are being moved to DLC, as many of you have decided to use " +
        "your guns like a club, breaking all of them...",
        "Our artists are on strike and demanding royalties for art usage. " +
        "To avoid another lawsuit, all graphics will be moved to a new DLC to pay them. \n",
        "Due to complaints about performance issues, we have downgraded all your Operating Systems to to bindows XP.",
        "It has caught our attention that our game is too easy, so all checkpoints have been " +
        "moved to DLC.",
		"Your free trial has ended. Please check the DLC store.",
    };

    [SerializeField]
    TMP_Text patchNotes;
    [SerializeField]
    TMP_Text version;
    [SerializeField] 
    RectTransform transform;
    
    [SerializeField]
    private int day;
    
    // Start is called before the first frame update
    void Start()
    {
        day = GameObject.FindGameObjectWithTag("DayManager").GetComponent<TrackDay>().currentDay;
        patchNotes.text = dailyPatchNotes[day];
        version.text = "1." + day + " PATCH NOTES";
        if (day == 4) {
            patchNotes.fontSize = 10;
            transform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 300);
        }
    }
}
