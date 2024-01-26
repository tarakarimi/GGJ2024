using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        int nextSceneIndex = currentSceneIndex++;
        SceneManager.LoadScene(nextSceneIndex);
    }
}