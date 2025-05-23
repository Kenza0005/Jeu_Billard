using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Trou : MonoBehaviour
{
    [Tooltip("Points à attribuer quand une bille rentre")]
    public int points = 10;

    AudioSource src;
    void Awake()
    {
        src = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        if (!src.isPlaying)
            src.Play();
    }
}

