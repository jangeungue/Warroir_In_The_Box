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
    //몇 초후 파괴
    //[SerializeField]
    //float b1WasTimer = 0f;
    //float b1WasShootTimer = 5f;
    [SerializeField]
    bool stop;
    void Update()
    {
        //총알 이동중
        if (!stop)
        {
            transform.Translate(Vector2.right * 50 * Time.deltaTime);
        }

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
    //어딘가에 닿았다
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall1") || collision.gameObject.CompareTag("Monster1"))
        {
            StartCoroutine(HitAnime());
        }
    }
    //총알 충돌 애니메이션
    IEnumerator HitAnime()
    {
        stop = true;
        anim.SetTrigger("isHit");
        //애니메이션이 다시 돌아와야 하는데 마지막 스프라이트 없고 시간으로 처리 수정필요
        yield return new WaitForSeconds(1);//임시로 시간 늘리고 컴포넌트 끄기 수정필요
        stop = false;
        Bullet1Destroy();
        
    }

    //총알 다시 넣기
    void Bullet1Destroy()
    {
        BulletManager.Instance.Bullet1Insert(gameObject);
    }
}
