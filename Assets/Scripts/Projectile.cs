using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Projectile : MonoBehaviourPun
{
    [SerializeField] private float projectileSpeed;
    // Start is called before the first frame update
    void Start()
    {
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
            GameObject.Find("SoundManager").GetComponent<SoundManager>().PlayWallBreak();
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "OuterWall")
        {
            // Outer walls are indestructible
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Player")
        {
            // Set the appropriate endgame text
            GameOverManager GOManager = GameObject.Find("GameOverManager").GetComponent<GameOverManager>();
            var PV = col.gameObject.GetPhotonView();
            if (PV.IsMine)
            {
                GOManager.SetGameOverText("You Lose!");
            }
            else
            {
                GOManager.SetGameOverText("You Win!");
            }

            // Make the text visible
            GOManager.SetCanvasActive();

            // remove the projectile
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
