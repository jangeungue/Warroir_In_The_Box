using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    int playerHealth = 5;


    void PlayerTakeDamage()
    {
        playerHealth--;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall1"))
            return;

        if (collision.gameObject.CompareTag("Monster1"))
        {
            PlayerTakeDamage();
        }
    }
}
