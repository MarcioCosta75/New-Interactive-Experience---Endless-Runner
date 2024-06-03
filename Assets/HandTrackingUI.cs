using UnityEngine;

public class HandTrackingUI : MonoBehaviour
{
    public RectTransform leftHandIndicator;
    public RectTransform rightHandIndicator;
    public Transform leftHand3D;
    public Transform rightHand3D;

    private Camera mainCamera;
    private RectTransform canvasRectTransform;

    public Transform cubeTopLeft;
    public Transform cubeBottomRight;

    private float screenWidth = 1080f;
    private float screenHeight = 1920f;

    void Start()
    {
        mainCamera = Camera.main;
        canvasRectTransform = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
    }

    void Update()
    {
        UpdateHandPosition(leftHandIndicator, leftHand3D);
        UpdateHandPosition(rightHandIndicator, rightHand3D);
    }

    void UpdateHandPosition(RectTransform handIndicator, Transform hand3D)
    {
        // Convert the 3D position to a screen position
        Vector3 screenPosition = MapToScreenPosition(hand3D.position);

        // Convert the screen position to a canvas position
        Vector2 canvasPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, screenPosition, mainCamera, out canvasPosition);

        // Update the position of the hand indicator
        handIndicator.anchoredPosition = canvasPosition;
    }

    Vector3 MapToScreenPosition(Vector3 handPosition)
    {
        Vector3 topLeft = cubeTopLeft.position;
        Vector3 bottomRight = cubeBottomRight.position;

        float xNormalized = (handPosition.x - topLeft.x) / (bottomRight.x - topLeft.x);
        float yNormalized = (handPosition.y - bottomRight.y) / (topLeft.y - bottomRight.y);

        float screenX = xNormalized * screenWidth;
        float screenY = yNormalized * screenHeight;

        return new Vector3(screenX, screenY, 0);
    }
}