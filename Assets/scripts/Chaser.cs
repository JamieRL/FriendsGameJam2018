using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour {

    public Transform target;
    public float moveSpeed = 3;
    public float minFollowDistance = 0;

    private Rigidbody2D rigidbody2d;

	// Use this for initialization
	void Start () {
        rigidbody2d = GetComponent<Rigidbody2D>();
        if(!target) {
            target = GameObject.FindWithTag("Player").transform;
        }
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 dirToTarget = Vector3.Normalize(target.position - transform.position);
        float distance = Vector3.Distance(transform.position, target.position);

        transform.up = dirToTarget;

        if (distance > minFollowDistance)
        {
            rigidbody2d.velocity = new Vector2(dirToTarget.x * moveSpeed, dirToTarget.y * moveSpeed);
        }
        else
        {
            rigidbody2d.velocity = new Vector2(0, 0);
        }
	}
}
