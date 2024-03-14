using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLives : MonoBehaviour
{
    [SerializeField] float fallSpeed;

    private void Update()
    {
        FallDown();
    }

    void FallDown()
    {
        transform.Translate(Vector2.down * Time.deltaTime * fallSpeed);
    }

    public void ApplyPowerUp()
    {
       // GameManager.i.UpdateNumberOfLives(livesToAdd);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Bottom"))
        {
            Destroy(this.gameObject);
        }
    }

}
