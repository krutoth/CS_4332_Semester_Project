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

    //When we touch the collider we disable this object.
    void OnCollisionEnter(Collision other)
    {
        //Find the contact point on the object we collided with.
        ContactPoint contact = other.contacts[0];

        //Set the exact position and rotation we hit the collider at.
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        //Spawn our particle using the above parameters.
        Instantiate(particle, pos, rot);

        gameObject.SetActive(false);
    }
}
