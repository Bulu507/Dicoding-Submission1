using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    #region Enums

    #endregion //Enums

    #region Public Variables

    public Sprite[] sprites;

    #endregion //Public Variables

    #region Private Variables

    [SerializeField]
    private float moveDirection = 1;
    private float randomSpeed;
    private float randomScale;
    private float randomVelocityY;
    private Rigidbody2D rb;

    #endregion //Private Variables

    // (Unity Named Methods)
    #region Main Methods

    // Start is called before the first frame update
    void Start()
    {
        randomSpeed = Random.Range(30, 70); 
        randomScale = Random.Range(30, 80);
        randomVelocityY = Random.Range(200, 220);
        int index = Random.Range(0, sprites.Length);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[index];
        transform.localScale = new Vector3(randomScale, randomScale, 0);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = (randomSpeed * Time.deltaTime * moveDirection) + transform.position.x;
        transform.position = new Vector3(move, transform.position.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // make a stable bounce
        rb.velocity = new Vector2(rb.velocity.x, randomVelocityY);
    }

    #endregion //Main Methods

    //(Custom Named Methods)
    #region Utility Methods 

    #endregion //Utility Methods

    //Coroutines run parallel to other fucntions
    #region Coroutines

    #endregion //Coroutines
}

