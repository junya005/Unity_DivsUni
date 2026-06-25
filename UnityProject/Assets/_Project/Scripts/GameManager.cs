using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static bool inGame;
    private bool is_gameOver;
    public float Score;
    public int now_Levels;
    public int playerHP;
    public float sanso;
    public int sansoJougen;
    public GameObject soundManagerObj;
    private SoundManager soundManager;
    public GameObject displayText;
    public Slider o2Gauge;
    public GameObject playerLife1;
    public GameObject playerLife2;
    public GameObject playerLife3;
    public GameObject gameoverPanel;
    public SC_ScoreDataBase sc_scoreDataBase;
    public GameObject resultScoreText;

    void Start()
    {
        gameoverPanel.SetActive(false);
        inGame = true;
        is_gameOver = false;
        now_Levels = 1;
        sanso = sansoJougen;
        soundManager = soundManagerObj.GetComponent<SoundManager>();
        soundManager.PlayBGM(1);
    }

    void Update()
    {
        if (inGame) 
        {
            sanso -= Time.deltaTime;
            o2Gauge.value = sanso / sansoJougen;

            if(sanso > sansoJougen)
            {
                sanso = sansoJougen;
            }

            PlayerHPAnim();
        }

        if(!is_gameOver)
        {
            if(playerHP == 0)
            {
                GameOver();
                is_gameOver = true;
            }
            else if(sanso < 0)
            {
                GameOver();
                is_gameOver = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (inGame) 
        {
            Score += Time.deltaTime;
            DisplayScore();

            if (Score > 20)
            {
                now_Levels = 2;
            }
            if (Score > 90) 
            {
                now_Levels = 3;
            }
            if (Score > 180) 
            { 
                now_Levels = 4;
            }
        }
    }

    private void DisplayScore()
    {
        String scoreText = Score.ToString("f0");
        displayText.GetComponent<TextMeshProUGUI>().text = "";
        for(int i = 0;i <= scoreText.Length - 1; i++)
        {
            displayText.GetComponent<TextMeshProUGUI>().text += scoreText[i];
        }
    }

    private void PlayerHPAnim()
    {
        if(playerHP == 2)
        {
            Animator animator;
            animator = playerLife3.GetComponent<Animator>();
            animator.SetTrigger("is_Damaged");
        }
        else if(playerHP == 1)
        {
            Animator animator;
            animator = playerLife2.GetComponent<Animator>();
            animator.SetTrigger("is_Damaged");
        }
        else if(playerHP == 0)
        {
            Animator animator;
            animator = playerLife1.GetComponent<Animator>();
            animator.SetTrigger("is_Damaged");
        }
    }

    private void GameOver()
    {
        inGame = false;
        soundManager.StopBGM();
        soundManager.PlaySE(1);
        resultScoreText.GetComponent<TextMeshProUGUI>().text = Score.ToString("f0");
        gameoverPanel.SetActive(true);
    }
}
