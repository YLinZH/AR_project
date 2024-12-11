using UnityEngine;

public class CarControl : MonoBehaviour
{
    private float autoRotateSpeed = 50f;
    private float manualRotateSpeed = 0.5f;
    private bool isAutoRotating = true;
    private Vector2 lastTouchPosition;
    private bool isDragging = false;

    void Update()
    {
        // Auto Rotate
        if (isAutoRotating)
        {

            transform.Rotate(Vector3.up, autoRotateSpeed * Time.deltaTime, Space.World);
        }

        // Si no se esta rotando automaticamente, entonces el usuario puede rotar el modelo manualmente
        else
        {
            HandleUserInput();
        }
    }

    // Change the Rotation State (Rotation Mode or Stop Rotation)
    public void ChangeRotationState()
    {
        isAutoRotating = !isAutoRotating;
    }

    // El usuario puede rotar el modelo manualmente
    private void HandleUserInput()
    {

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isDragging = true;
                lastTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                Vector2 deltaPosition = touch.position - lastTouchPosition;

                RotateModel(deltaPosition);

                lastTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isDragging = false;
            }
        }
    }
    private void RotateModel(Vector2 deltaPosition)
    {
        float rotationX = deltaPosition.y * manualRotateSpeed;
        float rotationY = -deltaPosition.x * manualRotateSpeed;

        transform.Rotate(Vector3.up, rotationY, Space.World);
        transform.Rotate(Vector3.right, rotationX, Space.World);
    }
}


