using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    PlayerCont plCont;
    [SerializeField]
    Rigidbody2D rigid;
    void Start()
    {
        plCont = GetComponent<PlayerCont>();
        StartCoroutine(Coroutine_Update());
    }

    [SerializeField]
    float dashTime;
    [SerializeField]
    float maxDashTime;
    /*
    public void PlayerDashStart()
    {
        tmpdir = playerCont.inputVec.normalized * playerCont.playerSpeed * Time.fixedDeltaTime;
        transform.Translate(tmpdir * Time.deltaTime);
        //this.ghost.makeGhost = true;
        if (this.tmpdir == Vector2.zero) this.tmpdir = Vector2.right;

        if (this.dashTime >= this.maxDashTime)
        {
            this.dashTime = 0;
            this.isDash = true;
            //this.ghost.makeGhost = false;
        }

    }
    public void PlayerDashing()
    {
        //플레이어 대쉬중
        if (isDash)
        {
            this.rigid.velocity = tmpdir.normalized * (playerCont.playerSpeed * 5) * Time.deltaTime;
        }
        if (dashTime < maxDashTime)
        {
            this.dashTime += Time.deltaTime;
        }
        else
        {
            this.isDash = false;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            PlayerDashStart();
        }

    }

    void FixedUpdate()
    {
        PlayerDashing(); 
    }
    */
    void Update()
    {
        if (dashTime >= maxDashTime)//처음 입력만 받는 if문
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
                Excute();
        }
    }
    void Excute()
    {
        dashTime = 0;
        moveVector = plCont.inputVec.normalized * 4;//절댓값?오른쪽만 감
        print(plCont.inputVec);
    }
    [SerializeField]
    Transform plPos;
    Vector2 moveVector;
    IEnumerator Coroutine_Update()
    {
        while (true)
        {
            if (dashTime < maxDashTime)
            {
                dashTime += Time.deltaTime;
                transform.Translate(moveVector * Time.deltaTime * plCont.playerSpeed);
            }

            yield return null;
        }        
    }
}
