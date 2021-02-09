using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int m_hp = 10;
    [SerializeField] float m_moveSpeed = 5;
    [SerializeField] GameObject hp = null;

    int a = 0;

    int maxHp;

    public Slider slider;

    Rigidbody m_rd = null;

    void Start()
    {
        m_rd = GetComponent<Rigidbody>();
        slider.value = 1;
        maxHp = m_hp;
        Rigidbody rigidbody = this.gameObject.transform.Find("Cylinder").gameObject.GetComponent<Rigidbody>();
        Debug.Log(rigidbody.gameObject);
    }

    
    private void FixedUpdate()
    {
        
    }
    

    //子オブジェクトが親オブジェクトのRigidbodyに依存するのでミサイルが子オブジェクトに当たった時にもこの関数が呼び出されているのでは？（藤島）
    /*
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(this.gameObject);
        if (other.gameObject.CompareTag("BulletTag"))
        {
            Debug.Log("玉");
            m_hp -= 1;
        }
        if (other.gameObject.CompareTag("MissileTag"))
        {
            //Debug.Log("ミサイル");
            //Debug.Log(other.gameObject.name);
            m_hp -= 10;
            a += 1;
            Debug.Log(a);
        }
        

        if (maxHp != m_hp)
        {
            hp.gameObject.SetActive(true);
        }

        slider.value = (float)m_hp / (float)maxHp;

        if (m_hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    */

    //MissileController側から上のOntrigerと同じ処理を呼び出す
    //理由としてはMissileオブジェクトが一回の当たり判定でDestroyされるので結果的に呼び出し回数が絶対に1回となるから
    public void Damage(Collider other)
    {

        if (other.gameObject.CompareTag("BulletTag"))
        {
            Debug.Log("玉");
            m_hp -= 1;
        }
        if (other.gameObject.CompareTag("MissileTag"))
        {
            Debug.Log("ミサイル");
            //Debug.Log(other.gameObject.name);
            m_hp -= 10;
            a += 1;
            Debug.Log(a);
        }


        if (maxHp != m_hp)
        {
            hp.gameObject.SetActive(true);
        }

        slider.value = (float)m_hp / (float)maxHp;

        if (m_hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
