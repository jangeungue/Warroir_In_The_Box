using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootEffect : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    //발사 애니메이션
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
