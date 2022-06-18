using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public string type;
    public int contents;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")){

            
            if (this.contents == 1| this.contents == 2){
                usePotion(this.type);
            }
        }
    }
    void usePotion(string type)
    {
        GameObject p = GameObject.Find("Player");
        PlayerBehavior player = p.GetComponent<PlayerBehavior>();
        

        if (type == "healing")
        {            
            player.health += 10;
            player.increaseHealth(10);
            this.contents -= 1;
        }
        if (type == "damage")
        {

            player.damage += 2;
        }
        if (type == "speed")
        {

            player.damage += 2;
        }
        if (type == "weakness")
        {

        }
        if (type == "firing")
        {

        }
        if (type == "poison")
        {

        }
        if (type == "teleport")
        {
            Debug.Log("TELEPORT!");
            GameObject[] rooms = GameObject.FindGameObjectsWithTag("Room");
            int rand = Random.Range(0, rooms.Length);
            player.transform.position = rooms[rand].transform.position;
            this.contents -= 1;
        }
    }
}
