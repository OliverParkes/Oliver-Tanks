using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public float m_maxLifeTime = 2f;
    public float m_maxDamage = 34f;
    public float ExplosionRadius = 5f;
    public float ExplosionForce = 100f;

    public ParticleSystem m_ExplosionParticles;

    private float CalculateDamage(Vector3 targetPosition)
    {
        Vector3 explosionToTarget = targetPosition - transform.position;

        float explosionDistance = explosionToTarget.magnitude;

        float relativeDistance = (ExplosionRadius - explosionDistance) / ExplosionRadius;

        float damage = relativeDistance * m_maxDamage;

        damage = Mathf.Max(0f, damage);

        return damage;
    }

    void Start()
    {
        Destroy(gameObject, m_maxLifeTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        Rigidbody targetRididbody = other.gameObject.GetComponent<Rigidbody>();

        if (targetRididbody != null)
        {
            targetRididbody.AddExplosionForce(ExplosionForce, transform.position, ExplosionRadius);

            TankHealth TargetHealth = targetRididbody.GetComponent<TankHealth>();

            if (TargetHealth != null)
            {
                float damage = CalculateDamage(targetRididbody.position);

                TargetHealth.TakeDamage(damage);
            }
        }

        
        m_ExplosionParticles.transform.parent = null;

        m_ExplosionParticles.Play();
        Destroy(m_ExplosionParticles.gameObject, m_ExplosionParticles.main.duration);

        Destroy(gameObject);
    }

    
    
}
