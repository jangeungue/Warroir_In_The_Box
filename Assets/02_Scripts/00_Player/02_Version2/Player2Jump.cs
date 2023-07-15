using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Jump : MonoBehaviour
{
    [SerializeField]
    bool isGround;
    [SerializeField]
    int jumpForce;//점프 힘 
    [SerializeField]
    bool isDoubleJumpState = false;//2단 감지


    [SerializeField]
    Rigidbody2D rigid;//좌우 이동은 현재 리지드 안 쓰임 점프만
    [SerializeField]
    Animator anim;//애니메이터

    void Update()
    {
        Jump();
    }
    void FixedUpdate()
    {
        
        IsLand();//레이캐스트 땅 감지
    }
    public void Jump()//2단점프
    {
        if (isGround)
        {
            isDoubleJumpState = true;
        }

        if (isGround && Input.GetKeyDown(KeyCode.Space))//임시 수정 필요
        {
            //jumpForce = 20;
            JumpAddForce();

        }
        if (!isGround && Input.GetKeyDown(KeyCode.Space) && isDoubleJumpState)
        {
            //jumpForce = 20;
            JumpAddForce();
            isDoubleJumpState = false;
        }
    }
    void JumpAddForce()
    {
        
        rigid.velocity = Vector2.zero;
        rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);//즉각적인 점프
        //anim.SetBool("isJumping", true);
    }

    public void IsLand()//레이캐스트 땅 감지
    {
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down * 2f, new Color(0, 1, 0));
            //Land만 감지하겠다
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 2, LayerMask.GetMask("Land"));
            if (rayHit.collider != null)
            {
                //anim.SetBool("isJumping", false);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)//바닥에 착지할 떄
    {
        if (collision.gameObject.CompareTag("Wall1"))
        {
            isGround = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)//바닥에서 떨어질 때
    {
        if (collision.gameObject.CompareTag("Wall1"))
        {
            isGround = false;
        }
    }
}
