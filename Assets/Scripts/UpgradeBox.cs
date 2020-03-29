using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeBox : MonoBehaviour
{
    public static bool m_canFly = false;
    private bool m_flying;
    

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 90f * Time.deltaTime, 0f);

        m_flying = TankHealth.m_flying;

        if (m_flying == true)
        {
            m_canFly = false;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        m_canFly = true;
        Destroy(gameObject);

    }
}
