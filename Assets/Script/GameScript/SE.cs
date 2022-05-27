using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{
    public AudioClip se;
    public AudioClip se2;
    public AudioClip se3;
    AudioSource audioSource;

    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    public void Pikon()
    {
        //音(se)を鳴らす
        audioSource.PlayOneShot(se);
    }

    public void Kiran()
    {
        //音(se)を鳴らす
        audioSource.PlayOneShot(se2);
    }

    public void Bomb()
    {
        audioSource.PlayOneShot(se3);
    }
}
