using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

public class Cannon : MonoBehaviourPun
{
    [SerializeField] private float projectileSpeed;
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
            photonView.RPC("FireProjectile", RpcTarget.All);
        }
    }

    [PunRPC]
    private void FireProjectile()
    {
        var shellInstance = Instantiate(shellPrefab, spawnPoint.position, spawnPoint.rotation);

        shellInstance.GetComponent<Rigidbody>().velocity = shellInstance.transform.forward * projectileSpeed;
        Destroy(shellInstance, 5f);
    }
}
