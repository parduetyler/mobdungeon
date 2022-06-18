using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //most likely will have if statements for what type of enemy it is.
    //or will just have seperate AI scripts for each, not sure what would be better. but want to keep it basic with this test enemy
    // Start is called before the first frame update
    public Rigidbody2D rb;
    Vector2 movement;
    GameObject player;
    public GameObject enemy;
    public SpriteRenderer sprite;
    public float moveSpeed = 8f;
    public int health;
    public int damage = 5;
    public int difficulty;

    void Start()
    {
        player = GameObject.Find("Player");
        if (difficulty == 1)
        {
            health = 50 * (2 * difficulty);
        }
        else { }

    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position.x - player.transform.position.x) > 0)
        {
            sprite.flipX = true;
        }
        if ((transform.position.x - player.transform.position.x) < 0)
        {
            sprite.flipX = false;
        }



    }
    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position + (movement)*(moveSpeed) * Time.fixedDeltaTime);

        var step = moveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, player.transform.position) > .5f & Vector3.Distance(transform.position, player.transform.position) < 5f)
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("ApplyDamage", damage,SendMessageOptions.DontRequireReceiver);
        }
    }
    public void ApplyDamage(int damage)
    {
        health -= damage;
        checkIfDead();
    }
    public void checkIfDead()
    {
        if(health <= 0)
        {
            Destroy(enemy);
        }
    }
}
