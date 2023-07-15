using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour//벡터입력으로 움직임
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
    
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
        
    }
    
    void FixedUpdate()
    {
        Vector2 nextVec = inputVec.normalized * playerSpeed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
    }

    //구르기
    public void Roll()
    {
        playerSpeed = rollSpeed;
    }
    //구르지 않기
    public void NotRoll()
    {
        playerSpeed = NotrollSpeed;
    }
}

