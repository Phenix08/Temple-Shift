using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        float time = Mathf.PingPong(Time.time * speed, 1);
        float easedTime = Mathf.SmoothStep(0, 1, time);
        transform.position = Vector3.Lerp(pointA.position, pointB.position, easedTime);
    }
}
