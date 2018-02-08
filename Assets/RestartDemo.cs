using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartDemo : MonoBehaviour {
    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
