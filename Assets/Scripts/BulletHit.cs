using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //disable on collision
    void OnCollisionEnter(Collision other)
    {
        //Find contact point
        ContactPoint contact = other.contacts[0];

        //Set pos/rot of particle
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        //Spawn particle
        Instantiate(particle, pos, rot);

        gameObject.SetActive(false);
    }
}
