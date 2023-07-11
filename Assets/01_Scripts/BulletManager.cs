using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : Singleton<BulletManager>
{
    public GameObject Bullet1Prefab = null;

    public Queue<GameObject> Bullet_queue = new Queue<GameObject>();


    void Start()
    {
        //Bullet1
        for (int i = 0; i < 30; i++)
        {
            GameObject b_object = Instantiate(Bullet1Prefab, Vector3.zero, Quaternion.identity);
            Bullet_queue.Enqueue(b_object);
            b_object.transform.SetParent(transform); // ?
            b_object.SetActive(false);

        }
    }

    public GameObject Bullet1Get()//³»º¸³¿
    {
        GameObject b_object = Bullet_queue.Dequeue();
        b_object.SetActive(true);
        return b_object;
    }


    public void Bullet1Insert(GameObject b_object)//¹Ý³³
    {
        Bullet_queue.Enqueue(b_object);
        b_object.SetActive(false);
    }
}
