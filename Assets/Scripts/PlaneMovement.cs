﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour
{
    

    

    private float m_movementInput;
    private float m_pitchInput;
    private float m_rollInput;
    private float m_yawInput;

    
    public float m_movementSpeed = 30f;
    public float m_rollSpeed = 140f;
    public float m_pitchSpeed = 90f;
    public float m_yawSpeed = 50f;
    public float m_stallspeed = 0.01f;
    private Rigidbody m_rigidBody;

    private void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        m_movementInput = Input.GetAxis("Thrust");
        m_pitchInput = Input.GetAxis("Pitch");
        m_rollInput = Input.GetAxis("Roll");
        m_yawInput = Input.GetAxis("Yaw");

        
    }

    private void OnEnable()
    {
        m_rigidBody.isKinematic = false;
        m_rigidBody.useGravity = false;
    }

    private void FixedUpdate()
    {
        Move();
        Pitch();
        Roll();
        Yaw();
        
        
        
    }

    void Move()
    {
        Vector3 Movement = transform.forward * m_movementInput * m_movementSpeed * Time.deltaTime;
        m_rigidBody.MovePosition(m_rigidBody.position + Movement);
        m_rigidBody.AddForce(Vector3.forward * m_movementSpeed * Time.deltaTime);
    }

    void Pitch()
    {
        float Pitch = m_pitchSpeed * m_pitchInput * Time.deltaTime;
        Quaternion pitch = Quaternion.Euler(Pitch, 0f, 0f);
        m_rigidBody.MoveRotation(m_rigidBody.rotation * pitch);
    }

    void Roll()
    {
        float Roll = m_rollSpeed * m_rollInput * Time.deltaTime;
        Quaternion RollSpeed = Quaternion.Euler(0f, 0f, Roll);
        m_rigidBody.MoveRotation(m_rigidBody.rotation * RollSpeed);

    }
    void Yaw()
    {
        float Yaw = m_yawSpeed * m_yawInput * Time.deltaTime;
        Quaternion YawSpeed = Quaternion.Euler(0f, Yaw, 0f);
        m_rigidBody.MoveRotation(m_rigidBody.rotation * YawSpeed);
    }
    

    
}