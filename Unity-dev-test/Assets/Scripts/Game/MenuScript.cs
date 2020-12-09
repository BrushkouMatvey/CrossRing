
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    
    private int score;
    [SerializeField] private Text bestScore;
    public void Start()
    {
        score = PlayerPrefs.GetInt("Best Score");
        bestScore.text = score.ToString();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
