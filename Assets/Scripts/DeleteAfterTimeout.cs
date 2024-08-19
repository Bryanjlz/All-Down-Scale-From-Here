using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterTimeout : MonoBehaviour
{
	public float timeout;

	private float timer = 0;

    // Update is called once per frame
    void Update()
    {
        if (timer >= timeout) {
			Destroy(this.gameObject);
		}

		timer += Time.deltaTime;
    }
}
