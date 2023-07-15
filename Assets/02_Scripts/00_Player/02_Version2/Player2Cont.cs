using System.Threading;
using UnityEditor;
using UnityEngine;

public class Player2Cont : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigid;//�¿� �̵��� ���� ������ �� ���� ������
    [SerializeField]
    Animator anim;//�ִϸ�����

    [SerializeField]
    float playerSpeed;//�÷��̾� �⺻ ���ǵ� 6
    [SerializeField]
    float maxSpeed;//�ִ� ���ǵ� 8
    [SerializeField]
    float minSpeed;//�ּ� ���ǵ� 6
    int playerSpeedUp = 0;//6������
    int playerspeedDown = 0;//3������

    /*
    public bool isStopAllMovement;//��θ���
    */
    
    void Move()//�¿��̵�
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput > 0)//������ ����Ű
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); //�����ʹ���
            transform.Translate(transform.right * playerSpeed * Time.deltaTime);
        }
        else if (horizontalInput < 0)//���� ����Ű
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); //���ʹ���
            transform.Translate(transform.right * -1 * playerSpeed * Time.deltaTime);
        }
        if (horizontalInput > 0 || horizontalInput < 0)
        {
            playerspeedDown = 0;
            if (playerSpeedUp <= 6f)
            {
                playerSpeedUp++;
                playerSpeed += Time.deltaTime; //�ִ� �̸��̸� ���ǵ� �ְ� �ִ뽺�ǵ�� ����
            }
            else
            {
                playerSpeed = maxSpeed;
            }
        }
        else
        {
            
            playerSpeedUp = 0;
            if (playerspeedDown <= 3f)
            {
                playerspeedDown++;
                playerSpeed -= Time.deltaTime;
            }
            else
            {
                playerSpeed = minSpeed;
            }
        }
        
    }

    void SetAnimation()//�ִϸ��̼�
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput < 0 || horizontalInput > 0)//�÷��̾� �¿��ư ���� ��
        {
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }
    }

    void Update()//����,Ű �Է�,�ִϸ��̼�
    {
        //PlayerMovePlus();
        SetAnimation();
    }
    void FixedUpdate()//����,�¿��̵�,�뽬
    {
        
        Move();//�¿��̵�                     
        
    }
    /*
    public float moveSpeedPlus;
    public void PlayerMovePlus()
    {
        if (moveSpeedPlus > 0f)
            maxSpeed = 9f;
        else
            maxSpeed = 6f;
    }
    */
}
