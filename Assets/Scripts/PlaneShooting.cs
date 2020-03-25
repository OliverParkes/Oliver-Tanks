using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneShooting : MonoBehaviour
{
    public Rigidbody m_shell;

    public Transform m_fireTransform;

    public float m_LaunchForce = 10;


    
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        if (Input.GetButtonUp("Fire1"))
        {
            Fire();
        }
    }

    private void Fire()
    {
        Rigidbody shellInstance = Instantiate(m_shell, m_fireTransform.position, m_fireTransform.rotation) as Rigidbody;
        shellInstance.velocity = m_LaunchForce * m_fireTransform.forward;
    }
}
