using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI;
    public float camz;
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        camz = this.transform.position.z;
    }
    void FixedUpdate()
    {
        Vector3 destination;
        if (POI == null)
        {
            destination = Vector3.zero;
        }
        else
        {
            destination = POI.transform.position;
            if (POI.tag == "Projectile")
            {
                if (POI.GetComponent<Rigidbody>().IsSleeping()) {
                    POI = null;
                    return;
                }
            }
        }
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y);
        destination = Vector3.Lerp(transform.position, destination, easing);
        destination.z = camz;
        transform.position = destination;
        Camera.main.orthographicSize = destination.y + 10;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
