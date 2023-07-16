using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Dash : MonoBehaviour
{
    float dashDir;//대쉬방향
    Vector2 dashVector;//대쉬할 거리
    [SerializeField]
    float dashSpeed = 5f;//대쉬 스피드 5
    [SerializeField]
    float dashSize = 5f;

    [SerializeField]
    float useTimer;
    [SerializeField]
    bool canUseSkill;
    void Update()

    {
        if (useTimer <= 0.3f && canUseSkill)
        {           
            var nextPlayerPos = Vector3.Lerp(transform.position, dashVector, dashSpeed / 100);
            nextPlayerPos.y = transform.position.y;

            transform.position = nextPlayerPos;
        }
        else
        {
            canUseSkill = false;
        }
        if (useTimer < 0.3f)
        {
            useTimer += Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            UseDash();
        }
    }
    void UseDash()
    {
        canUseSkill = true;
        useTimer = 0f;
        if (transform.rotation.y == 0)
        {
            dashDir = transform.localScale.x;
            dashVector = new Vector2(transform.position.x + dashDir * dashSize, transform.position.y);
        }
        else
        {
            dashDir = -transform.localScale.x;
            dashVector = new Vector2(transform.position.x + dashDir * dashSize, transform.position.y);
        }
        
    }
}
