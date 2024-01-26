using System.Collections;
using DG.Tweening;
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
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private FoodSpawner foodSpawner;
    [SerializeField] private PathBounceController wallController;
    
    [SerializeField] private CanvasGroup uiCanvasGroup;
    [SerializeField] private float fadeInDuration = 0.5f;
    [SerializeField] private float beforeAcidRiseDelay = 1f;
    [SerializeField] private float loadAcidSceneDelay = 2f;

    [Header("Blood Lose Screen")]
    [SerializeField] private GameObject bloodLoseScreen;
    [SerializeField] private Animation bloodLoseAnimation;

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
        uiCanvasGroup.alpha = 0;
        playerMovement.enabled = false;
        wallController.enabled = false;
    }

    public void StartGame() {
        GameState = GameState.Playing;
        blades.SetActive(true);
        foodSpawner.isActive = true;
        playerMovement.enabled = true;
        wallController.enabled = true;
        uiCanvasGroup.DOFade(1, fadeInDuration);
        Invoke(nameof(StartAcidRising), beforeAcidRiseDelay);
    }

    private void StartAcidRising() {
        acidController.shouldGoUp = true;
    } 


    public void WinGame() {
        if (IsGameOver()) return;
        GameState = GameState.Won;
        SceneHandler.Instance.LoadWinScene();
    }

    public void LoseGameByAcid() {
        if (IsGameOver()) return;
        GameState = GameState.AcidLost;
        Invoke(nameof(LoadLoseAcidScene), loadAcidSceneDelay);
    }

    private void LoadLoseAcidScene() {
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