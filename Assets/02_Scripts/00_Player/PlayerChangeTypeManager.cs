using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerTypeClass;

public class PlayerChangeTypeManager : MonoBehaviour//�����Ӱ� ���Ӽ� ���� ��ȯ
{
    [SerializeField]
    Rigidbody2D rigid;
    [SerializeField]
    Ghost ghost;
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
    Player2Dash player2Dash;
    [SerializeField]
    GameObject grappler;
    [SerializeField]
    DistanceJoint2D distanceJoint2D;
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
        // �÷��̾� ���� ���� ������ �����մϴ�.
        // ����: ���� PlayerType�� Normal�̸� Changed�� �����ϰ�, Changed�� Normal�� �����մϴ�.
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
        player2Dash.enabled = false;

        grappler.SetActive(false);
        //distanceJoint2D.enabled = false;
    }
    void SecondPlayerForm()
    {
        rigid.mass = 1f;
        rigid.gravityScale = 3f;
        //Player2
        player2Cont.enabled = true;
        player2Jump.enabled = true;
        player2Dash.enabled = true;

        grappler.SetActive(true);
        //distanceJoint2D.enabled = true;

        //Player1
        playerCont.enabled = false;
        playerRoll.enabled = false;
        playerdash.enabled = false;


    }
    public void Grappling()
    {
        //Player2
        player2Cont.enabled = false;
        player2Jump.enabled = false;
        //player2Dash.enabled= false;
        ghost.enabled = false;
    }
    public void GrapplingFinish()
    {
        //Player2
        player2Cont.enabled = true;
        player2Jump.enabled = true;
        //player2Dash.enabled = true;
        ghost.enabled = true;
    }
}
