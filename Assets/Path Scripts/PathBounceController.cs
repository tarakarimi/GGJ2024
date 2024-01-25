using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PathBounceController : MonoBehaviour {
    [SerializeField] private Transform player;
    [SerializeField] private SpriteShapeController rightWallShape;
    [SerializeField] private SpriteShapeController leftWallShape;
    [SerializeField] private float bounceHeight = 1f;
    [SerializeField] private float bounceFrequency = 1f;
    private IEnumerator bounceCoroutine;

    private int lastLeftWallPointIdx;
    private int lastRightWallPointIdx;

    private Dictionary<int, Vector3> leftWallInitialPositions = new ();
    private Dictionary<int, Vector3> rightWallInitialPositions = new ();

    private void Start() {
        for (int i = 0; i < leftWallShape.spline.GetPointCount(); i++) {
            leftWallInitialPositions.Add(i, leftWallShape.spline.GetPosition(i));
        }

        for (int i = 0; i < rightWallShape.spline.GetPointCount(); i++) {
            rightWallInitialPositions.Add(i, rightWallShape.spline.GetPosition(i));
        }

        bounceCoroutine = Bounce();
        StartCoroutine(bounceCoroutine);
    }

    private IEnumerator Bounce() {
        float t = 0f;
        while (true) {
            t += Time.deltaTime;
            float xOffset = Mathf.Sin(t * Mathf.PI * bounceFrequency) * bounceHeight;
            var curLeftWallPointIdx = GetClosestSplinePointToPlayer(leftWallShape);
            var curRightWallPointIdx = GetClosestSplinePointToPlayer(rightWallShape);

            if (curLeftWallPointIdx != lastLeftWallPointIdx) {
                RevertLeftPointToInitPos(lastLeftWallPointIdx);
                lastLeftWallPointIdx = curLeftWallPointIdx;
            }

            if (curRightWallPointIdx != lastRightWallPointIdx) {
                RevertRightPointToInitPos(lastRightWallPointIdx);
                lastRightWallPointIdx = curRightWallPointIdx;
            }

            var leftWallPointPos = leftWallShape.spline.GetPosition(curLeftWallPointIdx);
            var rightWallPointPos = rightWallShape.spline.GetPosition(curRightWallPointIdx);

            leftWallShape.spline.SetPosition(curLeftWallPointIdx,
                new Vector3(leftWallPointPos.x + xOffset, leftWallPointPos.y, leftWallPointPos.z));
            rightWallShape.spline.SetPosition(curRightWallPointIdx,
                new Vector3(rightWallPointPos.x - xOffset, rightWallPointPos.y, rightWallPointPos.z));
            yield return null;
        }
    }

    private void RevertLeftPointToInitPos(int leftPointIdx) {
        leftWallShape.spline.SetPosition(leftPointIdx, leftWallInitialPositions[leftPointIdx]);
    }

    private void RevertRightPointToInitPos(int rightPointIdx) {
        rightWallShape.spline.SetPosition(rightPointIdx, rightWallInitialPositions[rightPointIdx]);
    }

    private int GetClosestSplinePointToPlayer(SpriteShapeController shapeController) {
        int closestPointIndex = 0;
        float closestDistance = Mathf.Infinity;
        for (int i = 0; i < shapeController.spline.GetPointCount(); i++) {
            float distance = Mathf.Abs(shapeController.spline.GetPosition(i).y - player.position.y);
            if (distance < closestDistance) {
                closestDistance = distance;
                closestPointIndex = i;
            }
        }

        return closestPointIndex;
    }
}