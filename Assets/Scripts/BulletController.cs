﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float m_speed = 30f;
    [SerializeField] float m_lifetime = 1f;
    Rigidbody m_rb = null;

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_rb.velocity = this.transform.forward * m_speed;
        Destroy(this.gameObject, m_lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyTag"))
        {
            EnemyController controller = null;
            if (other.TryGetComponent(out controller))
            {
                SphereCollider col = GetComponent<SphereCollider>();
                controller.Damage(col);
            }
            Destroy(this.gameObject);
        }
    }

   
}
