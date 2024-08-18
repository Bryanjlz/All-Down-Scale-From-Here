using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NoteTextDIsplay : MonoBehaviour
{
    private string[] notes = { "- Winning at work!\r\n- Playing best game", 
        "- Winning at work!\r\n- Playing best game", 
        "- :(",
        "- :(",
        "- :(",
        "- :(",
        "- >:(" };
    public TMP_Text noteText;

    private void Start()
    {
        noteText = GetComponent<TextMeshProUGUI>();
        noteText.SetText(notes[0]);
    }
    public void updateNoteText(int currentDateIndex)
    {
        noteText.SetText(notes[currentDateIndex % 7]);
    }
}
