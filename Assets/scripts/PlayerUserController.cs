using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShooterProjectile))]
public class PlayerUserController : MonoBehaviour {

    private ShooterProjectile shooter;

    private Animator animator;

	// Use this for initialization
	void Start () {
        shooter = GetComponent<ShooterProjectile>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if (GameManager.gm)
        {
            if (GameManager.gm.gameIsOver)
            {
                return;
            }
        }

        if(Input.GetButton("Horizontal") || Input.GetButton(("Vertical"))) {
            Debug.Log("setting animator to boosting");
            animator.SetBool("isBoosting", true);
        }
        else {
            Debug.Log(("setting animator to not boosting"));
            animator.SetBool("isBoosting", false);
        }
		if (Input.GetButton("Fire1"))
        {
            shooter.Shoot();
        }
	}
}
