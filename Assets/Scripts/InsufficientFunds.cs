using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsufficientFunds : MonoBehaviour {
    [SerializeField]
	float deathTime;

	private float startTime;
    
    // Start is called before the first frame update
    void Start() {
	    startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
	    if (Time.time - startTime > deathTime) {
		    Destroy(transform.parent.gameObject);
	    }
    }
    
}
