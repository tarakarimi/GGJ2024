
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class FeatherController : MonoBehaviour
{
    [SerializeField] private Transform leftFoot;
    [SerializeField] private Transform rightFoot;
    [SerializeField] private float degree;
    [SerializeField] private ExpressionHandler _expressionHandler;
    [SerializeField] private PlayerMovement _playerMovement;
    private bool isTickling = false;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void RotateToFoot(float targetRotation)
    {
        transform.DORotate(new Vector3(0, 0, targetRotation), 0.5f).OnComplete(WiggleFeather);
    }

    public void RotateToLeftFoot()
    {
        RotateToFoot(degree);
    }

    public void RotateToRightFoot()
    {
        RotateToFoot(-degree);
    }
    
    private IEnumerator LaughCoolDown()
    {
        yield return new WaitForSeconds(0.5f);
        if (!isTickling)
        {
            _expressionHandler.SetExpression(ExpressionHandler.Expression.SLEEP);
        }
    }
    
    public void WiggleFeather()
    {
        isTickling = true;
        transform.DOPunchRotation(new Vector3(0, 0, 1), 1f).OnComplete(() =>
        {
            isTickling = false;
            StartCoroutine(LaughCoolDown());
        });
    }
}