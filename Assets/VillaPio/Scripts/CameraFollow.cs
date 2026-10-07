using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);    
    }
}
