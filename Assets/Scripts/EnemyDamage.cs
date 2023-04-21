using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    //Private means only this script can access the variable.
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

    //Unity stores the collider it hits and we can access it via the name other.
    void OnCollisionEnter(Collision other)
    {
        //We compare the tag in the other object to the tag name we set earlier.
        if (other.collider.transform.CompareTag("bullet"))
        {
            //If the comparison is true, we increase the hit number.
            hitNumber++;
            // Add points per hit to score
            ScoreManager.gameScore += 5;
        }
        
        //if the hit number is equal to 3 we destroy this object.
        if (hitNumber == mobHealth)
        {
            // Add to score after a kill
            ScoreManager.gameScore += 50;
            gameObject.SetActive(false);
        }
    }
}
