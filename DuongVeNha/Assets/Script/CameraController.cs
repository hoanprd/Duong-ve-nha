using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 min_pos;
    public Vector2 max_pos;

    void LateUpdate()
    {
        //transform.position = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);
        if (transform.position != target.position)
        {
            Vector3 target_pos = new Vector3(target.position.x, target.position.y, transform.position.z);

            target_pos.x = Mathf.Clamp(target.position.x, min_pos.x, max_pos.x);
            target_pos.y = Mathf.Clamp(target.position.y, min_pos.y, max_pos.y);

            transform.position = Vector3.Lerp(transform.position, target_pos, smoothing);
        }
    }
}
