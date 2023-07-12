using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    PlayerCont playerCont;
    [SerializeField]
    Rigidbody2D rigid;
    [SerializeField]
    Ghost ghost;
    // Start is called before the first frame update
    void Start()
    {
        playerCont = GetComponent<PlayerCont>();
        StartCoroutine(Coroutine_Update());

    }

    [SerializeField]
    float dashTime;
    [SerializeField]
    float maxDashTime;
    void Update()
    {
        if (dashTime >= maxDashTime)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
                Excute();
        }
    }
    void Excute()
    {
        
        dashTime = 0;
        //moveVector = playerCont.inputVec * 4;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveVector = playerCont.inputVec * -4;
        }
        else
        {
            moveVector = playerCont.inputVec * 4;
        }

        print(playerCont.inputVec);
    }
    [SerializeField]
    Transform plPos;
    [SerializeField]
    Vector2 moveVector;
    IEnumerator Coroutine_Update()
    {
        while (true)
        {
            if (dashTime < maxDashTime)
            {
                dashTime += Time.deltaTime;
                transform.Translate(moveVector * Time.deltaTime * 10);
                ghost.makeGhost = true;
            }
            else
            {
                ghost.makeGhost = false;
            }

            yield return null;
        }

    }
}   