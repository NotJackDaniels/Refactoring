using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePersonWithArrows : MonoBehaviour {

    public float speed = 6.0f;
    public float degreesPerSecond = 90f;
    Quaternion targetRotation;
    Quaternion personRotation;
    private Vector3 moveDirection = Vector3.zero;


    void Update ()
    {
        personRotation = GameObject.Find("Player").transform.rotation;
        moveDirection = new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical"));
        moveDirection *= speed;

        Vector3 xzDirection = new Vector3(moveDirection.x, 0, moveDirection.z);
        if (xzDirection.magnitude > 0)
            targetRotation = Quaternion.LookRotation(xzDirection) * personRotation;
        transform.rotation = Quaternion.RotateTowards(transform.rotation,
            targetRotation, degreesPerSecond * Time.deltaTime);
    }
}
