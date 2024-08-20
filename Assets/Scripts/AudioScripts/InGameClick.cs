using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameClick : MonoBehaviour
{
    public void clickButton()
    {
        FindObjectOfType<AudioManager>().Play("menuClick");
    }

    public void clickDlcItem()
    {
        FindObjectOfType<AudioManager>().Play("yourebroke");
    }
}
