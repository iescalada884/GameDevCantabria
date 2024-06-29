using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovementScript : MonoBehaviour
{
    public float MovementSpeed = 0.0f;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        transform.position += Vector3.left * MovementSpeed * Time.deltaTime;
    }
}
