using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;
    public int score = 0;
    public Text scoreText;

    void Awake()
    {
        Instance = this;
    }

    public void AjouterScore(int points)
    {
        score += points;
        scoreText.text = "Score : " + score;
    }
}
