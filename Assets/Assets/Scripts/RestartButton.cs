using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    // Cette fonction est appelée quand on clique sur le bouton "Recommencer"
    public void OnRestartPressed()
    {
        // On recharge la scène actuelle (ça remet tout à zéro)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
