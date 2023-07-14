using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletPos : Singleton<BulletPos>
{
    [SerializeField]
    ShootEffect shootEffect;
    [SerializeField]
    GameObject effect;
    public void ShootBullet1(Transform bulletRotate)
    {
        GameObject BulletObj = BulletManager.Instance.Bullet1Get();//옵젝풀매니저의 총알 객체 생성
        BulletObj.transform.position = bulletRotate.position;
        BulletObj.transform.rotation = bulletRotate.rotation;

        //총알 발사 애니메이션 호출
        effect.SetActive(true);
        shootEffect.Shoot();
    }
}
