using UnityEngine;

public class PortraitMode : MonoBehaviour {
    [SerializeField] private Vector2 aspectRatio;

    void Start() {
        // Set the desired aspect ratio
        float targetAspect = aspectRatio.x / aspectRatio.y;
        Screen.SetResolution((int)(Screen.height * targetAspect), Screen.height,
            FullScreenMode.MaximizedWindow);
    }
}