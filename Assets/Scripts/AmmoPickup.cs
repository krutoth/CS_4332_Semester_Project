using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammoAmount = 10;
    public bool respawn;
    public float delaySpawn = 30;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        //compare tag
        if (other.transform.CompareTag("Player"))
        {
            //Disable mesh
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            //We Disable collider
            gameObject.GetComponent<Collider>().enabled = false;
            //Broadcast
            other.transform.BroadcastMessage("ApplyAmmo", ammoAmount);
            //Respawn after X sec
            if (respawn)
            {
                Invoke("Respawn", delaySpawn);
            }
        }
    }

    void Respawn()
    {
        //Visible pickup
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        //enable collider
        gameObject.GetComponent<Collider>().enabled = true;
    }
}
