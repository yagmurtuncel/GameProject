using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float height;
    [SerializeField] float followSpeed;
    Vector3 NewCameraPos;

    void LateUpdate()
    {
        NewCameraPos= new Vector3 (target.position.x,target.position.y + height,transform.position.z);
        transform.position = Vector3.Lerp(transform.position,NewCameraPos, followSpeed * Time.deltaTime);
    }
}//class
