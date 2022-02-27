using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.up; //방향 먼저
        // 이동하고 싶다 -> p = p0+vt
        transform.position += dir * speed * Time.deltaTime;
    }
}
