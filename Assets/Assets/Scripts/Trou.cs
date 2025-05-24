using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// On oblige à avoir un composant AudioSource sur ce GameObject
[RequireComponent(typeof(AudioSource))]
public class Trou : MonoBehaviour
{
    // On peut choisir dans Unity combien de points vaut ce trou
    [Tooltip("Points à attribuer quand une bille rentre")]
    public int points = 10;

    AudioSource src; // C’est l’objet qui va jouer le son

    void Awake()
    {
        // Dès le début, on récupère le composant AudioSource attaché à ce trou
        src = GetComponent<AudioSource>();
    }

    // Quand un objet touche ce trou (zone de type "trigger")
    private void OnTriggerEnter(Collider other)
    {
        // On vérifie que l’objet qui entre est bien une balle,
        // et que ce GameObject est bien marqué comme un trou
        if (other.CompareTag("Ball") && CompareTag("Hole"))
        {
            // On joue le petit son
            PlaySound();

            // On ajoute les points au score du joueur
            GameManager.Instance.AjouterScore(points);

            // On supprime la balle (comme si elle tombait dans le trou)
            Destroy(other.gameObject);
        }
    }

    // Cette fonction joue le son s’il n’est pas déjà en train de jouer
    public void PlaySound()
    {
        if (!src.isPlaying)
            src.Play();
    }
}
