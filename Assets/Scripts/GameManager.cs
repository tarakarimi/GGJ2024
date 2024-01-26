using UnityEngine;

public enum GameState {
    PreStart,
    Playing,
    Won,
    AcidLost,
    BloodLost
}

public class GameManager : MonoBehaviour {
    public static GameManager instance;
    public GameState GameState { get; private set; }
    [SerializeField] private GameObject bloodLoseScreen;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    void Start() {
        GameState = GameState.PreStart;
    }

    public void WinGame() {
        if (GameState == GameState.Playing) return;
        GameState = GameState.Won;
    }

    public void LoseGameByAcid() {
        if (GameState == GameState.Playing) return;
        GameState = GameState.AcidLost;
    }

    public void LoseGameByBlood() {
        if (GameState == GameState.Playing) return;
        GameState = GameState.BloodLost;
        bloodLoseScreen.SetActive(true);
    }
}