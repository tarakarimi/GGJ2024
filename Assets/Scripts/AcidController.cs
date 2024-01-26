using UnityEngine;

public class AcidController : MonoBehaviour {
    [SerializeField] private float normalSpeed = 1f;

    void Update() {
        transform.Translate(Vector3.up * (normalSpeed * Time.deltaTime));
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.TryGetComponent(out PlayerMovement player)) {
            // If the player collides with the acid, lose the game
        }
    }
}