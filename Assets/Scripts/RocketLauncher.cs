using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    public bool playerControlled = true;    // Is this RocketLauncher controlled by the player?
    public float fireInterval = 3.0f; 		// how many seconds between shots for this rocket launcher?

	private float fireTimer = 0; 			// keeop track of when we can fire again

	public GameObject rocketPrefab; 		// reference to Rocket prefab so we spawn it
	public Vector3 spawnOffset; 			// a position offset for where the rocket is spawned so that we dont spawn inside the gun
	
	public int ammo = 100;
    // Start is called before the first frame update
    void Start()
    {
        fireTimer = fireInterval; 			// when the game starts we are ready to shoot
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime; 		// advance the timer

		if(fireTimer >= fireInterval) {
			if(playerControlled && Input.GetButtonDown("Fire1")) {
				Fire(); 		// Fire a rocket
			}
		}
    }

	public void Fire() {
		if(ammo <= 0) { 														// only shoot if there is ammo
			return;
		}
		GameObject rocketInstance = Instantiate(rocketPrefab); 					// spawn and store a new rocket prefab

		rocketInstance.transform.position = transform.position +transform.right * spawnOffset.x +transform.up * spawnOffset.y +transform.forward * spawnOffset.z; 	// apply the spawn offset relative to the gun position
		rocketInstance.transform.rotation = this.transform.rotation; 			// rotate the rocket to match the guns rotation

		fireTimer = 0; 															// reset fire timer
		ammo -= 1; 																// reduce ammo count
	}
}
