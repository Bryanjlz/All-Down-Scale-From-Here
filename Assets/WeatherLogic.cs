using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeatherLogic : MonoBehaviour
{
    public SpriteRenderer weatherRenderer;
    public Sprite[] sprites; // 7 total weathers

    public void updateWeatherSprite(int currentWeather)
    {
        weatherRenderer.sprite = sprites[currentWeather % 7];
    }
}
