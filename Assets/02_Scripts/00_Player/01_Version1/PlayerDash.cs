using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    PlayerCont playerCont;
    [SerializeField]
    Rigidbody2D rigid;
    [SerializeField]
    Ghost ghost;

    [SerializeField]
    float dashingTime = 0.1f;
    [SerializeField]
    float maxDashingTime = 0.1f;
    [SerializeField]
    float dashCool;
    [SerializeField]
    float dashCoolTime;//쿨타임

    [SerializeField]
    Transform plPos;
    [SerializeField]
    Vector2 moveVector;
    void Start()
    {
        playerCont = GetComponent<PlayerCont>();
        StartCoroutine(Coroutine_Update());

    }
    
    
    void Update()
    {
        if (dashCool < dashCoolTime)
            dashCool += Time.deltaTime;
        if (dashCool >= dashCoolTime && Input.GetKeyDown(KeyCode.LeftShift))
        {            
            Excute();

        }
    }
    void Excute()
    {
        dashCool = 0;
        dashingTime = 0;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveVector = new Vector2(-4 * playerCont.inputVec.x, playerCont.inputVec.y);
        }
        else
        {
            moveVector = playerCont.inputVec.normalized * 4;
        }

    }
    
    IEnumerator Coroutine_Update()
    {
        while (true)
        {
            if (dashingTime < maxDashingTime)
            {
                dashingTime += Time.deltaTime;
                transform.Translate(moveVector * Time.deltaTime * 10);
                ghost.GhostMake(); 
            }
            else
            {
                ghost.DoNotGhostMake();
            }

            yield return null;
        }

    }
}   