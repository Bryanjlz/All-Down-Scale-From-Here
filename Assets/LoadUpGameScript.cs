using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadUpGameScript : MonoBehaviour
{
    public AdditiveSceneChanger additiveSceneChanger;
    public Image loadingBackground;
    public RectTransform loadingBar;
    private GameObject desktop;

    public float loadingInterval = 0.02f;
    private float loadingTimer = 0.0f;

    public float colorInterval = 0.2f;
    private float colorTimer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        desktop = GameObject.FindGameObjectWithTag("Desktop");
        StartCoroutine(DelayAction(1.25f));
    }

    private void Update()
    {
        loadingTimer += Time.deltaTime;
        colorTimer += Time.deltaTime;

        if (colorTimer > colorInterval)
        {
            colorTimer = colorTimer - colorInterval;
            if (loadingBackground.color.g < 1)
            {
                loadingBackground.color = new Color(loadingBackground.color.r, loadingBackground.color.g + 0.2f, loadingBackground.color.b);
            }
            else if (loadingBackground.color.r > 0.75f)
            {
                loadingBackground.color = new Color(loadingBackground.color.r - 0.1f, loadingBackground.color.g, loadingBackground.color.b);
            }
        }


        if (loadingTimer > loadingInterval && loadingBar.offsetMax.x < 100)
        {
            loadingTimer = loadingTimer - loadingInterval;
            loadingBar.offsetMax = new Vector2(loadingBar.offsetMax.x + 4, loadingBar.offsetMax.y);
        }
    }

    IEnumerator DelayAction(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        additiveSceneChanger.ChangeScene();
        desktop.SetActive(false);
    }
}
