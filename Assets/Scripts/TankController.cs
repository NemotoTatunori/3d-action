using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] float m_movingSpeed = 5f;
    [SerializeField] GameObject m_bulletPrefab = null;
    [SerializeField] Transform m_muzzle = null;

    Rigidbody m_rb = null;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        Vector3 dir = Vector3.forward * v + Vector3.right * h;

        if (dir == Vector3.zero)
        {
            // 方向の入力がニュートラルの時は、y 軸方向の速度を保持するだけ
            m_rb.velocity = new Vector3(0f, m_rb.velocity.y, 0f);
        }
        else
        {
            Vector3 velo = dir.normalized * m_movingSpeed; // 入力した方向に移動する
            velo.y = m_rb.velocity.y;   // ジャンプした時の y 軸方向の速度を保持する
            m_rb.velocity = velo;   // 計算した速度ベクトルをセットする
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    void Attack()
    {
        Instantiate(m_bulletPrefab, m_muzzle.position, m_muzzle.rotation);
    }
}
