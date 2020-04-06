using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    AudioSource audiosource;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }

    public void PlayWallBreak()
    {
        audiosource.Play();
    }
}
