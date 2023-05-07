using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendDamage : MonoBehaviour
{
    public int appliedDamage = 1;

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
        // compare other object tag to prev tag
        if (other.collider.transform.CompareTag("Player"))
        {
            // if =, send message to other object
            // pass dmg value
            other.transform.SendMessage("ApplyDamage", appliedDamage);
        }
    }
}
