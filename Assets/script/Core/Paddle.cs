using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float paddleSpeed = 10f;
    float barrier = 7.4f;
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");


        transform.Translate(Vector2.right * horizontal * Time.deltaTime * paddleSpeed);
        if (transform.position.x >= barrier)
        {
            transform.position = new Vector2(barrier, transform.position.y);
        }
        if (transform.position.x <= -barrier)
        {
            transform.position = new Vector2(-barrier, transform.position.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PowerUp"))
        {
            other.GetComponent<ExtraLives>().ApplyPowerUp();
            Destroy(other.gameObject);
        }
    }
}
