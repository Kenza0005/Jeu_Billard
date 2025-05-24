using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // Cette méthode sera appelée quand on appuie sur le bouton "Quitter"
    public void OnQuitPressed()
    {
        // Si on est en train de tester le jeu dans l’éditeur Unity
        #if UNITY_EDITOR
        // Alors on arrête simplement le mode Play (ça ferme pas Unity, juste le jeu en cours)
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // Sinon, si c’est une version du jeu compilée (sur PC, téléphone, etc.)
        // On quitte carrément l’application
        Application.Quit();
        #endif
    }
}
