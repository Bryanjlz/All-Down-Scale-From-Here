using TMPro;
using UnityEngine;

public class TaskbarFileLogic : MonoBehaviour
{
    public bool hovered = false;
    public SpriteRenderer mySpriteRenderer;
    public AudioManager audioManager;

    // things to render
    public GameObject objectToRender;
    public GameObject textToRender;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (hovered)
        {
            mySpriteRenderer.color = new Color(1f, 1f, 1f, 0.1f);
        } else
        {
            mySpriteRenderer.color = new Color(1f, 1f, 1f, 0f);
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Selected");

        if (objectToRender.activeSelf)
        {
            audioManager.Play("click");
            objectToRender.SetActive(false);
        } else
        {
            audioManager.Play("clickOpen");
            objectToRender.SetActive(true);
        }
    }

    void OnMouseEnter()
    {
        textToRender.SetActive(true);
        hovered = true;
    }

    void OnMouseExit()
    {
        textToRender.SetActive(false);
        hovered = false;
    }
}
