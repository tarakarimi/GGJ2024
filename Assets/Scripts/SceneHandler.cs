using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] private string gameSceneName;
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        int nextSceneIndex = currentSceneIndex++;
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void LoadGameScene() {
        SceneManager.LoadScene(gameSceneName);
    }
}