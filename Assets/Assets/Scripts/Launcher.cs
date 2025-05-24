using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Ce script contrôle le lancer d'une balle. Il doit être attaché à un objet qui a un Rigidbody.
[RequireComponent(typeof(Rigidbody))]
public class Launcher : MonoBehaviour
{
    const float force = 10f; // Force qu’on utilise pour lancer la balle
    const int MAX_LAUNCHES = 2; // Nombre maximum de lancers autorisés
    int launchCount = 0; // On commence avec 0 lancer
    Rigidbody body; // On va garder ici le Rigidbody de la balle
    public Text triesText; // Texte pour afficher le nombre d’essais restants
    int remainingTries; // Essais restants

    private void Awake()
    {
        // Ici, on récupère le Rigidbody attaché à la balle
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Quand on clique avec le bouton gauche de la souris, et si on a encore des essais
        if (Input.GetKeyDown(KeyCode.Mouse0) && launchCount <= MAX_LAUNCHES)
        {
            // 1) On crée un rayon qui part de la caméra vers l’endroit où on a cliqué
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // 2) On définit un plan horizontal à la hauteur de la balle
            Plane plane = new Plane(Vector3.up, transform.position);

            // 3) Si le rayon croise le plan...
            if (plane.Raycast(ray, out float enter))
            {
                // ...on récupère le point d’impact entre le rayon et le plan
                Vector3 hitPoint = ray.GetPoint(enter);

                // ...on calcule la direction entre la balle et ce point
                Vector3 direction = (hitPoint - transform.position).normalized;

                // 4) On "active" le Rigidbody et on applique une force pour lancer la balle
                body.isKinematic = false;
                body.AddForce(direction * force, ForceMode.Impulse);

                // 5) On augmente le nombre de lancers utilisés
                launchCount++;
                remainingTries = MAX_LAUNCHES - launchCount;

                // 6) On met à jour le texte qui indique combien d’essais il nous reste
                BallFatory factory = FindObjectOfType<BallFatory>();
                if (factory != null && factory.triesText != null && remainingTries >= 0)
                {
                    factory.triesText.text = $"Essais restants : {remainingTries}";
                }

                // 7) Si on a dépassé le nombre d’essais, on détruit la balle
                if (launchCount > MAX_LAUNCHES)
                {
                    Debug.LogWarning($"Vous avez utilisé vos {MAX_LAUNCHES} essais.");
                    Destroy(gameObject);
                }
            }

            // Si on appuie sur la touche S, on détruit la balle (peut servir pour annuler un tir)
            if (Input.GetKeyDown(KeyCode.S))
            {
                Destroy(gameObject);
            }
        }
    }
}
