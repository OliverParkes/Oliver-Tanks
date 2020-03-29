using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneHealth : MonoBehaviour
{
    
    public float m_tankHealth1 = 100;
    public GameObject m_explosionPrefab;

    private float m_currentHealth1;
    private bool m_Dead;

    private ParticleSystem m_ExplosionParticles;

    private void Awake()
    {
        m_ExplosionParticles = Instantiate(m_explosionPrefab).GetComponent<ParticleSystem>();

        m_ExplosionParticles.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        m_currentHealth1 = m_tankHealth1;
        m_Dead = false;

        SetHealthUI();
    }

    private void SetHealthUI()
    {

    }

    public void TakeDamage(float amount)
    {
        m_currentHealth1 -= amount;

        SetHealthUI();

        if (m_currentHealth1 <= 0)
        {
            OnDeath();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        m_tankHealth1 = 0f;
    }
    private void OnDeath()
    {
        m_Dead = true;

        m_ExplosionParticles.transform.position = transform.position;
        m_ExplosionParticles.gameObject.SetActive(true);

        m_ExplosionParticles.Play();

        gameObject.SetActive(false);

    }
}
