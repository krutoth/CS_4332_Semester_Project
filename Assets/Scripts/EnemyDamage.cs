using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private int hitNumber;
    public int mobHealth = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        hitNumber = 0;
    }

    //store collider hit
    void OnCollisionEnter(Collision other)
    {
        //compare tag
        if (other.collider.transform.CompareTag("bullet"))
        {
            //inc hit number
            hitNumber++;
            // Add points per hit to score
            ScoreManager.gameScore += 5;
        }
        
        //if the hit number = X, destroy
        if (hitNumber == mobHealth)
        {
            // Add to score after a kill
            ScoreManager.gameScore += 50;
            gameObject.SetActive(false);
        }
    }
}
