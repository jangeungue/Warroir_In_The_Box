using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour//벡터입력으로 움직임
{
    [SerializeField]
    Rigidbody2D rigid;
    [SerializeField]
    PlayerAnimation playerAnimation;

    //대쉬 참조
    public Vector2 inputVec;
    //대쉬 참조
    public float playerSpeed = 7f;
   
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

        playerAnimation.PlayerAnim();
        
        
    }    
    void FixedUpdate()
    {
        //플레이어 방향벡터
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
    
