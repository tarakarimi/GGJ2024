using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalSpeed = 0f;
    public float maxVerticalSpeed = 0.5f;
    public float verticalSpeed = -0.5f;
    [SerializeField] private Rigidbody2D rb;
    public bool goUp = false;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Camera mainCamera; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();
        //UpdateCameraPosition();
    }

    void MovePlayer()
    {
        verticalSpeed = goUp ? 2 * maxVerticalSpeed : -maxVerticalSpeed;
        
        Vector2 moveDirection = new Vector2(horizontalSpeed, verticalSpeed);
        
        rb.AddForce(moveDirection);
    }
    
    private void UpdateCameraPosition()
    {
        if (mainCamera != null)
        {
            Vector3 cameraPosition = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
            mainCamera.transform.position = cameraPosition;
        }
    }
}