using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour//벡터입력으로 움직임
{
    [SerializeField]
    public Vector2 inputVec;
    [SerializeField]
    public float playerSpeed = 7;

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
        Vector2 nextVec = inputVec.normalized * playerSpeed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    //구르기
    public void Roll()
    {
        playerSpeed = 10;
    }
    //구르지 않기
    public void NotRoll()
    {
        playerSpeed = 7;
    }
}
    
