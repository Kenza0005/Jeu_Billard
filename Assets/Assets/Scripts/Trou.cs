using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// On oblige à ce qu’il y ait un composant AudioSource sur l’objet auquel ce script est attaché
[RequireComponent(typeof(AudioSource))]
public class Trou : MonoBehaviour
{
    // On peut choisir dans l’inspecteur d’Unity combien de points ce trou rapporte quand une bille tombe dedans
    [Tooltip("Points à attribuer quand une bille rentre")]
    public int points = 10;

    // On prépare une variable pour garder une référence à la source audio
    AudioSource src;

    void Awake()
    {
        // Dès que l’objet est activé (au début du jeu), on récupère la source audio
        src = GetComponent<AudioSource>();
    }

    // Cette fonction se lance automatiquement quand quelque chose entre dans la zone de détection (trigger) du trou
    private void OnTriggerEnter(Collider other)
    {
        // On vérifie que c’est bien une bille qui est entrée
        // et que cet objet est bien un trou (ça évite les erreurs)
        if (other.CompareTag("Ball") && CompareTag("Hole"))
        {
            // On joue le son quand la bille tombe
            PlaySound();

            // On ajoute les points au score du joueur
            GameManager.Instance.AjouterScore(points);

            // On détruit la bille (comme si elle disparaissait dans le trou)
            Destroy(other.gameObject);
        }
    }

    // Cette fonction sert à jouer un son si aucun son n’est déjà en cours
    public void PlaySound()
    {
        // Si le son n’est pas déjà en train de jouer, on le lance
        if (!src.isPlaying)
            src.Play();

        // Ensuite, on attend un petit moment, puis on arrête le son
        StartCoroutine(StopSoundAfterDelay(1f));
    }

    // Ici, on crée une petite attente (1 seconde) avant d’arrêter le son
    private IEnumerator StopSoundAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        src.Stop();
    }
}
