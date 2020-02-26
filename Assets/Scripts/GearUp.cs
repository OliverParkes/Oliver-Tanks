using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearUp : MonoBehaviour
{
    public GameObject m_rightWheel;
    public GameObject m_leftWheel;
    public GameObject m_tailWheel;

    public float m_gearUp;
    

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_gearUp = Input.GetAxis("Gear");
    }

    private void FixedUpdate()
    {
        Gear();
    }

    private void Gear()
    {
        if (m_gearUp > 0)
        {
            m_leftWheel.SetActive(false);
            m_rightWheel.SetActive(false);
            m_tailWheel.SetActive(false);
        }
    }
}
