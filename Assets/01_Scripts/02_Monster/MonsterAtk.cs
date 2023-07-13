using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAtk : MonoBehaviour
{
    [SerializeField]
    Animator anim;


    [SerializeField]
    bool isAtkStartPlayer;
    [SerializeField]
    Vector3 target;

    void Update()
    {
        if (isAtkStartPlayer)
        {
            target =  GameObject.FindGameObjectWithTag("Player").transform.position;
            Vector3 direction = target - transform.position;
            transform.Translate(direction * Time.deltaTime);

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
