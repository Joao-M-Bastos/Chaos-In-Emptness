using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SholderRotation : MonoBehaviour
{
    private void Update()
    {
        if (!GameManagerScpt.IsPaused)
        {
            Vector3 mouse_pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouse_pos.z = 20f; //The distance between the camera and object
            Vector3 object_pos = this.transform.position;
            mouse_pos.x = mouse_pos.x - object_pos.x;
            mouse_pos.y = mouse_pos.y - object_pos.y;
            float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.Euler(new Vector3(-angle, 90, 0));
        }
    }
}
