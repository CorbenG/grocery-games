using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.2f;
    private Vector3 _velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(target.position.x - 24, target.position.y + 34, target.position.z - 24);
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(target.position.x - 24, target.position.y + 34, target.position.z - 24);

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);

    }
}
