using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerTypeClass;

public class PlayerChangeTypeManager : MonoBehaviour//움직임과 게임성 형태 변환
{
    [SerializeField]
    Rigidbody2D rigid;
    //Player1
    [SerializeField]
    PlayerCont playerCont;
    [SerializeField]
    PlayerRoll playerRoll;
    [SerializeField]
    PlayerDash playerdash;

    //Player2
    [SerializeField]
    Player2Cont player2Cont;
    [SerializeField]
    Player2Jump player2Jump;
    [SerializeField]
    Player2Dash Player2Dash;
    public PlayerType CurrentPlayerType { get; set; }
    void Start()
    {
        CurrentPlayerType = PlayerType.Player1;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ChangePlayerForm"))
        {
            ChangePlayerForm();
            

        }
    }
    void ChangePlayerForm()
    {
        // 플레이어 형태 변경 로직을 구현합니다.
        // 예시: 현재 PlayerType이 Normal이면 Changed로 변경하고, Changed면 Normal로 변경합니다.
        if (CurrentPlayerType == PlayerType.Player1)
        {
            SecondPlayerForm();
            CurrentPlayerType = PlayerType.Player2;
        }
        else if  (CurrentPlayerType == PlayerType.Player2)
        {
            FirstPlayerForm();
            CurrentPlayerType = PlayerType.Player1;
        }
    }

    void FirstPlayerForm()
    {
        rigid.mass = 100f;
        rigid.gravityScale = 0f;
        //Player1       
        playerCont.enabled = true;
        playerRoll.enabled = true;
        playerdash.enabled = true;

        //Player2
        player2Cont.enabled = false;
        player2Jump.enabled = false;
        Player2Dash.enabled = false;
    }
    void SecondPlayerForm()
    {
        rigid.mass = 1f;
        rigid.gravityScale = 3f;
        //Player2
        player2Cont.enabled = true;
        player2Jump.enabled = true;
        Player2Dash.enabled = true;

        //Player1
        playerCont.enabled = false;
        playerRoll.enabled = false;
        playerdash.enabled = false;

        
    }
}
