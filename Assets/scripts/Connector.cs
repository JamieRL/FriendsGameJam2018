using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connector : Health {


    private CircleCollider2D deathRadius = null;
    private bool connected = false;
    public float maxTimeDead = 5.0f;
    private float timeDead = 0.0f;
    private bool connectedToTower = false;

    private ArrayList connectedObjects;

    private void Awake()
    {
        connectedObjects = new ArrayList();
    }


    // Override player die method
    public override void Die() {
        Collider2D[] colliders = new Collider2D[15];
        Collider2D m_collider = GetComponent<Collider2D>();

        m_collider.OverlapCollider(new ContactFilter2D(), colliders);

        foreach (Collider2D col in colliders) {
            if(col.gameObject.tag == "Node"){
                col.gameObject.GetComponent<Node>().powerOn();

                //kill the connector enemy
                Destroy(gameObject);
            }
        }
    }

    public override void Respawn() {
        connected = false;
    }




    public override void Update()
    {
        base.Update();


    }



}
