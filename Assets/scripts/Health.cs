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


    public AudioClip explosionClip;

    public float deathDelay = 0.6f;

    public float deathViewTime = 2.0f;

    public Animator deathAnimator;
    public AudioSource deathAudioSource;

    public GameObject deathEmitters;

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

    private void GameOver() {
        SceneManager.LoadScene(LevelToLoad);

    }

    public virtual void Die() {
        numLives = numLives - 1;
        isAlive = false;
        explode();
        if (numLives < 0)
        {
            GameOver();
            StartCoroutine(waitAndGameOver());
        }
        else {
            StartCoroutine(waitAndRespawn());
        }


    }

    private void freeze() {
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GetComponent<Rigidbody2D>().angularVelocity = 0;

    }

    private void unFreeze(){
        GetComponent<Rigidbody2D>().isKinematic = false;

    }

    IEnumerator waitAndGameOver()
    {
        freeze();
        yield return new WaitForSeconds(deathDelay);
        deathAnimator.SetBool("isDead", false);

        DestroyObject(gameObject);

    }

    IEnumerator waitAndRespawn()
    {
        freeze();
        yield return new WaitForSeconds(deathDelay);
        deathAnimator.SetBool("isDead", false);

        Respawn();

    }

    public virtual void Respawn() {
        
        isAlive = true;
        transform.position = respawnPosition;
        transform.rotation = respawnRotation;

        health = respawnHealthPoints;

        deathAnimator.SetBool("isDead", false);

        deathEmitters.SetActive(false);

        unFreeze();

    }

    private void explode(){
        deathAnimator.SetBool("isDead", true);
        deathEmitters.SetActive(true);
        AudioSource.PlayClipAtPoint(explosionClip, Camera.main.transform.position);
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
            if (isAlive)
            {
                Die();
            }
            else {
                deathAnimator.SetBool("isDead", false);
            }
        }

	}
}
