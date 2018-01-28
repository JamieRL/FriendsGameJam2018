using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShooterProjectile))]
public class PlayerUserController : MonoBehaviour {

    private ShooterProjectile shooter;

    private Animator shipAnimator;
    public Animator cannonAnimator;

	// Use this for initialization
	void Start () {
        
        shooter = GetComponent<ShooterProjectile>();
        shipAnimator = GetComponent<Animator>();

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
            shipAnimator.SetBool("isBoosting", true);
        }
        else {
            shipAnimator.SetBool("isBoosting", false);
        }
        if (cannonAnimator)
        {
            if (Input.GetButton("Fire1"))
            {
                shooter.Shoot();

            }
            else
            {
                cannonAnimator.SetBool("fire", false);
            }
        }
	}
}
