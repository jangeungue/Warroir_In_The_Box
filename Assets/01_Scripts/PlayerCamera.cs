using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] 
    Camera mainCamera;

    [SerializeField]
    Transform playerTransform;
    [SerializeField]
    float cameraMoveSpeed = 5;

    void Update()
    {
        Vector3 targetPosition = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * cameraMoveSpeed);
    }

    
}