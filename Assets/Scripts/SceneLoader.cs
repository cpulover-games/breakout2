using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void loadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // last scene: game over
        if (currentSceneIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            if (FindObjectOfType<GameSession>())
            {
                FindObjectOfType<GameSession>().ResetGame();
            }// to remove the score
            SceneManager.LoadScene(1); // load the second scene (level 1)
        }
        else 
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }

    }

    public void quitGame()
    {
        Application.Quit();
    }
}
