using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviourPun
{
    [SerializeField] private float movementSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            TakeInput();
        }
    }

    private void TakeInput()
    {
        Vector3 movement = new Vector3
        {
            x = Input.GetAxisRaw("Horizontal"),
            y = 0f,
            z = Input.GetAxisRaw("Vertical")
        }.normalized;

        transform.Translate(movement * movementSpeed * Time.deltaTime);
    }
}
