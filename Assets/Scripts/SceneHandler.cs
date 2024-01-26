using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour {
    public static SceneHandler Instance;

    [SerializeField] private string gameSceneName;
    [SerializeField] private string acidLoseSceneName;
    
    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void LoadNextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int nextSceneIndex = currentSceneIndex++;
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void LoadGameScene() {
        SceneManager.LoadScene(gameSceneName);
    }

    public void LoadAcidLoseScene() {
        SceneManager.LoadScene(acidLoseSceneName);
    }
}