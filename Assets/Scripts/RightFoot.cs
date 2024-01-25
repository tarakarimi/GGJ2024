using UnityEngine;
using UnityEngine.EventSystems;

public class RightFoot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float rightMoveSpeed;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private FeatherController featherController;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (playerMovement != null)
        {
            playerMovement.horizontalSpeed = rightMoveSpeed;
            playerMovement.goUp = true;
            featherController.RotateToRightFoot();
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