using UnityEngine;

public class ForwardMovement : MonoBehaviour
{
    public float forwardSpeed = 5.0f;
    public Transform king;

    void Update()
    {
        if (king == null)
        {
            Debug.LogError("King reference not set on ForwardMovement script.");
            return;
        }

        Vector3 newPosition = transform.position;
        newPosition.x = king.position.x;
        transform.position = newPosition;

        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }
}