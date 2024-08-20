using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WindowsUpdate : MonoBehaviour
{
    public TMP_Text updateText;
    public Image buttonImage;

    public GameObject desktopFile;
    public GameObject monitorBackground;

    private Animator fadeAnimator;
    private float timeStartFade;
    private float totalFadeTime = 2f;
    private bool isFading;

    private int currentDay;
    private bool updated;

    public AudioManager audioManager;
    public Sprite blass;

    public GameObject windowsUpdater;

    public void updateUpdateButton(int currentDay)
    {
        this.currentDay = currentDay;
        if (windowsUpdater.GetComponent<TaskbarFileLogic>().isGlowing && currentDay == 5 && !updated)
        {
            buttonImage.color = new Color(0.88f, 1, 0.88f);
            updateText.SetText("Upgrade?");
        } else
        {
            buttonImage.color = new Color(1, 0.88f, 0.88f);
            updateText.SetText("Up To Date");
        }
    }

    private void Update()
    {
        if (isFading && Time.time - timeStartFade > totalFadeTime)
        {
            updateUpdateButton(currentDay);
            monitorBackground.GetComponent<SpriteRenderer>().sprite = blass;
            monitorBackground.GetComponent<Transform>().localScale = new Vector3(1.7f, 0.76f, 0.06f);
            windowsUpdater.GetComponent<TaskbarFileLogic>().isGlowing = false;
            fadeAnimator.SetTrigger("FadeIn");
            isFading = false;
        }
    }

    private void OnMouseDown()
    {
        audioManager.Play("click");
        if (windowsUpdater.GetComponent<TaskbarFileLogic>().isGlowing && currentDay == 5 && !updated)
        {
            updated = true;
            audioManager.Play("clickOpen");
            Debug.Log("Upgrading?");
            desktopFile.GetComponent<OpenFileForGame>().updated = true;
            fadeAnimator = GameObject.FindGameObjectWithTag("Fade").GetComponent<Animator>();

            fadeAnimator.SetTrigger("FadeOut");
            timeStartFade = Time.time;
            isFading = true;
        }
    }
}
