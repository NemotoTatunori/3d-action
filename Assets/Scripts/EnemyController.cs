using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int m_hp = 10;
    [SerializeField] float m_moveSpeed = 5;
    [SerializeField] GameObject hp = null;

    int maxHp;

    public Slider slider;

    Rigidbody m_rd = null;

    void Start()
    {
        m_rd = GetComponent<Rigidbody>();
        slider.value = 1;
        maxHp = m_hp;
    }


    private void FixedUpdate()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        m_hp -= 1;

        if (maxHp != m_hp)
        {
            hp.gameObject.SetActive(true);
        }

        slider.value = (float)m_hp / (float)maxHp;

        if (m_hp == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
