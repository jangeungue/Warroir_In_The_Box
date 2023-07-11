using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigid;
    //몇 초후 파괴
    [SerializeField]
    float b1WasTimer = 0f;
    float b1WasShootTimer = 5f;
    void Update()
    {
        transform.Translate(Vector2.right * 50 * Time.deltaTime);

        if (b1WasTimer < b1WasShootTimer)
        {
            b1WasTimer += Time.deltaTime;
        }
        if (b1WasTimer > b1WasShootTimer)
        {
            Bullet1Destroy();
            b1WasTimer = 0f;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Monster1"))
        {
            Bullet1Destroy();
        }
    }
    void Bullet1Destroy()//다시 넣어
    {
        BulletManager.Instance.Bullet1Insert(gameObject);
    }
}
