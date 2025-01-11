using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public KeyCode left;
    public KeyCode right;
    public float rotationDuration;
    public float easeStrength;

    private bool isRotating;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRotating)
        {
            if (Input.GetKeyDown(right))
            {
                StartCoroutine(RotateAroundWorldYAxis(-90));
            }

            if (Input.GetKeyDown(left))
            {
                StartCoroutine(RotateAroundWorldYAxis(90));
            }
        }
    }

    IEnumerator RotateAroundWorldYAxis(float angle)
    {
        isRotating = true;

        Vector3 pivotPoint = Vector3.zero; // World origin
        Vector3 axis = Vector3.up;         // World's vertical axis

        float elapsedTime = 0f;
        float startAngle = 0f;
        float currentAngle = 0f;

        while (elapsedTime < rotationDuration)
        {
            elapsedTime += Time.deltaTime;

            // Stronger ease-in and ease-out (using cubic easing)
            float t = Mathf.Pow(elapsedTime / rotationDuration, easeStrength); // Cubic easing for strong effect

            // Calculate the new angle based on easing
            float deltaAngle = Mathf.Lerp(startAngle, angle, t) - currentAngle;
            currentAngle += deltaAngle;

            // Rotate around the world's Y-axis at the origin
            transform.RotateAround(pivotPoint, axis, deltaAngle);

            yield return null; // Wait for the next frame
        }

        // Ensure the final rotation angle is exact
        transform.RotateAround(pivotPoint, axis, angle - currentAngle);

        isRotating = false;
    }
}
