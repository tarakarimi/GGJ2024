using UnityEngine;

public class daricheController : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.transform.CompareTag("Player")) {
            GameManager.Instance.StartGame();
        }
    }
}