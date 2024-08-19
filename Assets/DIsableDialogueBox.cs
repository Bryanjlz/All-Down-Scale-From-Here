using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableDialogueBox : MonoBehaviour
{
    public void disableDialogueBox()
    {
        Debug.Log("I'm Closing!");
        this.gameObject.SetActive(false);
    }
}
