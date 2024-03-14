using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float ballspeed = 500f;
    [SerializeField] Transform playerPaddle;

    bool inPlay = false;
    Rigidbody2D rb;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    

    private void Update()
    {
        if (!inPlay)
        {
            transform.position = playerPaddle.position;
        }
       if (Input.GetButtonDown("Jump") && !inPlay)
       {
           inPlay = true;
           rb.AddForce(Vector2.up * ballspeed);
       }
    } 
    public void ResetBall()
    {
        transform.position = playerPaddle.position;
        inPlay = false;
        rb.velocity = Vector2.zero;
    }
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.CompareTag("Bottom Wall"))
        {
            ResetBall();
            if (!GameManager.i.LevelPassed())
            {
                print("working");
                GameManager.i.UpdateNumberOfLives();

            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
   
       if (other.gameObject.CompareTag("Brick"))
       {
            other.gameObject.GetComponent<BrickParent>().TakeDamage(1);
       }
       
    }
    
}

    

