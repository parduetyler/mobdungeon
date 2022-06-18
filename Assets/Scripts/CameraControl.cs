using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public PlayerBehavior player;
    public Vector3 offset;
    
    // Start is called before the first frame update
    void Start()
    {
        offset.y = 0.9f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.currRoom.transform.position.x + offset.x, player.currRoom.transform.position.y + offset.y, offset.z);
    }
}
