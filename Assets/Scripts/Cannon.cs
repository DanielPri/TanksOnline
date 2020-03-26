using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

public class Cannon : MonoBehaviourPun
{
    [SerializeField] private GameObject shellPrefab;
    [SerializeField] private Transform spawnPoint;

    private void Update()
    {
        if (photonView.IsMine)
        {
            TakeInput();
        }
    }

    private void TakeInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            PhotonNetwork.Instantiate(shellPrefab.name, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
