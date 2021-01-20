using UnityEngine;
using System.Collections;
using UnityEditor.UIElements;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform player;

    private Vector3 cameraOffset;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    private void Start()
    {
        cameraOffset = transform.position - player.position;
    }

    private void LateUpdate()
    {
        Vector3 newPos = player.position + cameraOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
    }
}