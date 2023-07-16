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

    // Start is called before the first frame update
    void Start()
    {
        distanceJoint2D.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            playerChangeTypeManager.Grappling();
            Vector2 mousPos = (Vector2)maincamera.ScreenToWorldPoint(Input.mousePosition);
            lineRenderer.SetPosition(0, mousPos);
            lineRenderer.SetPosition(1, transform.position);
            distanceJoint2D.connectedAnchor = mousPos;
            distanceJoint2D.enabled = true;
            lineRenderer.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
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
