using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAtk : MonoBehaviour
{
    [SerializeField]
    Animator anim;
    [SerializeField]
    Rigidbody2D rigid;

    [SerializeField]
    bool isAtkStartPlayer;
    [SerializeField]
    Vector2 target;
 
    void FixedUpdate()
    {
        if (isAtkStartPlayer)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform.position;
            Vector2 dirVec = target - rigid.position;
            Vector2 nextVec = dirVec.normalized * 5f * Time.fixedDeltaTime;
            rigid.MovePosition(rigid.position + nextVec);
            rigid.velocity = Vector2.zero;
            //transform.Translate(direction * Time.deltaTime * 0.5f);

        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("isMonsterJump", true);
            isAtkStartPlayer = true;            
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isAtkStartPlayer = false;
            anim.SetBool("isMonsterJump", false);
            
        }
    }
}
