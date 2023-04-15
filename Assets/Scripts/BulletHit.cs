using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //When we touch the collider we disable this object.
    void OnCollisionEnter()
    {
        gameObject.SetActive(false);
    }
}
