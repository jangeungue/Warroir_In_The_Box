using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour//�����Է����� ������
{
    [SerializeField]
    Vector2 inputVec;
    [SerializeField]
    float speed = 7;

    [SerializeField]
    Rigidbody2D rigid;   
    [SerializeField]
    PlayerAnimation playerAnimation;
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

        playerAnimation.PlayerAnim();
    }
    
    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }
}
    
