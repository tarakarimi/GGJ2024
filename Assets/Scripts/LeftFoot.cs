using UnityEngine;
using UnityEngine.EventSystems;

public class LeftFoot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float leftMoveSpeed;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private FeatherController featherController;
    [SerializeField] private ExpressionHandler _expressionHandler;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (playerMovement != null)
        {
            playerMovement.horizontalSpeed = leftMoveSpeed;
            playerMovement.goUp = true;
            featherController.RotateToLeftFoot();
            _expressionHandler.SetExpression(ExpressionHandler.Expression.HAPPY);
            playerMovement.RotateTorque(-1);
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