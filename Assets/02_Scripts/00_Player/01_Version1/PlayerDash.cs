using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    [SerializeField]
    PlayerCont playerCont;
    [SerializeField]
    Ghost ghost;

    [SerializeField]
    int dashPower;
    [SerializeField]
    float dashingTime = 0.1f;
    [SerializeField]
    float maxDashingTime = 0.1f;
    [SerializeField]
    float dashCool;
    [SerializeField]
    float dashCoolTime;//쿨타임

    [SerializeField]
    Vector2 moveVector;

    void Update()
    {
        if (dashCool < dashCoolTime)
            dashCool += Time.deltaTime;
        if (dashCool >= dashCoolTime && Input.GetKeyDown(KeyCode.LeftShift))
        {
            playerCont.IsDash();
            Excute();
        }
        if (dashingTime < maxDashingTime)
        {
            dashingTime += Time.deltaTime;
            if (moveVector != Vector2.zero)
            {
                transform.Translate(moveVector * Time.deltaTime * dashPower);
            }
            else
            {
                if (transform.rotation == Quaternion.Euler(0, -180, 0))
                    transform.Translate(Vector2.right * Time.deltaTime * dashPower * 5);
                else if (transform.rotation == Quaternion.Euler(0, 0, 0))
                    transform.Translate(Vector2.right * Time.deltaTime * dashPower * 5);
            }            
            ghost.GhostMake();
        }
        else
        {
            playerCont.IsNotDash();
            ghost.GhostMakeDoNot();
        }
    }
    void Excute()
    {
        dashCool = 0;
        dashingTime = 0;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveVector = new Vector2(playerCont.inputVec.x * -5, playerCont.inputVec.normalized.y * 5);
        }
        else
        {
            moveVector = new Vector2(playerCont.inputVec.x * 5, playerCont.inputVec.normalized.y * 5);
        }

    }

}