using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Launcher : MonoBehaviour
{

    //const float force = 8f;
    float force;
    const int MAX_LAUNCHES = 2;
    int launchCount = 0;    // on commence à 0 essais
    Rigidbody body;
    private void Awake()
    {
        // Recupere le rigidbody
        body = GetComponent<Rigidbody>();
        force = Random.Range(5,9);
        // body.useGravity = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && launchCount <= MAX_LAUNCHES)
        {
            Vector3 vect = new Vector3(force, 0, 0);
            body.isKinematic = false;
            body.AddForce(vect, ForceMode.Impulse);
            launchCount++;
            if (launchCount > MAX_LAUNCHES)
            {
                // On a utilisé les 2 essais, on détruit la balle
                Debug.LogWarning($"Vous avez utilisé vos {MAX_LAUNCHES} essais.");
                Destroy(gameObject);
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        { 
            Destroy(gameObject);

        }
    }
}
