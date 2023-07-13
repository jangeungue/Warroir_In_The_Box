using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTakeDamage : MonoBehaviour
{
    [SerializeField]
    Animator anim;
    [SerializeField]
    SpriteRenderer spriteRenderer;
    [SerializeField]
    CapsuleCollider2D capsuleCollider2D;


    [SerializeField]
    float monster1Health;//30
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet1"))
        {
            StartCoroutine(TakeDamage(1));
        }
        
    }
    IEnumerator TakeDamage(float count)
    {
        monster1Health--;
        capsuleCollider2D.size = new Vector2(10, 10);
        anim.SetTrigger("isMonsterHurt");

        if (monster1Health <= 0)
        {
            anim.SetTrigger("isMonsterDeath");
            capsuleCollider2D.enabled = false;

            yield return new WaitForSeconds(1f);//수정필요
            Destroy(gameObject);//수정필요
        }
    }   
}
