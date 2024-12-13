using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*****************************************************
 * Attached to Monobehavior
 * Game manager for UI and Player
 * Sebastian Balakier
 * 12/9/24, Version 1.0
 ****************************************************/


public class GameManager : MonoBehaviour
{
    //fields
    [SerializeField] private TextMeshProUGUI scoreboardText;
    [SerializeField] private TextMeshProUGUI timeRemainingText;
    [SerializeField] private GameObject toggleGroup;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject spawnManager;
    [SerializeField] private Animator playerAnimatior;
    [SerializeField] private ParticleSystem dirtSplatter;
    public static bool gameOver {get; set; }
    private static float score;
    private AudioSource audioScource;
    private int timeRemaining = 60;
    private bool timedGame;


    // Start is called before the first frame update
    private void Start()
    {
        Time.timeScale = 0;
        spawnManager.SetActive(true);
        toggleGroup.SetActive(true);
        startButton.SetActive(true);
        audioScource = GetComponent<AudioSource>();
        timeRemainingText.gameObject.SetActive(true);

        InvokeRepeating(nameof(TimeCountdown), 1f, 1f);

        
        playerAnimatior.SetFloat("Speed_f", 1.0f);
        playerAnimatior.SetBool("BeginGame_b", true);
        DisplayUI();
        dirtSplatter.Play();
    }

    // Update is called once per frame
    private void Update()
    {
        DisplayUI();
        if(gameOver)
        {
            EndGame();
        }
     
    }

    // Score and countdown UI
    private void DisplayUI()
    {
        scoreboardText.text = "Score: " + Mathf.RoundToInt(score).ToString();

        if (timeRemaining > 0)
        {
            timeRemainingText.text = timeRemaining.ToString();
        }
    }

    // 1 minute game timer
    private void TimeCountdown()
    {
        if (timedGame)
        {
            if (timeRemaining > 0)
            {
                timeRemaining--;
                timeRemainingText.text = timeRemaining.ToString();
            }
            else
            {
                gameOver = true;
            }
        }
    }

    // Play audio at start of game
    public void StartGame()
    {
        Debug.Log("Started");
        Time.timeScale = 1;
        audioScource.Play();

        Debug.Log("Audio is playing");
    }

    // Game over
    private void EndGame()
    {
        playerAnimatior.SetBool("BeginGam_b", false);
        playerAnimatior.SetFloat("Speed_f", 0);
        audioScource.Stop();
        CancelInvoke("TimeCountdown");
    }

    // Timed game
    public void SetTimed(bool timed)
    {
        timedGame = timed;
        Debug.Log(timedGame);
    }

    // Increase score every collectable
    public static void ChangeScore(int change)
    {
        score += change;

        Debug.Log("Score is increasing");
    }
}
