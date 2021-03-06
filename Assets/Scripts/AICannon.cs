﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICannon : MonoBehaviourPun
{

    [SerializeField] private GameObject shellPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float cooldown = 0.5f;
    [SerializeField]
    private float range = 10f;
    private float timeElapsedSinceFire = 0;
    private void Update()
    {
        if (photonView.IsMine)
        {
            HandleCannon();
        }
    }

    private void HandleCannon()
    {
        RaycastHit hit;
        Ray ray = new Ray(spawnPoint.position, spawnPoint.forward);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.tag == "Player")
            {
                if ((hit.transform.position - transform.position).magnitude < range)
                {
                    Fire();
                }
            }
        }
        timeElapsedSinceFire += Time.deltaTime;
    }

    private void Fire()
    {
        if(timeElapsedSinceFire > cooldown)
        {
            timeElapsedSinceFire = 0;
            PhotonNetwork.Instantiate(shellPrefab.name, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
