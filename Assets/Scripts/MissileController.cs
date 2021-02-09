using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileController : MonoBehaviour
{
    [SerializeField] int m_power = 10;
    [SerializeField] float m_speed = 20f;
    [SerializeField] float m_lifetime = 3f;
    Rigidbody m_rb = null;

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_rb.velocity = this.transform.forward * m_speed;
        Destroy(this.gameObject, m_lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("EnemyTag"))
        {
            EnemyController controller = null;
            if (other.TryGetComponent(out controller))
            {
                BoxCollider col = GetComponent<BoxCollider>();
                controller.Damage(col);
            }
            Destroy(this.gameObject);
        }
    }
}
