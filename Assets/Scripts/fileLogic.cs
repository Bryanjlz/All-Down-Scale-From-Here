using UnityEngine;

public class openFileForGame : MonoBehaviour
{
    public float doubleClickWindow = 0.5f;
    public SpriteRenderer mySpriteRenderer;
    public bool selected = false;
    public bool hovered = false;
    private float doubleClickTimer = 0;

    [SerializeField]
    AdditiveSceneChanger additiveSceneChanger;

    // Start is called before the first frame update
    void Start()
    {
        
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
        if (doubleClickTimer > 0)
        {
            Debug.Log("Open the file");
            additiveSceneChanger.LoadScene();
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
}
