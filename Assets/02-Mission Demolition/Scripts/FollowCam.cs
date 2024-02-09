using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public float camz;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
     camz = this.transform.position.z   
    }
    void FixedUpdate()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
