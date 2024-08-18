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
	
	[SerializeField]
	Animator animatorRef;
	
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
			Vector3 position = transform.position;
			position.y -= 0.15f;
			position.x += 0.5f * player.GetFacingDirection();
			GameObject go = Instantiate(bulletPrefab.gameObject, position, Quaternion.identity);
			Bullet bullet = go.GetComponent<Bullet>();
			bullet.SetVelocity(new Vector3(bulletSpeed * player.GetFacingDirection(), 0, 0));
		}
	}
}
