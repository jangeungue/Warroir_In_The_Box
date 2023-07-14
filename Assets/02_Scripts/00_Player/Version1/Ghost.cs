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
        ghostingTime = ghosting;
    }
    void Update()
    {
        if (makeGhost && ghostingTime > 0)
        {
            ghostingTime -= Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        if (makeGhost  && ghostingTime <= 0)//고스트중
        {
            GameObject currentGhost = Instantiate(ghost, transform.position, transform.rotation);
            Sprite currentSprite = GetComponent<SpriteRenderer>().sprite;
            currentGhost.transform.localScale = transform.localScale;
            currentGhost.GetComponent<SpriteRenderer>().sprite = currentSprite;
            ghostingTime = ghosting;
            Destroy(currentGhost, 1f);//수정필요
        }

    }
    public void GhostMake()
    {
        makeGhost = true;
    }
    public void DoNotGhostMake()
    {
        makeGhost = false;
    }
}
