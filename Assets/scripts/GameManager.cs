using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    public static GameManager gm = null;

    public bool gameIsOver = true;

    public Button startButton;

    public Button instructionButton;

    public Button hideInstructionButton;

    public Canvas menuCanvas;

    public Canvas instructionsCanvas;

    public int numberOfNodes = 1;

    private GameObject[] nodes;
    private GameObject[] musicTracks;

    public string SceneToLoad = "";

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
        //DontDestroyOnLoad(gameObject);
        if(SceneToLoad ==""){
            SceneToLoad = SceneManager.GetActiveScene().name;
        }
        
            
    }
    void startGame() {
        gameIsOver = false;
        menuCanvas.gameObject.SetActive(false);
    }
    void showInstructions()
    {
        instructionsCanvas.gameObject.SetActive(true);
        menuCanvas.gameObject.SetActive(false);
    }

    void hideInstructions()
    {
        instructionsCanvas.gameObject.SetActive(false);
        menuCanvas.gameObject.SetActive(true);
    }
    public void restartGame() {
        gameIsOver = true;
        menuCanvas.gameObject.SetActive(true);
    }

    void setRandomMusic()
    {
        int trackNumber = Random.Range(0, musicTracks.Length - 1);
        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
        AudioSource randomTrack = Instantiate(musicTracks[trackNumber].GetComponent<AudioSource>(), cam.transform);

        randomTrack.mute = false;
    }

    // Use this for initialization
    void Start()
    {
        Button strtbtn = startButton.GetComponent<Button>();
        Button instrbtn = instructionButton.GetComponent<Button>();
        Button hideinstrbtn = hideInstructionButton.GetComponent<Button>();

        strtbtn.onClick.AddListener(startGame);
        instrbtn.onClick.AddListener(showInstructions);
        hideinstrbtn.onClick.AddListener(hideInstructions);

      
    }

    // Update is called once per frame
    void Update()
    {
        //repopulate nodes upon restart
        if(nodes.Length == 0) {
            nodes = GameObject.FindGameObjectsWithTag("Node");

        }
        
        foreach (GameObject node in nodes){
            if (!node.GetComponent<Node>().isPowered()){
                return;
            }
        }

        // TODO: Winning stuff here
        Debug.Log("Wow you win!");
        SceneManager.LoadScene(SceneToLoad);


    }
}
