
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("PLAY");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
