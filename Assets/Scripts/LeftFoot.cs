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
            playerMovement.horizontalSpeed = leftMoveSpeed;
            playerMovement.goUp = true;
            featherController.RotateToLeftFoot();
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (playerMovement != null)
        {
            playerMovement.horizontalSpeed = 0f;
            playerMovement.goUp = false;
        }
    }
}