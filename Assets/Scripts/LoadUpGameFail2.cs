using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadUpGameFail2 : MonoBehaviour
{
    public AdditiveSceneChanger additiveSceneChanger;
    public Image loadingBackground;
    public RectTransform loadingBar;
    private GameObject desktop;

    public float loadingInterval = 0.02f;
    private float loadingTimer = 0.0f;

    public float colorInterval = 0.2f;
    private float colorTimer = 0.0f;

    private bool playedSound;
    public TMP_Text loadingText;

    private bool stopLoading;

    // Start is called before the first frame update
    void Start()
    {
        playedSound = false;
        stopLoading = false;
        loadingText.SetText("Loading...");
        desktop = GameObject.FindGameObjectWithTag("Desktop");
        StartCoroutine(DelayAction(1.5f));
    }

    private void Update()
    {
        loadingTimer += Time.deltaTime;
        colorTimer += Time.deltaTime;

        if (colorTimer > colorInterval)
        {
            colorTimer = colorTimer - colorInterval;
            if (!stopLoading)
            {
                if (loadingBackground.color.g < 1)
                {
                    loadingBackground.color = new Color(loadingBackground.color.r, loadingBackground.color.g + 0.2f, loadingBackground.color.b);
                }
                else if (loadingBackground.color.r > 0.80f)
                {
                    loadingBackground.color = new Color(loadingBackground.color.r - 0.1f, loadingBackground.color.g, loadingBackground.color.b);
                }
            }
        }


        if (loadingTimer > loadingInterval && loadingBar.offsetMax.x < 60)
        {
            loadingTimer = loadingTimer - loadingInterval;
            loadingBar.offsetMax = new Vector2(loadingBar.offsetMax.x + 4, loadingBar.offsetMax.y);
        }
        else if (loadingTimer > loadingInterval && playedSound == false)
        {
            stopLoading = true;
            FindObjectOfType<AudioManager>().Play("error");
            loadingText.SetText("ERRORERRORERRORERROR");
            loadingBackground.color = new Color(1, 0.5f, 0.5f);
            playedSound = true;
        }
    }

    IEnumerator DelayAction(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        additiveSceneChanger.ChangeScene();
        additiveSceneChanger.LoadScene("GoodPatchNotes");
        desktop.SetActive(false);
    }
}
