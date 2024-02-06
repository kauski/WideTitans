using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// author: Henri Hienonen (last edited 30.3.22)


public class PlayerCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
    }
}
