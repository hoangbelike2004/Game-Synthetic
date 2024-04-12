using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed = 4f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         float moveX =Input.GetAxis("Horizontal");
        if((moveX>0 || transform.position.x >= -3.06f) && (moveX<0||transform.position.x <= 2.5f))
        {
            transform.position += Vector3.right * Time.deltaTime * speed * moveX;
        }
         //transform.Translate(moveX * speed * Time.deltaTime * Vector2.right);

    }
}
