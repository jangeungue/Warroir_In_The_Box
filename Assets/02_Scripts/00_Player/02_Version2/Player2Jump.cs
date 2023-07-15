using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Jump : MonoBehaviour
{
    [SerializeField]
    bool isGround;
    [SerializeField]
    int jumpForce;//���� �� 
    [SerializeField]
    bool isDoubleJumpState = false;//2�� ����


    [SerializeField]
    Rigidbody2D rigid;//�¿� �̵��� ���� ������ �� ���� ������
    [SerializeField]
    Animator anim;//�ִϸ�����

    void Update()
    {
        Jump();
    }
    void FixedUpdate()
    {
        
        IsLand();//����ĳ��Ʈ �� ����
    }
    public void Jump()//2������
    {
        if (isGround)
        {
            isDoubleJumpState = true;
        }

        if (isGround && Input.GetKeyDown(KeyCode.Space))//�ӽ� ���� �ʿ�
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
        rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);//�ﰢ���� ����
        //anim.SetBool("isJumping", true);
    }

    public void IsLand()//����ĳ��Ʈ �� ����
    {
        if (rigid.velocity.y < 0)
        {
            Debug.DrawRay(rigid.position, Vector3.down * 2f, new Color(0, 1, 0));
            //Land�� �����ϰڴ�
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 2, LayerMask.GetMask("Land"));
            if (rayHit.collider != null)
            {
                //anim.SetBool("isJumping", false);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D collision)//�ٴڿ� ������ ��
    {
        if (collision.gameObject.CompareTag("Wall1"))
        {
            isGround = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)//�ٴڿ��� ������ ��
    {
        if (collision.gameObject.CompareTag("Wall1"))
        {
            isGround = false;
        }
    }
}
