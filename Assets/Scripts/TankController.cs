using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] float m_movingSpeed = 5f;//動く速さ
    [SerializeField] GameObject m_bulletPrefab = null;//弾のプレハブ
    [SerializeField] GameObject m_missilePrefab = null;//ミサイルのプレハブ
    [SerializeField] Transform m_muzzle = null;//弾の出所
    [SerializeField] int m_missileInterval = 60;//ミサイル再使用時間
    [SerializeField] int m_bulletMax = 20;

    bool missile = true;//ミサイル使用判定
    float timer;//弾の連射抑制
    float mtimer;//ミサイルの再使用時間
    int bulletNow;

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

        if (Input.GetButton("Fire1"))//弾発射
        {
            timer += Time.deltaTime;
            if (timer > 0.1)
            {
                Attack();
                timer = 0;
            }
            
        }
        if (Input.GetButtonDown("Fire2"))//ミサイル発射
        {           
            if (missile == true)
            {
                Missile();
                missile = false;
            }
            else
            {
               // Debug.Log("装填完了まで" + (m_missileInterval - (int)mtimer) + "秒");
            }
        }
        if (missile == false)//ミサイルの再使用時間
        {
            mtimer += Time.deltaTime;
            if (mtimer > m_missileInterval)
            {
                //Debug.Log("ミサイル装填完了");
                mtimer = 0;
                missile = true;                
            }
        }
    }

    void Attack()
    {
        Instantiate(m_bulletPrefab, m_muzzle.position, m_muzzle.rotation);
    }

    void Missile()
    {
        Instantiate(m_missilePrefab, m_muzzle.position, m_muzzle.rotation);
    }
}
