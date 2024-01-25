using UnityEngine;
using UnityEngine.EventSystems;

public class RightFoot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float rightMoveSpeed;
    [SerializeField] private PlayerMovement playerMovement;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        playerMovement.moveSpeed = rightMoveSpeed;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerMovement.moveSpeed = 0f; // Stop movement when button is released
    }
}