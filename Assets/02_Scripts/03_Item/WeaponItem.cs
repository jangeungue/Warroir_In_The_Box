using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponItem : MonoBehaviour
{
    [SerializeField]
    List<GameObject> Weapons = new List<GameObject>();

    bool isWeapon1;
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
            if (isWeapon1)
            {
                //다른 총 저장
                Weapons[0].SetActive(true);//수정필요
            }

        }
    }
    //총 얻기 가능
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            isWeapon1 = true;            
        }
    }
    //총 얻기 불가능
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            isWeapon1 = false;
        }
    }
}
