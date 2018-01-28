﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Chaser))]
public class EnemyPatroller : MonoBehaviour {
    public float moveSpeed = 5.0f;
    public float directionChangeRate = 1.0f;

    private Chaser chaseBehaviour;
    private float timeSinceDirectionChange;
    private Rigidbody2D enemyRigidbody2d;
    private Vector3 startPos;
    private Vector3 endPos;

    // Use this for initialization
    void Awake() {
        chaseBehaviour = GetComponent<Chaser>();
        enemyRigidbody2d = GetComponent<Rigidbody2D>();
        timeSinceDirectionChange = 0.0f;

        chaseBehaviour.enabled = false;

    }

    void Start()
    {
        startPos = transform.position;
        GetNewDirection();

        Debug.Log("endPos: " + endPos);

    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Chasing");
            chaseBehaviour.enabled = true;
        }
    }


    void OnTriggerExit2D (Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Stopped Chasing");
            chaseBehaviour.enabled = false;
            GetNewDirection();
            enemyRigidbody2d.velocity = new Vector2(0, 0);
        }
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Border")
        {
            Debug.Log("Hit a wall");
        }
    }

    void Update()
    {
        if (!chaseBehaviour.enabled)
        {
            if (Vector3.Distance(transform.position, endPos) < 1)
            {
                GetNewDirection();
            }

            transform.position = Vector3.MoveTowards(transform.position, endPos, Time.deltaTime * moveSpeed);
        }
        
    }

    void GetNewDirection()
    {
        Vector3 newDirection = new Vector3(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), 0);
        endPos = startPos + newDirection;
    }
   
}