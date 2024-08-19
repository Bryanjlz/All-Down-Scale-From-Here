using UnityEngine;

public class TaskbarFileLogic : MonoBehaviour
{
    public bool hovered = false;
    public SpriteRenderer mySpriteRenderer;

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
