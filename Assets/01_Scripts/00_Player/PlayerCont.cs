using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour//벡터입력으로 움직임
{
    [SerializeField]
    Vector2 inputVec;
    [SerializeField]
    float playerSpeed = 7;

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

    public void Roll()
    {
        playerSpeed = 10;
    }
    public void NotRoll()
    {
        playerSpeed = 7;
    }
}
    
