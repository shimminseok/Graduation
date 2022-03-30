using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float _rotSpeed;
    void Start()
    {

    }

    void Update()
    {
        Invoke("Move", 3f);
    }
    void Move()
    {
        transform.rotation = transform.rotation * Quaternion.Euler(0, -_rotSpeed * Time.deltaTime, 0);
    }
}
