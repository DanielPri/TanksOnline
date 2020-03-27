using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICannon : MonoBehaviour
{

    [SerializeField] private GameObject shellPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float cooldown = 0.5f;
    private float timeElapsedSinceFire = 0;
    private void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(spawnPoint.position, spawnPoint.forward);
        if(Physics.Raycast(ray,out hit))
        {
            Debug.Log("Raycast is " + hit.transform.tag);
            if (hit.transform.tag == "Player")
            {
                Fire();   
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
