using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour//�����Է����� ������
{
    [SerializeField]
    Rigidbody2D rigid;
    [SerializeField]
    PlayerAnimation playerAnimation;

    public Vector2 inputVec;
    [SerializeField]
    float playerSpeed;//10
    [SerializeField]
    int rollSpeed;
    [SerializeField]
    int NotrollSpeed;
    [SerializeField]
    bool isDash;
    void Update()
    {
        if (!isDash)
        {
            inputVec.x = Input.GetAxisRaw("Horizontal");
            inputVec.y = Input.GetAxisRaw("Vertical");
        }
    }
    
    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * playerSpeed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    //������
    public void Roll()
    {
        playerSpeed = rollSpeed;
    }
    //������ �ʱ�
    public void NotRoll()
    {
        playerSpeed = NotrollSpeed;
    }

    //���� �� �ȵ�..
    public void IsDash()
    {
        isDash = true;
    }
    public void IsNotDash()
    {
        isDash = false;
    }
}

