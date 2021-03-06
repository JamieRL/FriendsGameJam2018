﻿using UnityEngine;
using System.Collections;

public class ShooterProjectile : MonoBehaviour
{

    // Reference to projectile prefab to shoot
    public GameObject projectile;
    public float projectileSpeed = 20.0f;
    public float fireRate = 1.0f;

    // Reference to AudioClip to play
    public AudioClip shootSFX;

    private float lastShotTimeStamp;

    public Animator cannonAnimator;

    void Start()
    {
        lastShotTimeStamp = 0.0f;
    }

    public void Shoot()
    {
        if ((Time.time - lastShotTimeStamp) >= fireRate)
        {
            cannonAnimator.SetBool("fire", true);
            // if projectile is specified
            if (projectile)
            {
                // Instantiante projectile at the camera + 1 meter forward with camera rotation
                GameObject newProjectile = Instantiate(projectile, transform.position + transform.up, transform.rotation) as GameObject;

                // if the projectile does not have a rigidbody component, add one
                if (!newProjectile.GetComponent<Rigidbody2D>())
                {
                    newProjectile.AddComponent<Rigidbody2D>();
                }

                // Apply force to the newProjectile's Rigidbody component if it has one
                newProjectile.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.up.x * projectileSpeed, transform.up.y * projectileSpeed);

                // play sound effect if set
                if (shootSFX)
                {
                    if (newProjectile.GetComponent<AudioSource>())
                    { // the projectile has an AudioSource component
                        // play the sound clip through the AudioSource component on the gameobject.
                        // note: The audio will travel with the gameobject.
                        newProjectile.GetComponent<AudioSource>().PlayOneShot(shootSFX);
                    }
                    else
                    {
                        // dynamically create a new gameObject with an AudioSource
                        // this automatically destroys itself once the audio is done
                        AudioSource.PlayClipAtPoint(shootSFX, Camera.main.transform.position);
                    }
                }

                Destroy(newProjectile, 3.0f);
            }

            lastShotTimeStamp = Time.time;
        }
    }
}
