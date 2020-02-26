using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public HighScores m_HighScores;

    public Text m_messageText;
    public Text m_timerText;

    public GameObject[] m_tanks;

    private float m_GameTime = 0;
    public float GameTime { get { return m_GameTime; } }

    public enum GameState
    {
        Start,
        Play,
        GameOver
    };

    private GameState m_GameState;
    public GameState State { get { return m_GameState; } }

    private bool OneTankLeft()
    {
        int numTanksLeft = 0;

        for (int i = 0; i < m_tanks.Length; i++)
        {
            if (m_tanks[i].activeSelf == true)
            {
                numTanksLeft++;
            }
        }
        return numTanksLeft <= 1;
    }

    private bool IsPlayerDead()
    {
        for (int i = 0; i < m_tanks.Length; i++)
        {
            if (m_tanks[i].activeSelf == false)
            {
                if (m_tanks[i].tag == "Player")
                    return true;
            }
        }
        return false;
    }
    public void Awake()
    {
        m_GameState = GameState.Start;
    }
    void Start()
    {
        for (int i = 0; i < m_tanks.Length; i++)
        {
            m_tanks[i].SetActive(false);
        }

        m_timerText.gameObject.SetActive(false);
        m_messageText.text = "Get Ready";
    }

    
    void Update()
    {
        switch (m_GameState)
        {
            case GameState.Start:
                if (Input.GetKeyUp(KeyCode.Return) == true)
                {
                    m_timerText.gameObject.SetActive(true);
                    m_messageText.text = "";

                    m_GameState = GameState.Play;
                    for (int i = 0; i < m_tanks.Length; i++)
                    {
                        m_tanks[i].SetActive(true);
                    }
                }
                break;
            case GameState.Play:
                bool isGameOver = false;

                m_GameTime += Time.deltaTime;
                int seconds = Mathf.RoundToInt(m_GameTime);

                m_timerText.text = string.Format("{0:D2}:{1:D2}", (seconds / 60), (seconds % 60));

                if (OneTankLeft() == true)
                {
                    isGameOver = true;
                }
                else if (IsPlayerDead() == true)
                {
                    isGameOver = true;
                }

                if (isGameOver == true)
                {
                    m_GameState = GameState.GameOver;
                    m_timerText.gameObject.SetActive(false);

                    if (IsPlayerDead() == true)
                    {
                        m_messageText.text = "Try Again";
                    }
                    else
                    {
                        m_messageText.text = "WINNER!";

                        m_HighScores.AddScore(Mathf.RoundToInt(m_GameTime));
                        m_HighScores.SaveScoresToFile();
                    }
                }
                break;
            case (GameState.GameOver):
                if (Input.GetKeyUp(KeyCode.Return) == true)
                {
                    m_GameTime = 0;
                    m_GameState = GameState.Play;

                    m_messageText.text = "";
                    m_timerText.gameObject.SetActive(true);

                    for (int i = 0; i < m_tanks.Length; i++)
                    {
                        m_tanks[i].SetActive(true);
                    }
                }
                break;

        }
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
