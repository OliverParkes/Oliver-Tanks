using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AAA : MonoBehaviour
{
    public GameObject m_player;

    public Transform m_turret;
    private void Awake()
    {
        m_player = GameObject.FindGameObjectWithTag("PlanePlayer");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_turret != null)
        {
            m_turret.LookAt(m_player.transform);
        }
        

    }
}
