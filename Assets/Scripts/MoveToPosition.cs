using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPosition : MonoBehaviour
{
    public float speed = 5f;
    public float knockbackTime = 1;
    public float kick = 1.8f;
    private Transform goal;
    private NavMeshAgent agent;
    private bool hit;
    private ContactPoint contact;
    private float timer;
    

    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();

        //knockback timer
        timer = knockbackTime;
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = Vector3.MoveTowards(transform.position, target.position, speed*Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (hit)
        {
            //physics
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            //stop AI
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            //puch back w/ kick var
            gameObject.GetComponent<Rigidbody>().AddForceAtPosition(Camera.main.transform.forward * kick, contact.point, ForceMode.Impulse);
            hit = false;
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
            //after X sec, continue
            if (knockbackTime < timer)
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.GetComponent<NavMeshAgent>().isStopped = false;
                agent.SetDestination(goal.position);
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        //compare bullet tag
        if (other.transform.CompareTag("bullet"))
        {
            contact = other.contacts[0];
            hit = true;
        }
    }
}
