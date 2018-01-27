using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShooterProjectile))]
public class EnemyShooting : MonoBehaviour {

    private ShooterProjectile shooter;
	
    void Awake()
    {
        shooter = GetComponent<ShooterProjectile>();
    }

	// Update is called once per frame
	void Update () {
        shooter.Shoot();
	}
}
