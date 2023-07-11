using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster1 : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;
    [SerializeField]
    float monster1Health = 100;
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet1"))
        {
            print("dd");
            StartCoroutine(TakeDamage(1));
        }
    }
    IEnumerator TakeDamage(float count)
    {
        monster1Health--;
        spriteRenderer.material.color = Color.red;

        yield return new WaitForSeconds(0.1f);
        spriteRenderer.material.color = Color.white;
    }
}
