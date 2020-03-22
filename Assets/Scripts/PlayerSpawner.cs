using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{

    [SerializeField] GameObject PlayerPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate(PlayerPrefab.name, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
