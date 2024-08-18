using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLCController : MonoBehaviour {
    [SerializeField] 
    int day;
    [SerializeField] 
    List<GameObject> DLCMenuItems;
    [SerializeField]  
    GameObject slider;
    [SerializeField]
    RectTransform contentTransform;
    [SerializeField] 
    GameObject ComingSoonText;
    
    void Start()
    {
        if (day == 0) {
            ComingSoonText.SetActive(true);
        } else {
            // Show slider when there are more than 4 items
            if (day >= 5) {
                slider.SetActive(true);
            }
            // Enable DLCs, and adjust slider content box size as necessary
            for (int i = 0; i < day; i++) {
                DLCMenuItems[i].SetActive(true);
            }
            contentTransform.sizeDelta = new Vector2(contentTransform.rect.width, 30 * day);
        }
    }


}
