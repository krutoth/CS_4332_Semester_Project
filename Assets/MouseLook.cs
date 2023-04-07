using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player Rotation based off Mouse Input

public class MouseLook : MonoBehaviour
{

    public float lookSensitivity = 2f, lookSmoothDamp = .5f;
    // [HideInInsepctor]
    public float yRot , xRot;
    // [HideInInsepctor]
    public float currentY , currentX;
    // [HideInInsepctor]
    public float yRotationV , xRotationV;

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }

    // values from Mouse Axes
    void LateUpdate() {
        yRot += Input.GetAxis("Mouse X") * lookSensitivity; 
        yRot += Input.GetAxis("Mouse Y") * lookSensitivity;

        currentX = Mathf.SmoothDamp(currentX, xRot, ref xRotationV, lookSmoothDamp);
        currentY = Mathf.SmoothDamp(currentY, yRot, ref yRotationV, lookSmoothDamp);

        xRot = Mathf.Clamp(xRot, -80, 80);

        transform.rotation = Quaternion.Euler(-currentX, currentY, 0);
    }

}
