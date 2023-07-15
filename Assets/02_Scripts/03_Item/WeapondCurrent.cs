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
    //총 아이템 얻기
    void GetWeapon( )
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isWeapon)
            {
                //다른 총 저장
                gunClass.IsWeapon();
                Weapons[0].SetActive(true);//수정필요
            }

        }
    }
    //총 얻기 가능
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            isWeapon = true;            
        }
        

    }
    //총 얻기 불가능
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            isWeapon = false;
        }
    }
}
