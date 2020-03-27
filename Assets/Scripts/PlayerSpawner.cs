using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    [SerializeField] GameObject PlayerPrefab = null;
    [SerializeField] Transform P1Spawn;
    [SerializeField] Transform P2Spawn;
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(PlayerPrefab.name, P1Spawn.position, P1Spawn.rotation);
        }
        else
        {
            PhotonNetwork.Instantiate(PlayerPrefab.name, P2Spawn.position, P2Spawn.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
