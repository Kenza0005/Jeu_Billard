using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // On crée une instance globale qu'on peut appeler depuis d'autres scripts
    public static GameManager Instance;
    [Header("Score UI")]
    // Le score du joueur
    public int score = 0;

    // Le texte qu’on voit à l’écran pour afficher le score
    public Text scoreText;
    [Header("Fin de partie UI")]
    public GameObject finPartiePanel;     // Assigne ton Panel “FinPartie” ici
    public Text finPartieScoreText;       // Assigne le Text enfant “FinPartieScoreText”
    private BallFatory ballFactory;
    void Awake()
    {
        // Dès que le jeu démarre, on enregistre cette instance pour pouvoir l'utiliser partout
        Instance = this;
    }
    void Start()
    {
        // On récupère l'instance de BallFactory et on masque le panel
        ballFactory = FindObjectOfType<BallFatory>();
        finPartiePanel.SetActive(false);
    }
    void Update()
    {
        CheckEndGame();
    }
    // Cette fonction ajoute des points au score actuel
    public void AjouterScore(int points)
    {
        // On augmente le score
        score += points;

        // On met à jour l'affichage du texte à l’écran
        scoreText.text = "Score : " + score;
    }
    private void CheckEndGame()
    {
        if (ballFactory != null
            && ballFactory.remaining == 0)   // condition remontée
        {
            // Affiche le panel et le score final
            finPartiePanel.SetActive(true);
            finPartieScoreText.text = $"SCORE: {score}";
        }
    }
}
