using UnityEngine;
using UnityEngine.EventSystems;

public class RightFoot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float rightMoveSpeed;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private FeatherController featherController;
    [SerializeField] private ExpressionHandler _expressionHandler;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (playerMovement != null)
        {
            playerMovement.horizontalSpeed = rightMoveSpeed;
            playerMovement.goUp = true;
            featherController.RotateToRightFoot();
            playerMovement.RotateTorque(1);
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