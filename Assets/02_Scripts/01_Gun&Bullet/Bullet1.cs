using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigid;
    [SerializeField]
    Animator anim;
    //�� ���� �ı�
    [SerializeField]
    float b1WasTimer = 0f;
    float b1WasShootTimer = 5f;
    [SerializeField]
    bool stop;
    void Update()
    {
        if (!stop)
            transform.Translate(Vector2.right * 50 * Time.deltaTime);

        //if (b1WasTimer < b1WasShootTimer)
        //{
        //    b1WasTimer += Time.deltaTime;
        //}
        //if (b1WasTimer > b1WasShootTimer)
        //{
        //    Bullet1Destroy();
        //    b1WasTimer = 0f;
        //}
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall1") || collision.gameObject.CompareTag("Monster1"))
        {
            StartCoroutine(Animm());
        }
    }
    IEnumerator Animm()
    {
        stop = true;
        anim.SetTrigger("isHit");
        //�ִϸ��̼��� �ٽ� ���ƿ;� �ϴµ� ��������Ʈ ���� �ð����� �ָ��ϰ� ó�� �����ʿ�
        yield return new WaitForSeconds(0.5f);
        stop = false;
        Bullet1Destroy();
        
    }


    void Bullet1Destroy()//�ٽ� �־�
    {
        BulletManager.Instance.Bullet1Insert(gameObject);
    }
}
