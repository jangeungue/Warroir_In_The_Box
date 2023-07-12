using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;
    [SerializeField]
    int playerHealth = 5;
    // Start is called before the first frame update
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Monster1Bullet"))
    //    {
    //        StartCoroutine(TakeDamage(1));
    //    }
    //}
    //IEnumerator TakeDamage(float count)
    //{
    //    playerHealth--;

    //    spriteRenderer.material.color = Color.red;
    //    yield return new WaitForSecondsRealtime(0.01f);//수정필요
    //    spriteRenderer.material.color = Color.white;
    //}
}
