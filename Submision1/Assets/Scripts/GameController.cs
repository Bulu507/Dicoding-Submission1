using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    #region Enums

    #endregion //Enums

    #region Public Variables

    public static float Score;
    public GameObject[] onScreenObj;
    public Text txtLastScore;
    public GameObject PanelGameOver;

    #endregion //Public Variables

    #region Private Variables

    private bool isPaused = false;
    private GameObject[] enemies;
    private Text txtScore;

    #endregion //Private Variables

    // (Unity Named Methods)
    #region Main Methods

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        txtScore = GameObject.Find("ScoreTxt").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Score += Time.deltaTime;
        txtScore.text = Mathf.Round(Score).ToString();

        if(PlayerControl.IsGameOver == true)
        {
            PlayerControl.IsGameOver = false;
            GameOver();
        }
    }

    #endregion //Main Methods

    //(Custom Named Methods)
    #region Utility Methods 

    public void IsPauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            SetVisible(true);
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
            SetVisible(false);
        }
    }

    public void SetVisible(bool b)
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject e in enemies)
        {
            e.GetComponent<SpriteRenderer>().enabled = b;
        }
    }

    public void GameOver()
    {
        txtLastScore.text = Mathf.Round(Score).ToString();
        IsPauseGame();
        //SetVisible(false);
        foreach(GameObject g in onScreenObj)
        {
            g.SetActive(false);
        }
        PanelGameOver.SetActive(true);
    }

    #endregion //Utility Methods

    //Coroutines run parallel to other fucntions
    #region Coroutines

    #endregion //Coroutines
}
