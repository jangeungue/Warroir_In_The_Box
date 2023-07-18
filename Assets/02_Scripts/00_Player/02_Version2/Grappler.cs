using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappler : MonoBehaviour
{
    [SerializeField]
    PlayerChangeTypeManager playerChangeTypeManager;
    [SerializeField]
    Camera maincamera;
    [SerializeField]
    LineRenderer lineRenderer;
    [SerializeField]
    DistanceJoint2D distanceJoint2D;

    [SerializeField]
    Rigidbody2D rigid;
    void Start()
    {
        distanceJoint2D.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            playerChangeTypeManager.Grappling();
            Vector2 mousPos = (Vector2)maincamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousPos, Vector2.zero);
            {

                if (hit.transform != null && hit.transform.gameObject.CompareTag("Roping"))
                {
                    float currentDistance = Vector2.Distance(transform.position, hit.point);

                    distanceJoint2D.distance = currentDistance;

                    lineRenderer.SetPosition(0, mousPos);
                    lineRenderer.SetPosition(1, transform.position);
                    distanceJoint2D.connectedAnchor = mousPos;
                    distanceJoint2D.enabled = true;
                    lineRenderer.enabled = true;

                }
            }
            
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            //rigid.velocity = Vector2.zero;
            playerChangeTypeManager.GrapplingFinish();
            distanceJoint2D.enabled = false;
            lineRenderer.enabled = false;
            
        }
        if (distanceJoint2D.enabled)
        {
            lineRenderer.SetPosition(1, transform.position);
        }
    }
}

