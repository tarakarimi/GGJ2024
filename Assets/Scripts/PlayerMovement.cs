using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    [SerializeField] private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        //float horizontalInput = moveSpeed;//Input.GetAxis("Horizontal");
        Vector2 moveDirection = new Vector2(moveSpeed, 0);
        
        rb.AddForce(moveDirection);
    }
}