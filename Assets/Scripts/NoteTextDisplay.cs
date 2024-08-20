using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteTextDIsplay : MonoBehaviour
{
    private string[] notes = { "- Winning at work!\r\n- Try out new game", 
        "- Too many meetings\r\n- Game night!",
        "- Dinner 7:30pm\r\n- back to gaming",
        "- Doctor's appt.\r\n- try meditation?",
        "- Grocery shopping\r\n- sleep early",
        "- Time to run\r\n- I can do this",
        "- >:(, I WANT TO PLAY", "- what have I done\r\n- what is my purpose" };
    public TMP_Text noteText;

    private void Start()
    {
        noteText = GetComponent<TextMeshProUGUI>();
        noteText.SetText(notes[0]);
    }
    public void updateNoteText(int currentDateIndex)
    {
        noteText.SetText(notes[currentDateIndex % 8]);
    }
}
