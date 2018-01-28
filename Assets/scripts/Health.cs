using System.Collections;
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
	
	// Update is called once per frame
	void Update () {
        if (GameManager.gm)
        {
            if (GameManager.gm.gameIsOver)
            {
                return;
            }
        }
        
        if(health <= 0) {
            
            //kill actor
            numLives = numLives - 1;
            if(numLives <= 0) {
                isAlive = false;
                deathTime += Time.deltaTime;
                //animator.setBool("isDead", true);
                if (deathTime >= deathViewTime)
                {
                    SceneManager.LoadScene(LevelToLoad);
                }

            }
            else {

                //signal the explosion animator
                //animator.setBool("isDead", true);
                deathTime += Time.deltaTime;

                //hold off on respawning the player until you the explosion is done
                if (deathTime >= deathViewTime)
                {
                    //animator.setBool("isDead", false);
                    transform.position = respawnPosition;
                    transform.rotation = respawnRotation;
                    health = respawnHealthPoints;
                }

            }
        }
        else {
            deathTime = 0.0f;
        }

	}
}
