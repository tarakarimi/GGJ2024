using UnityEngine;

public class WinAreaController : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent(out PlayerMovement playerMovement)) {
            GameManager.Instance.WinGame();
        }
    }
}