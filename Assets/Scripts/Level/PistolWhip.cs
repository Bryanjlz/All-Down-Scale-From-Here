using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolWhip : MonoBehaviour
{

	public float duration;

	private float lifespan;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (lifespan > duration) {
			Destroy(this.gameObject);
		}
		lifespan += Time.deltaTime;
	}
}
