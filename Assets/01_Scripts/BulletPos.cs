using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletPos : Singleton<BulletPos>
{

    public void ShootBullet1(Transform bulletRotate)
    {
        GameObject BulletObj = BulletManager.Instance.Bullet1Get();//����Ǯ�Ŵ����� �Ѿ� ��ü ����
        BulletObj.transform.position = bulletRotate.position;
        BulletObj.transform.rotation = bulletRotate.rotation;
    }
}
