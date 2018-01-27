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
                SceneManager.LoadScene(LevelToLoad);

            }
            else {
                transform.position = respawnPosition;
                transform.rotation = respawnRotation;
                health = respawnHealthPoints;

            }
        }

	}
}
