﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour {


    public int health;
    public int numLives;
    public bool isAlive = true;
    public int respawnHealthPoints;
    private Vector2 respawnPosition;
    private Quaternion respawnRotation;

    private float deathTime = 0.0f;

    public float deathViewTime = 2.0f;


    public string LevelToLoad = "";

	// Use this for initialization
	void Start () {
        respawnPosition = transform.position;
        respawnRotation = transform.rotation;

        if (LevelToLoad == "") // default to current scene 
        {
            LevelToLoad = SceneManager.GetActiveScene().name;
        }
	}

    public void damageHealth(int amount) {
        health = health - amount;
    }

    public void heal(int amount) {
        health = health + amount;
    }

    public virtual void Die() {
        SceneManager.LoadScene(LevelToLoad);

    }

    public virtual void Respawn() {
        numLives = numLives - 1;
        transform.position = respawnPosition;
        transform.rotation = respawnRotation;
        health = respawnHealthPoints;
    }
	
	// Update is called once per frame
	public virtual void Update () {
        if (GameManager.gm)
        {
            if (GameManager.gm.gameIsOver)
            {
                return;
            }
        }

        if(health <= 0) {

            //kill actor
            if (numLives > 0) {
                Respawn();
            }
            else {

                isAlive = false;
                Die();
            }
        }
        else {
            deathTime = 0.0f;
        }

	}
}
