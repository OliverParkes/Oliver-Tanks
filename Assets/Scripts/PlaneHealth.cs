using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float m_tankHealth = 100;
    public GameObject m_explosionPrefab;

    private float m_currentHealth;
    private bool m_Dead;

    private ParticleSystem m_ExplosionParticles;

    private void Awake()
    {
        m_ExplosionParticles = Instantiate(m_explosionPrefab).GetComponent<ParticleSystem>();

        m_ExplosionParticles.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        m_currentHealth = m_tankHealth;
        m_Dead = false;

        SetHealthUI();
    }

    private void SetHealthUI()
    {

    }

    public void TakeDamage(float amount)
    {
        m_currentHealth -= amount;

        SetHealthUI();

        if (m_currentHealth <= 0)
        {
            OnDeath();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        m_currentHealth = 0f;
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
