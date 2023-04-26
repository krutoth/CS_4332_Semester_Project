using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthAmount = 10;
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
            //disable mesh
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            //disable collider
            gameObject.GetComponent<Collider>().enabled = false;
            other.transform.SendMessage("ApplyHeal", healthAmount);
            
            //respawn after X sec
            if (respawn)
            {
                Invoke("Respawn", delaySpawn);
            }
        }
    }

    void Respawn()
    {
        //make visible
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        //enable collider
        gameObject.GetComponent<Collider>().enabled = true;
    }
}
