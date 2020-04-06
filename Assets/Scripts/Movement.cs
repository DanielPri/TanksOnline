using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviourPun
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private float BoostMagnitude = 2f;
    [SerializeField] private float boostDuration = 5f;

    private float boostTimeElapsed = 0f;
    private float currentMultiplier = 1f;

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
        HandleBoost();
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

        transform.Translate(movement * movementSpeed * currentMultiplier * Time.deltaTime);
        transform.Rotate(rotation * rotationSpeed * currentMultiplier * Time.deltaTime);
    }

    private void HandleBoost()
    {
        if(currentMultiplier == BoostMagnitude)
        {
            if(boostTimeElapsed > boostDuration)
            {
                currentMultiplier = 1f;
            }
            boostTimeElapsed += Time.deltaTime;
        }
    }


    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "PowerUp")
        {
            boostTimeElapsed = 0f;
            currentMultiplier = BoostMagnitude;
            Destroy(col.gameObject);
        }
    }
}
