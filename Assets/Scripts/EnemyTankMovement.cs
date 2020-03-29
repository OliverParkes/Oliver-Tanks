using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTankMovement : MonoBehaviour
{
    public float m_closeDistance = 8f;
    public Transform m_Turret;

    private GameObject m_Player;
    private NavMeshAgent m_NavAgent;
    private Rigidbody m_Rigidbody;

    private bool m_Follow;

    public List<Transform> _WayPoints = new List<Transform>();
    private int currentWayPoint;

    private void Awake()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player");
        m_NavAgent = GetComponent< NavMeshAgent > ();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Follow = false;
    }

    private void OnEnable()
    {
        m_Rigidbody.isKinematic = false;
    }
    private void OnDisable()
    {
        m_Rigidbody.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            m_Follow = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            m_Follow = false;
        }   
    }

    private void Update()
    {
        if (m_Follow == false)
        {
            if (_WayPoints.Count <= 0)
            {
                return;
            }


            if (currentWayPoint < _WayPoints.Count)
            {
                if (Vector3.Distance(transform.position, _WayPoints[currentWayPoint].position) > 5)
                {
                    m_NavAgent.SetDestination(_WayPoints[currentWayPoint].position);
                }
                else
                {
                    currentWayPoint++;
                }
            }
            else
            {
                currentWayPoint = 0;
            }

        }

        else
        {
            float distance = (m_Player.transform.position - transform.position).magnitude;
            if (distance > m_closeDistance)
            {
                m_NavAgent.SetDestination(m_Player.transform.position);
                m_NavAgent.isStopped = false;
            }

            if (m_Turret != null)
            {
                m_Turret.LookAt(m_Player.transform);

                transform.eulerAngles = transform.eulerAngles.y * Vector3.up;
            }
        }
    }


}

