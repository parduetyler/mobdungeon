using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class punchBehavior : MonoBehaviour
{
    public PlayerBehavior player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("ApplyDamage", player.damage);
        }
    }
}
