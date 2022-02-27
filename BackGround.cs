using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public Material bgMaterial;

    public float scrollSpeed = 0.2f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = Vector2.up;

        bgMaterial.mainTextureOffset += dir * scrollSpeed * Time.deltaTime;
    }
}
