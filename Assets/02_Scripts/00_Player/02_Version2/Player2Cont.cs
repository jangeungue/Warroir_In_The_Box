using System.Threading;
using UnityEditor;
using UnityEngine;

public class Player2Cont : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigid;//좌우 이동은 현재 리지드 안 쓰임 점프만
    [SerializeField]
    Animator anim;//애니메이터

    [SerializeField]
    float playerSpeed;//플레이어 기본 스피드 6
    [SerializeField]
    float maxSpeed;//최대 스피드 8
    [SerializeField]
    float minSpeed;//최소 스피드 6
    int playerSpeedUp = 0;//6프레임
    int playerspeedDown = 0;//3프레임

    /*
    public bool isStopAllMovement;//모두멈춤
    */
    
    void Move()//좌우이동
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput > 0)//오른쪽 방향키
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); //오른쪽방향
            transform.Translate(transform.right * playerSpeed * Time.deltaTime);
        }
        else if (horizontalInput < 0)//왼쪽 방향키
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); //왼쪽방향
            transform.Translate(transform.right * -1 * playerSpeed * Time.deltaTime);
        }
        if (horizontalInput > 0 || horizontalInput < 0)
        {
            playerspeedDown = 0;
            if (playerSpeedUp <= 6f)
            {
                playerSpeedUp++;
                playerSpeed += Time.deltaTime; //최대 미만이면 스피드 주고 최대스피드로 제한
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

    void SetAnimation()//애니메이션
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput < 0 || horizontalInput > 0)//플레이어 좌우버튼 누를 때
        {
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }
    }

    void Update()//점프,키 입력,애니메이션
    {
        //PlayerMovePlus();
        SetAnimation();
    }
    void FixedUpdate()//물리,좌우이동,대쉬
    {
        
        Move();//좌우이동                     
        
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
