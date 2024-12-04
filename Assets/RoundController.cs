using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundController : MonoBehaviour
{
    public int round = 1;
    public int highScore;
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI highScoreText;

    public CircleHandler circleHandler;
    public AimingController aimingController;
    public SquareSpawner squareSpawner;

    public AudioSource gameOver;
    public AudioSource nextLevel;

    [SerializeField]
    private bool isRoundActive = true;

    void Start()
    {
         highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;
    }

    // Update is called once per frame
    void Update()
    {
        roundText.text = "Score: " + round;
        if(highScore < round) 
        {
            highScore = round;
            highScoreText.text = "High Score: " + highScore;

            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
        if (isRoundActive && aimingController.allProjectilesDestroyed && circleHandler.outOfCircles)
        {
            EndRound();
        }
    }

    private void EndRound()
    {
        isRoundActive = false; 
        Debug.Log("Round completed!");

        
        circleHandler.ResetAmmo(round+1); 
        round++;
        StartNewRound();
    }
    private void StartNewRound()
    {
        isRoundActive = true;

        Debug.Log("Starting new round: " + round);
        squareSpawner.MoveSquaresDown(round);
        nextLevel.Play();
    }
}
