
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseScript : MonoBehaviour
{
    private int score;
    [SerializeField] private Text scoreValue;
    public void Start()
    {
        score = PlayerPrefs.GetInt("Score");
        if(score > PlayerPrefs.GetInt("Best Score"))
            PlayerPrefs.SetInt("Best Score", score);
        scoreValue.text = score.ToString();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    

    public void GoToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
