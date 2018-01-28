﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : Health {


    // public float maxTimeDead = 5.0f;
    // private float timeDead = 0.0f;
    public float deathDelay = 1.0f;


    IEnumerator waitAndDestroy(){
        GetComponent<Animator>().SetBool("isDead", true);
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        yield return new WaitForSeconds(deathDelay);
        Destroy(gameObject);
    }
    // Override player die method
    public override void Die() {
        Collider2D[] colliders = new Collider2D[15];
        Collider2D m_collider = GetComponent<Collider2D>();
        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.useTriggers = true;

        m_collider.OverlapCollider(contactFilter, colliders);
        foreach (Collider2D col in colliders) {
            if (col)
            {
                if (col.gameObject.tag == "Node")
                {
                    col.gameObject.GetComponent<Node>().powerOn();


                    //kill the connector enemy
                    StartCoroutine(waitAndDestroy());
                }
            }
        }
        StartCoroutine(waitAndDestroy());

    }





    public override void Update()
    {
        
        if(health <= 0) {
            isAlive = false;
            Die();
        }


    }



}
