using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Kgun : MonoBehaviour
{
    [SerializeField]
    Transform bulletPos;
    [SerializeField]
    SpriteRenderer spriteRenderer;
    //ÃÑ ¹æÇâ
    float angle;
    Vector2 target, mouse;
    //¹ß»ç ÄðÅ¸ÀÓ
    float b1Timer = 0f;
    float b1ShootTimer = 0.1f;
    
    private void Start()
    {
        this.transform.rotation = Quaternion.identity;
        
    }
    private void Update()
    {       
        LookAtMousePos();
        Bullet1Shoot();
        
    }
    void Bullet1Shoot()
    {
        if (b1Timer < b1ShootTimer)
        {
            b1Timer += Time.deltaTime;
        }
        
        if (Input.GetMouseButton(0) && b1Timer > b1ShootTimer)
        {
            BulletPos.Instance.ShootBullet1(bulletPos.transform);
            b1Timer = 0f;
        }
    }
    void LookAtMousePos()
    {
        target = transform.position;
        // Convert the mouse position from screen coordinates to world coordinates
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Calculate the angle between the mouse position and the target position   
        angle = Mathf.Atan2(mouse.y - target.y, mouse.x - target.x) * Mathf.Rad2Deg;
        // Set the rotation of the current object to the calculated angle
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //ÁÂ¿ì ¹ÝÀü
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
