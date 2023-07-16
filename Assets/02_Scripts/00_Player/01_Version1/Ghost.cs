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
        //��Ʈ �ð� �ʱ�ȭ
        ghostingTime = ghosting;
    }
    void Update()
    {
        //��Ʈ��
        if (makeGhost && ghostingTime > 0)
        {
            ghostingTime -= Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        //��Ʈ ����
        if (makeGhost  && ghostingTime <= 0)
        {
            GameObject currentGhost = Instantiate(ghost, transform.position, transform.rotation);
            Sprite currentSprite = GetComponent<SpriteRenderer>().sprite;
            currentGhost.transform.localScale = transform.localScale;
            currentGhost.GetComponent<SpriteRenderer>().sprite = currentSprite;
            ghostingTime = ghosting;
            Destroy(currentGhost, 1f);//�����ʿ�
        }

    }

    //�ܻ� ���� ����
    public void GhostMake()
    {
        makeGhost = true;
    }
    //�ܻ� ���� �Ұ���
    public void GhostMakeDoNot()
    {
        makeGhost = false;
    }
}
