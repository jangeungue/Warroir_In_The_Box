using System.Threading;
using UnityEditor;
using UnityEngine;

public class Player2Cont : MonoBehaviour
{
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

    void FixedUpdate()//물리,좌우이동,대쉬
    {

        Move();//좌우이동                     

    }
    void Move()//좌우이동
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput > 0)//오른쪽 방향키
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); //오른쪽방향
            transform.Translate(transform.right * playerSpeed * Time.fixedDeltaTime);
        }
        else if (horizontalInput < 0)//왼쪽 방향키
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); //왼쪽방향
            transform.Translate(transform.right * -1 * playerSpeed * Time.fixedDeltaTime);
        }
        if (horizontalInput > 0 || horizontalInput < 0)
        {
            playerspeedDown = 0;
            if (playerSpeedUp <= 6f)
            {
                playerSpeedUp++;
                playerSpeed += Time.fixedDeltaTime; //최대 미만이면 스피드 주고 최대스피드로 제한
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
                playerSpeed -= Time.fixedDeltaTime;
            }
            else
            {
                playerSpeed = minSpeed;
            }
        }
        
    }
    
}
