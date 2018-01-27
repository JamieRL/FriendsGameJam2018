using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShooterProjectile))]
public class PlayerUserController : MonoBehaviour {

    private ShooterProjectile shooter;

	// Use this for initialization
	void Start () {
        shooter = GetComponent<ShooterProjectile>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1"))
        {
            shooter.Shoot();
        }
	}
}
