using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    
    float ghosting;
    [SerializeField]
    float ghostingTime;

    [SerializeField]
    GameObject ghost;

    [SerializeField] 
    bool makeGhost;

    void Start()
    {
        //고스트 시간 초기화
        ghostingTime = ghosting;
    }
    void Update()
    {
        //고스트중
        if (makeGhost && ghostingTime > 0)
        {
            ghostingTime -= Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        //고스트 생성
        if (makeGhost  && ghostingTime <= 0)
        {
            GameObject currentGhost = Instantiate(ghost, transform.position, transform.rotation);
            Sprite currentSprite = GetComponent<SpriteRenderer>().sprite;
            currentGhost.transform.localScale = transform.localScale;
            currentGhost.GetComponent<SpriteRenderer>().sprite = currentSprite;
            ghostingTime = ghosting;
            Destroy(currentGhost, 1f);//수정필요
        }

    }

    //잔상 생성 가능
    public void GhostMake()
    {
        makeGhost = true;
    }
    //잔상 생성 불가능
    public void GhostMakeDoNot()
    {
        makeGhost = false;
    }
}
