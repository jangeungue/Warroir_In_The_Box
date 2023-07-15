using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoll : MonoBehaviour
{
    [SerializeField]
    PlayerCont playerCont;
    float rolling;
    float rollTimer = 1;
    // Update is called once per frame
    void Update()
    {
        if (rolling < rollTimer)
        {
            playerCont.Roll();
            rolling += Time.deltaTime;
        }
        else
        {
            playerCont.NotRoll();
        }
        if (Input.GetKeyDown(KeyCode.Space) && rolling > rollTimer)
        {
            rolling = 0;
            
        }
        
    }
}
