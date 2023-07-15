using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponCurrent : MonoBehaviour
{
    [SerializeField]
    GunClass gunClass;
    [SerializeField]
    List<GameObject> Weapons = new List<GameObject>();

    bool isWeapon;
    // Update is called once per frame
    void Update()
    {
        GetWeapon();
        
    }
    //�� ������ ���
    void GetWeapon( )
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isWeapon)
            {
                //�ٸ� �� ����
                gunClass.IsWeapon();
                Weapons[0].SetActive(true);//�����ʿ�
            }

        }
    }
    //�� ��� ����
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            isWeapon = true;            
        }
        

    }
    //�� ��� �Ұ���
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            isWeapon = false;
        }
    }
}
