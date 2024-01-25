using UnityEngine;
using UnityEngine.EventSystems;

public class LeftFoot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float leftMoveSpeed;
    [SerializeField] private PlayerMovement playerMovement;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        playerMovement.moveSpeed = leftMoveSpeed;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerMovement.moveSpeed = 0f; // Stop movement when button is released
    }
}