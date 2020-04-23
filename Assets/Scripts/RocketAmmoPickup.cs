using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAmmoPickup : MonoBehaviour
{
    public int amount = 5;                                  // how many rockets this pickup is worth
    public float rotationSpeed = 20f;                       // how fast the ammo box rotates
    // Start is called before the first frame update
    void Update()
    {
        gameObject.transform.RotateAround(transform.position, transform.up, rotationSpeed * Time.deltaTime);
    }

private void OnTriggerEnter(Collider other) {
    RocketLauncher rocketLauncher = other.gameObject.GetComponentInChildren<RocketLauncher>();              // checks to see if we have a rocketlauncher attached

    if(rocketLauncher != null) {                                                 // if we found a rocketlauncher
        rocketLauncher.ammo += amount;
        gameObject.SetActive(false);
    }
}

}
