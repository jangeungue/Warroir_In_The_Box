using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootEffect : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    [SerializeField]
    float time;
    float timer = 0.1f;
    void Update()
    {
        if (time < timer)
            time += timer;
        if (time >= timer)
        {
            gameObject.SetActive(false);
        }
    }
    public void Shoot()
    {
        anim.SetTrigger("isShoot");
        //gameObject.SetActive(false);
        time = 0;

        
    }
}
