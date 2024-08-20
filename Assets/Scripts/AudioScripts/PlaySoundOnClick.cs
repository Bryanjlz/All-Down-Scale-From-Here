using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnClick : MonoBehaviour
{
    public AudioManager audioManager;

    private void OnMouseDown()
    {
        audioManager.Play("click");
    }
}
