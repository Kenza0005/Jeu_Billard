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
    // Appelé quand un Collider entre dans le trigger du trou
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie que c'est bien la balle et que ce GameObject est un trou
        if (other.CompareTag("Ball") && CompareTag("Hole"))
        {
            PlaySound();
            GameManager.Instance.AjouterScore(points);
            Destroy(other.gameObject);
        }
    }
    public void PlaySound()
    {
        if (!src.isPlaying)
            src.Play();
    }
}

