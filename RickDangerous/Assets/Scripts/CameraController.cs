using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform playerTransformCamera;
    void Update()
    {
        transform.position = new Vector3(playerTransformCamera.position.x,playerTransformCamera.position.y,transform.position.z);
    }
}
