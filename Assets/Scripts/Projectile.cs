using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Projectile : MonoBehaviourPun
{
    [SerializeField] private float projectileSpeed;
    [SerializeField]
    private SoundManager soundmanager;
    // Start is called before the first frame update
    void Start()
    {
        soundmanager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
        GetComponent<Rigidbody>().velocity = transform.forward * projectileSpeed;
        Destroy(gameObject, 5f);
    }

    void Update()
    {
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Wall")
        {
            soundmanager.PlayWallBreak();
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "OuterWall")
        {
            Destroy(gameObject);
        }
    }
}
