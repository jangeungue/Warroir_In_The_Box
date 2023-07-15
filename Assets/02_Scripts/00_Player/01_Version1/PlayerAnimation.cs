using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour//좌우입력으로 반응
{
    [SerializeField]
    Animator anim;
    void Update()
    {
        PlayerAnim();
    }
    void PlayerAnim()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (h < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (h > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (h > 0 || h < 0 || v > 0 || v < 0)
        {
            anim.SetBool("isRun", true);
        }
        else
            anim.SetBool("isRun", false);
    }
}
