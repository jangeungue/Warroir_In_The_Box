using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour//�����Է����� ������
{
    [SerializeField]
    Rigidbody2D rigid;
    [SerializeField]
    PlayerAnimation playerAnimation;

    //�뽬 ����
    public Vector2 inputVec;
    //�뽬 ����
    public float playerSpeed = 7f;
   
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

        playerAnimation.PlayerAnim();
        
        
    }    
    void FixedUpdate()
    {
        //�÷��̾� ���⺤��
        Vector2 nextVec = inputVec.normalized * playerSpeed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);

    }   
    public void Roll()
    {
        playerSpeed = 10;
    }
    public void NotRoll()
    {
        playerSpeed = 7;
    }
}
    
