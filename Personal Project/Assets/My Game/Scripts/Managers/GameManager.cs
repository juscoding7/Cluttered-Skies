using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;

    // GUI
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public GameObject gameOver;
    public GameObject buttons;
    public GameObject settingsButton;
    public Button restartButton;
    public GameObject gameTitle;
    public GameObject pauseScreen;
    public GameObject settingsScreen;
    private bool paused;

    // I think this one is obvious
    public GameObject player;
    public GameObject MSplayer;

    // Audio
    private AudioSource playerAudio;
    public AudioClip crashSound;

    // Particles
    public ParticleSystem explosionParticle;

    // Point System
    private int score;

    // Spawn Rate of enemies
    private float spawnRate = 1.0f;

    // "Starting" the Game
    public bool isGameActive;
    public SpawnManager spawnManager;
    public GameObject spawnManagerParent;

    // Start is called before the first frame update
    void Start()
    {
        if (!spawnManagerParent.activeSelf)
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        playerAudio = GetComponent<AudioSource>();

    }
    // Pause Menu
    void ChangePaused()
    {
        if (!gameTitle.activeSelf)
        {

           
 
            if (!paused)
            {
                if (!settingsScreen.activeSelf)
                {
                    if (!gameOver.activeSelf)
                    {
                        paused = true;
                        pauseScreen.SetActive(true);
                        Time.timeScale = 0;
                    }
                }
            }
                else
                {
                    if (!settingsScreen.activeSelf)
                    {
                      paused = false;
                      pauseScreen.SetActive(false);
                      Time.timeScale = 1;
                    }
                }
 
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        // For Build
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        //Check if the user has pressed the P key
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangePaused();
        }
    }

    // Keyword, SpawnTarget
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            spawnManager.SpawnRandomEnemy();

        }

    }
    // Just guess what this does 0_0
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;

        // This just doesn't want to work for some reason, I don't want my score to go into the negative
/*        if (score < 0)
        {
            score = 0;
        }
*/
    }
    // Dang you lost >:{
    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(true);
        isGameActive = false;
        playerAudio.PlayOneShot(crashSound, 1.0f);

    }
    // DO OVER!
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // I think you know what this one does :p
    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0;
        spawnRate /= difficulty;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);

        // All the things that have to be turned off or on for the title screen transitioning to the gameplay
        scoreText.gameObject.SetActive(true);
        buttons.gameObject.SetActive(false);
        settingsButton.gameObject.SetActive(false);
        gameTitle.gameObject.SetActive(false);
        player.gameObject.SetActive(true);
        MSplayer.gameObject.SetActive(false);
        spawnManager.gameObject.SetActive(true);
    }
    
}

