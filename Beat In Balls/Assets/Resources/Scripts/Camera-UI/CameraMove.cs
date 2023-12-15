using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform playerTransform;
    void Update()
    {
        if (!GameManagerScpt.IsPaused && playerTransform != null)
        {
            this.transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, -20);
            this.transform.rotation = playerTransform.rotation;
        }
    }
}
