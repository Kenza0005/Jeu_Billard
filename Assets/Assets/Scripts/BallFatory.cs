using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BallFatory : MonoBehaviour
{
    public GameObject ballPrefab; // Le prefab de la balle à instancier
    // cree une liste des game objett pour gardes l'historique des balles
    public List<GameObject> ballList = new List<GameObject>();
    public Transform pointLancement;
    // Nombre max de balles autorisées
    public int maxBalls = 10;
    public Text ballText;
    int remaining= 10;
    void Start()
    {
        ballText.text = $"Balles restantes : 10 s";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ballList.Count < maxBalls)
            {
                // Instancie mon prefab 
                GameObject newball = Instantiate(ballPrefab, pointLancement.position, Quaternion.identity);
                Rigidbody rb = newball.GetComponent<Rigidbody>();
                // Optionnel : désactiver la gravité pour la nouvelle balle
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                //rb.isKinematic = true; // désactive la physique jusqu'à nouvel ordre
                ballList.Add(newball);
                // Mets à jour le texte UI
                remaining--;
                ballText.text = $"Balles restantes : {remaining}";
            }
            else
            {
                Debug.LogWarning($"Limite atteinte : max {maxBalls} balles.");
            }


        }
    }
    
}
