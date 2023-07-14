using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using static BulletTypeClass;
using static GunTypeClass;

public class GunClass : MonoBehaviour
{
    
    


    [SerializeField]
    List<Transform> bulletPos = new List<Transform>();
    [SerializeField]
    SpriteRenderer spriteRenderer;
    //총 방향
    float angle;
    Vector2 target, mouse;
    //발사 쿨타임
    float b1Timer = 0f;
    float b1ShootTimer = 0.1f;

    private void Start()
    {
        this.transform.rotation = Quaternion.identity;
        
    }
    private void Update()
    {       
        LookAtMousePos();
        BulletShoot();
        
    }

    GunType state = GunType.Kgun;

    void BulletShoot()
    {
        //발사 쿨타임 시간 재기
        if (b1Timer < b1ShootTimer)
        {
            b1Timer += Time.deltaTime;
        }
        //좌클 & 발사 쿨타임
        if (Input.GetMouseButton(0) && b1Timer >= b1ShootTimer)
        {
            state = GunType.Kgun;
            if (state == GunType.Kgun)
            {
                BulletPos.Instance.ShootBullet1(bulletPos[0].transform);
            }


            //초기화
            b1Timer = 0f;
        }
        
    }
    //총이 마우스포지션 바라보기
    void LookAtMousePos()
    {
        target = transform.position;
        // 카메라의 마우스포인터 받기
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // target에서 mouse까지의 라디안 값을 계산하고, Mathf.Rad2Deg를 사용하여 해당 값을 각도로 변환
        angle = Mathf.Atan2(mouse.y - target.y, mouse.x - target.x) * Mathf.Rad2Deg;
        // 현재 객체를 해당 각도 angle만큼 회전
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //좌우 반전
        if (angle > 90 || angle < -90)
        {
            spriteRenderer.flipY = true;
        }
        else
        {
            spriteRenderer.flipY = false;
        }
    }
    
}
