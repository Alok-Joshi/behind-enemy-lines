using UnityEngine;

public class Crosshair : MonoBehaviour
{
    void Update()
    {
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;

        // Convert mouse position to world coordinates
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldPosition.z = 0; // Ensure the crosshair stays at the same Z position

        // Set the crosshair's position to the mouse position
        transform.position = worldPosition;
    }
}
