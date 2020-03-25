using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombsight : MonoBehaviour
{
    public GameObject m_flightCam;
    public GameObject m_bombCam;

    private bool m_bombing;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("tab"))
        {
            m_bombing = true;
        }
        else
        {
            m_bombing = false;
        }
        if (m_bombing == true)
        {
            m_flightCam.SetActive(false);
            m_bombCam.SetActive(true);
        }
        else
        {
            m_bombCam.SetActive(false);
            m_flightCam.SetActive(true);
        }
    }
}
