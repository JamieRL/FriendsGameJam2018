using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// © 2017 TheFlyingKeyboard and released under MIT License
// theflyingkeyboard.net
public class TopDownCharacterMovement : MonoBehaviour {
	private Rigidbody2D myRigidbody;
	[SerializeField] private float moveSpeed;
	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void FixedUpdate () {
        if(GameManager.gm) {
            if (GameManager.gm.gameIsOver) {
                return;
            }
        }

		Vector2 movingVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		myRigidbody.AddForce(movingVector * moveSpeed);
	}
}