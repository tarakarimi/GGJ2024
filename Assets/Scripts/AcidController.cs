using UnityEngine;

public class AcidController : MonoBehaviour {
    
    [SerializeField] private float normalSpeed = 1f;
    public bool shouldGoUp = false;

    void Update() {
        if (shouldGoUp)
        {
            transform.Translate(Vector3.up * (normalSpeed * Time.deltaTime));
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.TryGetComponent(out PlayerMovement player)) {
            GameManager.instance.LoseGameByAcid();
            // If the player collides with the acid, lose the game
        }
    }
}