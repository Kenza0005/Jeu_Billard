using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Launcher : MonoBehaviour
{
    // public GameObject ballPrefab;
    // public Transform pointLancement;

    const float force = 7f;
    // public List<GameObject> ballList= new List<GameObject>(); 
    Rigidbody body;
    private void Awake()
    {
        // Recupere le rigidbody
        body = GetComponent<Rigidbody>();
        // body.useGravity = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            // if (ballList.Count > 0)
            // {
            //     GameObject lastBall = ballList[ballList.Count - 1];
            //     Rigidbody rb = lastBall.GetComponent<Rigidbody>();
            //     rb.isKinematic = false; // réactive la physique

            //     rb.AddForce(0,force,0);
            // }
            Vector3 vect = new Vector3(force, 0, 0);
            body.isKinematic = false;
            body.AddForce(vect, ForceMode.Impulse);
            // body.AddForce(force, 0, 0);
        }
    }
}
