using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalSpeed = 0f;
    public float maxVerticalSpeed = 0.5f;
    public float verticalSpeed = -0.5f;
    
    [SerializeField] public Rigidbody2D rb;
    public bool goUp = false;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float rotSpeed;
    [SerializeField] private float fastSpeedMultiplier;
    [SerializeField] private float fastSpeedDuration;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddTorque(20f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Blade"))
        {
            Debug.Log("Lost by blood");
            GameManager.Instance.LoseGameByBlood();
        } else if (other.transform.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            BoostSpeed(fastSpeedMultiplier,fastSpeedDuration);
        }
    }

    public void BoostSpeed(float multiplier, float duration)
    {
        StartCoroutine(ApplySpeedBoost(multiplier, duration));
    }

    IEnumerator ApplySpeedBoost(float multiplier, float duration)
    {
        // Increase speed
        maxVerticalSpeed *= multiplier;

        // Wait for the specified duration
        yield return new WaitForSeconds(duration);

        // Revert speed back to normal
        maxVerticalSpeed /= multiplier;
    }

    public void RotateTorque(float value)
    {
        rb.AddTorque(value * rotSpeed);
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        verticalSpeed = goUp ? 5 * maxVerticalSpeed : 0;
        
        Vector2 moveDirection = new Vector2(horizontalSpeed, verticalSpeed);
        
        rb.AddForce(moveDirection);
    }
}