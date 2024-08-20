using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birdwatch : MonoBehaviour
{
    public Sprite[] birds;
    public SpriteRenderer birdRenderer;
        

    // Update is called once per frame
    public void updateBirdSprite(int currentDay)
    {
        birdRenderer.sprite = birds[currentDay % 8];
    }
}
