using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserScript : MonoBehaviour
{
    public Sprite laserOn;
    public Sprite laserOff;

    public float toogleInterval = 0.5f;
    public float rotationSpeed = 0f;

    bool isLaserOn=true;
    float timeUntilNextToogle;

    Collider2D laserCollider;
    SpriteRenderer laserRenderer;
    // Start is called before the first frame update
    void Start()
    {
        timeUntilNextToogle = toogleInterval;
        laserCollider = gameObject.GetComponent<Collider2D>();
        laserRenderer = gameObject.GetComponent<SpriteRenderer>();        
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilNextToogle -= Time.deltaTime;
        if (timeUntilNextToogle < 0)
        {
            isLaserOn = !isLaserOn;
            laserCollider.enabled = isLaserOn;
            if (isLaserOn)
            {
                laserRenderer.sprite = laserOn;
            }
            else
            {
                laserRenderer.sprite = laserOff;
            }
            timeUntilNextToogle = toogleInterval;
        }
        transform.RotateAround(transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
