using UnityEngine;

public enum GameState {
    PreStart,
    Playing,
    Won,
    AcidLost,
    BloodLost
}

public class GameManager : MonoBehaviour {
    public static GameManager Instance;
    public GameState GameState { get; private set; }
    
    [SerializeField] private AcidController acidController;
    [SerializeField] private GameObject blades;
    
    [Header("Blood Lose Screen")]
    [SerializeField] private GameObject bloodLoseScreen;
    [SerializeField] private Animation bloodLoseAnimation;
    [SerializeField] private FoodSpawner foodSpawner;

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    void Start() {
        GameState = GameState.PreStart;
        foodSpawner.gameObject.SetActive(false);
    }

    public void StartGame() {
        GameState = GameState.Playing;
        acidController.shouldGoUp = true;
        blades.SetActive(true);
        foodSpawner.isActive = true;
    }


    public void WinGame() {
        if (IsGameOver()) return;
        GameState = GameState.Won;
    }

    public void LoseGameByAcid() {
        if (IsGameOver()) return;
        GameState = GameState.AcidLost;
        SceneHandler.Instance.LoadAcidLoseScene();
    }

    public void LoseGameByBlood() {
        if (IsGameOver()) return;
        GameState = GameState.BloodLost;
        bloodLoseScreen.SetActive(true);
        bloodLoseAnimation.Play();
    }

    private bool IsGameOver() {
        return GameState != GameState.Playing && GameState != GameState.PreStart;
    }
}