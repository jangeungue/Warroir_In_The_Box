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
    //�� ����
    float angle;
    Vector2 target, mouse;
    //�߻� ��Ÿ��
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
        //�߻� ��Ÿ�� �ð� ���
        if (b1Timer < b1ShootTimer)
        {
            b1Timer += Time.deltaTime;
        }
        //��Ŭ & �߻� ��Ÿ��
        if (Input.GetMouseButton(0) && b1Timer >= b1ShootTimer)
        {
            state = GunType.Kgun;
            if (state == GunType.Kgun)
            {
                BulletPos.Instance.ShootBullet1(bulletPos[0].transform);
            }


            //�ʱ�ȭ
            b1Timer = 0f;
        }
        
    }
    //���� ���콺������ �ٶ󺸱�
    void LookAtMousePos()
    {
        target = transform.position;
        // ī�޶��� ���콺������ �ޱ�
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // target���� mouse������ ���� ���� ����ϰ�, Mathf.Rad2Deg�� ����Ͽ� �ش� ���� ������ ��ȯ
        angle = Mathf.Atan2(mouse.y - target.y, mouse.x - target.x) * Mathf.Rad2Deg;
        // ���� ��ü�� �ش� ���� angle��ŭ ȸ��
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //�¿� ����
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
