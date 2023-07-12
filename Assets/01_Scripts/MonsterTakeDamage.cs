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
    float monster1Health = 100;   
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

        animator.SetTrigger("isBlueSlimHurt");


        yield return null;
        //yield return new WaitForSecondsRealtime(0.05f);//수정필요
        //animator.SetBool("isBlueSlimHurt", false);
    }
}
