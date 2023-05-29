using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform mouse;
    float distanceToTarget;
    // Start is called before the first frame update
    void Start()
    {
        distanceToTarget = transform.position.x - mouse.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(mouse.position.x+distanceToTarget,transform.position.y,transform.position.z);
    }
}
