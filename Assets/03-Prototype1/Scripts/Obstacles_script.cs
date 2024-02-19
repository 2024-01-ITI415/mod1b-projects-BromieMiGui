using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles_script : MonoBehaviour
{
    public float Speed = 1f;
    public float UpandDownEdge = 0f;
    public float chanceToChangeDirection = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 po5 = transform.position;
        po5.x += Speed * Time.deltaTime;
        transform.position = po5;

        if (po5.y < -UpandDownEdge)
        {
            Speed = Mathf.Abs(Speed);
        }
        else if (po5.y > UpandDownEdge)
        {
            Speed = -Mathf.Abs(Speed);
        }

    }
    void FixedUpdate()
    {
        if (Random.value < chanceToChangeDirection)
        {
            Speed *= -1;
        }
    }
}
