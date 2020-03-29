using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAAShooting : MonoBehaviour
{
    public Rigidbody m_shell;
    public Transform m_FireTransform;
    
    public float m_launchForce = 200;
    public float m_ShootDelay = 0.5f;

    private bool m_canShoot = true;
    private float m_shootTimer;

    private void Awake()
    {
        m_canShoot = false;
        m_shootTimer = 0;
    }

    private void Update()
    {
        if (m_canShoot == true)
        {
            m_shootTimer -= Time.deltaTime;
            if (m_shootTimer <= 0)
            {
                m_shootTimer = m_ShootDelay;
                Fire();
            }
        }
    }

    private void Fire()
    {
        Rigidbody shellInstance = Instantiate(m_shell, m_FireTransform.position, m_FireTransform.rotation);
        shellInstance.velocity = m_launchForce * m_FireTransform.forward;
    }

    
    }
}
