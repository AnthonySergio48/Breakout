using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : BrickParent
{ 
    [SerializeField] Transform toxicGas;
    [SerializeField] Transform contents;
    
    public override void TakeDamage(int damageAmount)
    {
       hitPoints -= damageAmount;

        if (hitPoints <= 0)
        {
            DestroyBrick();
        }
        else
        {
            DamageBrick();
        }
    }
   
    void DestroyBrick()
    {
       GameManager.i.UpdateNumberOfBricks();
        GameManager.i.UpdateScore(pointValue);
        var go = Instantiate(toxicGas, transform.position, transform.rotation);
        Destroy(go.gameObject, 2.25f);
        Destroy(gameObject);
    }
    void ApplyBrickEffect()
    {
       /* if (Random.Range(0f, 1f) > .2f)
        {
            Instantiate(contents, transform.position, Quaternion.identity);
        }*/
    }
}