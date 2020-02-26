using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float m_DampTime = 0.2f;

    public Transform m_Target;

    private Vector3 m_moveVelocity;
    private Vector3 m_desiredPosition;

    private void Awake()
    {
        m_Target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        m_desiredPosition = m_Target.position;
        transform.position = Vector3.SmoothDamp(transform.position, m_desiredPosition, ref m_moveVelocity, m_DampTime);
    }
}
