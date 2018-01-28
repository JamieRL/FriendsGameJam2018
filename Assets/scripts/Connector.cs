using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : Health {


   // public float maxTimeDead = 5.0f;
   // private float timeDead = 0.0f;


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
                    Destroy(gameObject);
                }
            }
        }
        Destroy(gameObject);

    }





    public override void Update()
    {
        base.Update();


    }



}
