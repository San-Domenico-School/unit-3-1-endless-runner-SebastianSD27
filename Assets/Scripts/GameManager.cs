using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class GameManager : MonoBehaviour
{
    //field
    [SerializeField] private TextMeshProUGUI scoreboardText;
    [SerializeField] private TextMeshProUGUI timeRemainingText;
    [SerializeField] private GameObject toggleGroup;
    [SerializeField] private GameObject startButton;
    [SerializeField] private GameObject spawnManager;
    [SerializeField] private Animator playerAnimatior;
    [SerializeField] private ParticleSystem dirtSplatter;
    public static bool gameOver {get; set; }
    private float score;
    private AudioSource audioScource;
    private int timeRemaining = 60;
    private bool timedGame;

    // Start is called before the first frame update
    private void Start()
    {
        gameOver = false;

        spawnManager.SetActive(true);

        toggleGroup.SetActive(false);

        startButton.SetActive(false);

        timeRemainingText.gameObject.SetActive(true);

        InvokeRepeating(nameof(TimeCountdown), 1f, 1f);

        playerAnimatior.SetFloat("Speed_f", 1.0f);

        playerAnimatior.SetBool("BeginGame_b", true);
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void DisplayUI()
    {

    }

    private void TimeCountdown()
    {

    }

    public void StartGame()
    {
        audioScource.Play();
    }

    private void EndGame()
    {

    }

    public void SetTimed(bool timed)
    {

    }

    private void ChangeScore(int change)
    {

    }
}
