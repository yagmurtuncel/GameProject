using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] private float smoothX;
    [SerializeField] private float smoothY;

    [SerializeField] private float minX;
    [SerializeField] private float minY;
    [SerializeField] private float maxX;
    [SerializeField] private float maxY;

   

    void LateUpdate()
    {
        float posX = Mathf.MoveTowards(transform.position.x, target.position.x, smoothX);
        float posY = Mathf.MoveTowards(transform.position.y, target.position.y, smoothY);

        transform.position = new Vector3(Mathf.Clamp(posX, minX, maxX), Mathf.Clamp(posY, minY, maxY), transform.position.z);

    }


}
