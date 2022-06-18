using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehavior: MonoBehaviour
{

    public int health = 50;
    public int currentHealth = 50;
    public int damage = 5; 
    public float punchSpeed = 5f;
    public float fireRate = 5f;
    public float moveSpeed = 5f;
    public int defense = 0;
    public GameObject[] potions;
    public GameObject[] items;
    public SpriteRenderer sprite;
    public Rigidbody2D body;
    float minDist = Mathf.Infinity;
    float distance;
    float horizontal;
    float vertical;
    Camera mainCamera;
    public GameObject currRoom = null;
    GameObject player;
    public GameObject punch;
    Canvas loseScreen;
    




    Vector3 screenPosition;
    Vector3 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //inputs
        player = GameObject.Find("Player");
        

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        body = GetComponent<Rigidbody2D>();
        if (horizontal < 0)
        {
            sprite.flipX = true;
        }
        else if(horizontal>0) sprite.flipX = false;
        else if (horizontal == 0){ }
        if (Input.GetMouseButtonDown(0))
        {
            GameObject p;
            mousePos = Input.mousePosition;
            //mousePos.z = 0;
            screenPosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10));
            Vector3 attackDir = screenPosition - player.transform.position;
            Debug.Log("Mouse position: "+ attackDir);
            if(Vector3.Distance(new Vector3(screenPosition.x,screenPosition.y,0), (player.transform.position))< 5) {
                p = Instantiate(punch, new Vector3(screenPosition.x, screenPosition.y, 0), Quaternion.identity);

                p.name = "punch";
                Destroy(p, .5f);
            }

        }
        //find current room
        currRoom = findCurrentRoom();


    }

    private void FixedUpdate()
    {
        //movement
        body.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
 
    }


    public void GetMousePosition()
    {

    }
    public void increaseHealth(int x)
    {
        if (currentHealth + x > health)
        {
            currentHealth = health;
        }
        else
        {
            currentHealth += x;
        }
    }
    public GameObject findCurrentRoom()
    {
        GameObject[] generatedRooms = GameObject.FindGameObjectsWithTag("Room");
        foreach (GameObject room in generatedRooms)
        {
            player = GameObject.Find("Player");
            if (currRoom != null)
            {
                minDist = Vector3.Distance(currRoom.transform.position, player.transform.position);
            }
            distance = Vector3.Distance(room.transform.position, player.transform.position);

            if (distance < minDist)
            {
                currRoom = room;
                // Debug.Log("current room:" + player.transform.position);     
                minDist = Vector3.Distance(currRoom.transform.position, player.transform.position);

            }

        }
        return currRoom;
    }
    public void ApplyDamage(int damage)
    {
        currentHealth -= (damage - defense);
        checkIfDead();
    }
    public void checkIfDead()
    {
        if(currentHealth <= 0)
        {
            
            Debug.Log("You died!");

            //display game over screen
            GameObject lose = GameObject.Find("Lose Screen");
            loseScreen = lose.GetComponent<Canvas>();
            loseScreen.enabled = true;
            Time.timeScale = 0;


        }
    }
}
