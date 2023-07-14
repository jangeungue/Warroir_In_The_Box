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
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isWeapon1)
            {
                //�ٸ� �� ����
                Weapons[0].SetActive(true);//�����ʿ�
            }
            
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {            
            isWeapon1 = true;            
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            isWeapon1 = false;
        }
    }
}
