using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Ce script permet de lancer une balle en cliquant.
[RequireComponent(typeof(Rigidbody))]
public class Launcher : MonoBehaviour
{
    // const float force = 12f; // C’est la force qu’on utilise pour propulser la balle
    float force;
    const int MAX_LAUNCHES = 2; // On peut lancer la balle au maximum 2 fois
    int launchCount = 0; // On commence avec zéro lancer
    Rigidbody body; // Ici, on va garder le Rigidbody de la balle
    public Text triesText; // Texte pour afficher combien d’essais il nous reste
    int remainingTries; // Nombre d’essais restants

    private void Awake()
    {
        // Au début, on récupère le Rigidbody pour pouvoir ensuite bouger la balle avec la physique
        body = GetComponent<Rigidbody>();
        force = Random.Range(10f, 14.5f); // On choisit une force aléatoire entre 10 et 15 pour le lancer
    }

    void Update()
    {
        // Si on clique avec le bouton gauche de la souris et qu’on n’a pas encore dépassé les essais
        if (Input.GetKeyDown(KeyCode.Mouse0) && launchCount <= MAX_LAUNCHES)
        {
            // 1) On crée un rayon qui part de la caméra vers là où on a cliqué à l’écran
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // 2) On définit un plan horizontal à la hauteur de la balle (donc parallèle au sol)
            Plane plane = new Plane(Vector3.up, transform.position);

            // 3) Si le rayon touche ce plan…
            if (plane.Raycast(ray, out float enter))
            {
                // …on récupère le point d’impact du rayon sur ce plan
                Vector3 hitPoint = ray.GetPoint(enter);

                // …on calcule la direction entre la balle et ce point (direction du tir)
                Vector3 direction = (hitPoint - transform.position).normalized;

                // 4) On active la physique sur la balle (si elle ne l’était pas) et on applique une impulsion
                body.isKinematic = false;
                body.AddForce(direction * force, ForceMode.Impulse);

                // 5) On augmente le compteur de tirs
                launchCount++;
                remainingTries = MAX_LAUNCHES - launchCount;

                // 6) On met à jour le texte à l’écran pour afficher combien d’essais il nous reste
                BallFatory factory = FindObjectOfType<BallFatory>();
                if (factory != null && factory.triesText != null && remainingTries >= 0)
                {
                    factory.triesText.text = $"Essais restants : {remainingTries}";
                }

                // 7) Si on a dépassé le nombre autorisé, on détruit la balle
                if (launchCount > MAX_LAUNCHES)
                {
                    Debug.LogWarning($"Vous avez utilisé vos {MAX_LAUNCHES} essais.");
                    Destroy(gameObject);
                }
            }

            // Bonus : si on appuie sur la touche S, on détruit la balle (pratique si on veut annuler un tir)
            if (Input.GetKeyDown(KeyCode.S))
            {
                Destroy(gameObject);
            }
        }
    }
}
