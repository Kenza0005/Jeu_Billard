using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFatory : MonoBehaviour
{
    public GameObject ballPrefab; // Le prefab de la balle à instancier
    // cree une liste des game objett pour gardes l'historique des balles
    public List<GameObject> ballList = new List<GameObject>();
    public Transform pointLancement;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Instancie mon prefab 
            GameObject newball = Instantiate(ballPrefab, pointLancement.position, Quaternion.identity);
            Rigidbody rb = newball.GetComponent<Rigidbody>();
            // Optionnel : désactiver la gravité pour la nouvelle balle
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true; // désactive la physique jusqu'à nouvel ordre
            ballList.Add(newball);

        }
    }
}
