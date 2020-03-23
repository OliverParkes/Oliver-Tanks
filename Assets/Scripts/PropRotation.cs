using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropRotation : MonoBehaviour
{
    public GameObject m_prop;

    public float m_RPM;
   

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, m_RPM * Time.deltaTime);
    }
}
