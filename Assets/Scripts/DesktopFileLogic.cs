using System.Collections;
using UnityEngine;

public class OpenFileForGame : MonoBehaviour
{
    public float doubleClickWindow = 0.5f;
    public SpriteRenderer mySpriteRenderer;
    public bool selected = false;
    public bool hovered = false;
    private float doubleClickTimer = 0;

    public BoxCollider2D myBoxCollider;

    [SerializeField]
    AdditiveSceneChanger additiveSceneChanger;

    public AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        myBoxCollider.enabled = true;
    }

    private void Update()
    {
        if (doubleClickTimer > 0)
        {
            doubleClickTimer -= Time.deltaTime;
        }

        if (hovered)
        {
            mySpriteRenderer.color = new Color(1f, 1f, 1f, 0.04f);
        } else if (selected)
        {
            mySpriteRenderer.color = new Color(1f, 1f, 1f, 0.08f);
        } else
        {
            mySpriteRenderer.color = new Color(1f, 1f, 1f, 0f);
        }
    }

    void OnMouseDown()
    {
        audioManager.Play("click");
        if (doubleClickTimer > 0)
        {
            Debug.Log("Open the file");
            additiveSceneChanger.LoadScene();

            // prevent opening too many games at once
            myBoxCollider.enabled = false;
            StartCoroutine(DelayAction(2));

            selected = false;
        } else
        {
            Debug.Log("Selected");
            selected = true;
            doubleClickTimer = doubleClickWindow;
        }
    }

    void OnMouseEnter()
    {
        hovered = true;
    }

    void OnMouseExit()
    {
        hovered = false;
    }

    private void OnMouseDrag()
    {
        Debug.Log("Dragging!");
    }

    IEnumerator DelayAction(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        myBoxCollider.enabled = true;
    }
}
