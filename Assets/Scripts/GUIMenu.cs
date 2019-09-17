using Assets.Scripts.Helpers;
using Assets.Scripts.StoredData;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIMenu : MonoBehaviour {
    Text highscoreText;
    Text highscoreNumber;
    Text scoreNumber;
    Text gameOverText;
    Image restartIcon;

    double personalHighscore;
    static double personalScore;

    public static double PersonalScore
    {
        get
        {
            return personalScore;
        }

        set
        {
            personalScore = value;
        }
    }

    // Use this for initialization
    void Start () {
        Init();
        HideAllComponents();
	}
	void Init()
    {
        highscoreText = CanvasGUIHelpers.GetTextByName(transform,"HighscoreText");
        highscoreNumber = CanvasGUIHelpers.GetTextByName(transform, "HighscoreNumber");
        scoreNumber = CanvasGUIHelpers.GetTextByName(transform, "ScoreNumber");
        gameOverText = CanvasGUIHelpers.GetTextByName(transform, "GameOverText");
        restartIcon = CanvasGUIHelpers.GetImageByName(transform, "RestartIcon");


        highscoreNumber.text = Math.Floor(StoredGUIProperties.StoredHighscore).ToString().PadLeft(5, '0');

        personalScore = 0;
        personalHighscore = StoredGUIProperties.StoredHighscore;
        
    }
	// Update is called once per frame
	void Update () {
        if(!RexMovement.IsStart && !RexMovement.IsDead)
        {
            return;
        }
        else if(RexMovement.IsStart && !RexMovement.IsDead)
        {
            StartGamePopUp();
        }
        else if (RexMovement.IsDead && !RexMovement.IsStart)
        {
            GameOverPopUp();
            if (StoredGUIProperties.StoredHighscore < personalHighscore)
            {
                StoredGUIProperties.StoredHighscore = personalHighscore;
            }            
            if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Mouse0))
            {
                SceneManager.LoadScene("SampleScene");
            }
            return;
        }
        CountScore();
    }
    void CountScore()
    {
        personalScore += 0.2;
        scoreNumber.text = Math.Floor(personalScore).ToString().PadLeft(5, '0');
        if (personalScore > personalHighscore)
        {
            personalHighscore = personalScore;
            highscoreNumber.text = Math.Floor(personalHighscore).ToString().PadLeft(5, '0');
        }
    }
    void HideAllComponents()
    {
        highscoreText.enabled = false;
        highscoreNumber.enabled = false;
        scoreNumber.enabled = false;
        gameOverText.enabled = false;
        restartIcon.enabled = false;
    }
    void StartGamePopUp()
    {
        scoreNumber.enabled = true;
    }
    void GameOverPopUp()
    {
        highscoreText.enabled = true;
        highscoreNumber.enabled = true;
        gameOverText.enabled = true;
        restartIcon.enabled = true;
    }
}
