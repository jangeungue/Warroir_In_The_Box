using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTakeDamage : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    SpriteRenderer spriteRenderer;
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

        animator.SetTrigger("isMonsterHurt");

        if (monster1Health <= 0)
        {
            animator.SetTrigger("isMonsterDeath");


            yield return new WaitForSeconds(1f);//수정필요
            Destroy(gameObject);
        }
    }   
}
