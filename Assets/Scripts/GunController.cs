using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
	// Editor accessible variables
	public float cooldown;
	public float bulletSpeed;

	public Bullet bulletPrefab;

	private float internalCooldown;
	private PlayerController player;


    // Start is called before the first frame update
    void Start()
    {
		player = GetComponent<PlayerController>();
		if (player == null) {
			Debug.LogError("Gun should be instantiated on the same object as the player character!");
		}
    }

    // Update is called once per frame
    void Update() {
		if (internalCooldown > 0) {
			internalCooldown -= Time.deltaTime;
		}

		if (Input.GetKeyDown(KeyCode.Space) && internalCooldown <= 0) {
			internalCooldown = cooldown;
			GameObject go = Instantiate(bulletPrefab.gameObject, transform.position, Quaternion.identity);
			Bullet bullet = go.GetComponent<Bullet>();
			bullet.SetVelocity(new Vector3(bulletSpeed * player.getFacingDirection(), 0, 0));
		}
	}
}
