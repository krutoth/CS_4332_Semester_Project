using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay(Collision other)
    {
        //We compare the tag in the other object to the tag name we set earlier.
        if (other.transform.CompareTag("Player"))
        {
            //If the above matches, then send a message to the other object.
            //This will also pass a value of 1 for our damage. 
            other.transform.SendMessage("ApplyDamage", 1);
        }
    }
}
