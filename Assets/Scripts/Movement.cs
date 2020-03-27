using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviourPun
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            TakeInput();
        }
        transform.position = new Vector3
        {
            x = transform.position.x,
            y = 0f,
            z = transform.position.z
        };
        // transform.rotation = Quaternion.Euler(0, transform.rotation.y, 0);
    }

    private void TakeInput()
    {
        Vector3 movement = new Vector3
        {
            x = 0f, // Input.GetAxisRaw("Horizontal"),
            y = 0f,
            z = Input.GetAxisRaw("Vertical")
        }.normalized;

        Vector3 rotation = new Vector3
        {
            x = 0f,
            y = Input.GetAxisRaw("Horizontal"),
            z = 0f
        };

        transform.Translate(movement * movementSpeed * Time.deltaTime);
        transform.Rotate(rotation * rotationSpeed * Time.deltaTime);
    }
}
