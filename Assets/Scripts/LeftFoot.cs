using UnityEngine;
using UnityEngine.EventSystems;

public class LeftFoot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float leftMoveSpeed;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private FeatherController featherController;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (playerMovement != null)
        {
            playerMovement.moveSpeed = leftMoveSpeed;
            featherController.RotateToLeftFoot();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (playerMovement != null)
        {
            playerMovement.moveSpeed = 0f;
        }
    }
}