using UnityEngine;
using DG.Tweening;

public class FeatherController : MonoBehaviour
{
    [SerializeField] private Transform leftFoot;
    [SerializeField] private Transform rightFoot;
    [SerializeField] private float degree;

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
    
    public void WiggleFeather()
    {
        transform.DOPunchRotation(new Vector3(0, 0, 1), 0.5f);
    }
}