using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject cameraObject;
    public float acceleration;
    public float walkAccelerationRatio;

    public float maxWalkSpeed;
    public float deaccelerate = 2;
    // [HideInInsepctor]
    public Vector2 horizontalMovement;

    // [HideInInsepctor]
    public float walkDeaccelerateX;
    // [HideInInsepctor]
    public float walkDeaccelerateZ;

    // [HideInInsepctor]
    public bool isGrounded = true;
    Rigidbody playerRigidBody;
    public float jumpVelocity = 20;
    float maxSlope = 45;

    // Start is called before the first frame update
    void Start()
    {
        //Getting rigidbody component from player
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Move();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerRigidBody.AddForce(0, jumpVelocity, 0);
        }
    }

    void Move()
    {
        horizontalMovement = new Vector2(playerRigidBody.velocity.x, playerRigidBody.velocity.z);

        if (horizontalMovement.magnitude > maxWalkSpeed)
        {
            horizontalMovement = horizontalMovement.normalized;
            horizontalMovement *= maxWalkSpeed;
        }

        playerRigidBody.velocity = new Vector3(horizontalMovement.x, playerRigidBody.velocity.y, horizontalMovement.y);
        transform.rotation = Quaternion.Euler(0, cameraObject.GetComponent<MouseLook>().currentY, 0);
        
        if(isGrounded)
            playerRigidBody.AddRelativeForce(Input.GetAxis("Horizontal") * acceleration, 0, Input.GetAxis("Vertical") * acceleration);
        else
            playerRigidBody.AddRelativeForce(Input.GetAxis("Horizontal") * acceleration * walkAccelerationRatio, 0, Input.GetAxis("Vertical") * walkAccelerationRatio * acceleration);

        if(isGrounded)
        {
            float xMove = Mathf.SmoothDamp(playerRigidBody.velocity.x, 0, ref walkDeaccelerateX, deaccelerate);
            float zMove = Mathf.SmoothDamp(playerRigidBody.velocity.z, 0, ref walkDeaccelerateZ, deaccelerate);
            playerRigidBody.velocity = new Vector3(xMove, playerRigidBody.velocity.y, zMove);
        }

    }

    void OnCollisionEnter(Collision coll) {

        foreach (ContactPoint contact in coll.contacts)
        {
            if(Vector3.Angle(contact.normal, Vector3.up) < maxSlope)
                isGrounded = true;
        }
    }

    void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.name.Equals("Plane")) {
            isGrounded = false;
        }
    }
}
