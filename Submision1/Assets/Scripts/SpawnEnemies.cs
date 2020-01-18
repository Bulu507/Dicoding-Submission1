using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    #region Enums

    #endregion //Enums

    #region Public Variables

    public GameObject enemyObj;
    public float delay;
    public float startDelay;

    #endregion //Public Variables

    #region Private Variables

    private float timer;
    private bool isStart;

    #endregion //Private Variables

    // (Unity Named Methods)
    #region Main Methods

    void Start()
    {
        timer = 0;
        isStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (isStart)
        {
            if (timer > startDelay)
            {
                isStart = false;
                timer = 0;
                Instantiate(enemyObj, transform.position, transform.rotation);
            }
        }
        else
        {
            if (timer > delay)
            {
                Instantiate(enemyObj, transform.position, transform.rotation);
                timer = 0;
            }
        }
    }

    #endregion //Main Methods

    //(Custom Named Methods)
    #region Utility Methods 

    #endregion //Utility Methods

    //Coroutines run parallel to other fucntions
    #region Coroutines

    #endregion //Coroutines
}
