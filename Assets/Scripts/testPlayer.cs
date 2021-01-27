using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPlayer : MonoBehaviour
{
    int life = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.FindGameObjectWithTag("");
        SingletonPattern01 singleton = obj.GetComponent<SingletonPattern01>();

        gameObject.GetComponent<SingletonPattern01>();

        GetComponent<SingletonPattern01>();

        //= FindObjectOfType<SingletonPattern01>();
        life = singleton.Hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        SingletonPattern01 singleton = FindObjectOfType<SingletonPattern01>();
        singleton.Hp = life;
    }
}
