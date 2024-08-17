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
            mySpriteRenderer.color = new Color(mySpriteRenderer.color.r, mySpriteRenderer.color.g, mySpriteRenderer.color.b, 0.5f);
        } else if (selected)
        {
            mySpriteRenderer.color = new Color(1f, 1f, 0f, 1f);
        } else
        {
            mySpriteRenderer.color = Color.white;
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
