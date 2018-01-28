using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{

    public static GameManager gm = null;

    public bool gameIsOver = true;

    public Button startButton;

    public Canvas menuCanvas;

    public int numberOfNodes = 1;

    private GameObject[] nodes;
    private GameObject[] musicTracks;

    private void Awake() {
        if (gm == null)
        {
            gm = this;
        }
        else if (gm != this) {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        musicTracks = GameObject.FindGameObjectsWithTag("BackgroundMusic");
        nodes = GameObject.FindGameObjectsWithTag("Node");
        
        setRandomMusic();
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
        
            
    }
    void startGame() {
        gameIsOver = false;
        menuCanvas.gameObject.SetActive(false);
    }

    public void restartGame() {
        gameIsOver = true;
        menuCanvas.gameObject.SetActive(true);
    }

    void setRandomMusic()
    {
        int trackNumber = Random.Range(0, musicTracks.Length - 1);
        Debug.Log(trackNumber);
        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
        AudioSource randomTrack = Instantiate(musicTracks[trackNumber].GetComponent<AudioSource>(), cam.transform);

        randomTrack.mute = false;
    }

    // Use this for initialization
    void Start()
    {
        Button btn = startButton.GetComponent<Button>();
        btn.onClick.AddListener(startGame);
    }

    // Update is called once per frame
    void Update()
    {
        
        foreach (GameObject node in nodes){
            if (!node.GetComponent<Node>().isPowered()){
                return;
            }
        }

        // TODO: Winning stuff here
        Debug.Log("Wow you win!");

    }
}
