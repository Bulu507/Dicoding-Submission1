using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerControl : MonoBehaviour
{
    #region Enums

    #endregion //Enums

    #region Public Variables

    #endregion //Public Variables

    #region Private Variables

    [SerializeField]
    private float xBoundaries = 576;
    private Animator anim;
    private Rigidbody2D rb;
    private bool facingRight;
    private Vector3 localScale;
    private GameObject player;
    private string IsMove = "IsMove";

    #endregion //Private Variables

    // (Unity Named Methods)
    #region Main Methods

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * 500f * Time.deltaTime, 0f, 0f);
        anim.SetBool(IsMove, false);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xBoundaries, xBoundaries),
            transform.position.y, transform.position.z); //boundaries

        if (Input.GetAxis("Horizontal") < 0)
        {
            anim.SetBool(IsMove, true);
            facingRight = false;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            anim.SetBool(IsMove, true);
            facingRight = true;
        }

        flip(facingRight);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.CompareTag("Enemy"))
        //{
        //    //Destroy(collision.gameObject);
        //    SceneManager.LoadScene("GameOver"); // Baris Ini akan digunakan pada submodul GameOver
        //}
    }

    #endregion //Main Methods

    //(Custom Named Methods)
    #region Utility Methods 

    private void flip(bool fc)
    {
        if ((fc && (localScale.x < 0)) || (!fc && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }

        transform.localScale = localScale;
    }

    #endregion //Utility Methods

    //Coroutines run parallel to other fucntions
    #region Coroutines

    #endregion //Coroutines
}
