using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallFatory : MonoBehaviour
{
    // On met ici le prefab (modèle) de la balle qu’on va faire apparaître
    public GameObject ballPrefab;

    // On garde une liste de toutes les balles qu’on a déjà créées
    public List<GameObject> ballList = new List<GameObject>();

    // C’est le point où les balles vont apparaître quand on appuie sur Espace
    public Transform pointLancement;

    // Combien de balles on peut créer au maximum
    public int maxBalls = 10;

    // Textes à afficher à l’écran
    public Text ballText;
    public Text triesText;
    [SerializeField]
    public int remaining = 10; // Combien de balles il nous reste
    int MAX_LAUNCHES = 2; // Nombre d’essais max par balle
    int remainingTries; // Essais restants pour une balle

    void Start()
    {
        // Au début du jeu, on affiche qu’il reste 10 balles
        ballText.text = $"Balles restantes : 10";

        // On remet les essais à 2 à chaque nouvelle balle
        remainingTries = MAX_LAUNCHES;
    }

    void Update()
    {
        // Quand on appuie sur la touche Espace...
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // ...et si on n’a pas encore atteint la limite de balles
            if (ballList.Count < maxBalls)
            {
                // 1) On crée une nouvelle balle au bon endroit, sans rotation
                GameObject newball = Instantiate(ballPrefab, pointLancement.position, Quaternion.identity);

                // 2) On récupère le Rigidbody de cette balle
                Rigidbody rb = newball.GetComponent<Rigidbody>();

                // 3) On remet sa vitesse et sa rotation à zéro pour bien la relancer
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                // 4) On ajoute cette nouvelle balle à notre liste
                ballList.Add(newball);

                // 5) On retire 1 balle au compteur, et on met à jour le texte à l’écran
                remaining--;
                ballText.text = $"Balles restantes : {remaining}";
            }
            else
            {
                // Si on a déjà utilisé toutes les balles, on affiche un message
                Debug.LogWarning($"Limite atteinte : max {maxBalls} balles.");
            }
        }
    }
}
