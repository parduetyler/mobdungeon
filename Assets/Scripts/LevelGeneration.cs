using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    //logic of how the level is generated. 
    //generate random number, 0,1,2,3 for each possible direction the path can move in.
    //or maybe, generate a starting room and a boss room, using the spawn location grid, and make sure that they're a certain length apart so floors aren't too short
    //draw a random line between these two points, take one or two of them to use as a path to generate rooms on the grid.
    //afterwards, generate random special rooms like treasure rooms and potion rooms using random spots on the line, and checking that there's an applicable spot inside border and not already instantiated
    public GameObject[] spawnLocations;
    public GameObject startR;
    public GameObject bossR;
    public GameObject itemR;
    public GameObject potionR;
    public GameObject[] rooms;
    GameObject room;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //Determine Start Room and Boss Room
        int rand = Random.Range(0, rooms.Length);
        int startRoom = Random.Range(0, 99);
        int bossRoom = Random.Range(0, 99);

        while((bossRoom - startRoom < 40) | (Mathf.Abs(bossRoom%10 - startRoom%10) < 2))
        {
            startRoom = Random.Range(0, 99);
            bossRoom = Random.Range(0, 99);
        }
        Debug.Log("bossRoom: "+ bossRoom + "startRoom: " + startRoom);
        
        //Generate Start Room and Boss Room
        Instantiate(spawnLocations[startRoom], spawnLocations[startRoom].transform.position, Quaternion.identity);
        room = Instantiate(startR, spawnLocations[startRoom].transform.position, Quaternion.identity);
        room.name = "startRoom";
        
        Instantiate(spawnLocations[bossRoom], spawnLocations[bossRoom].transform.position, Quaternion.identity);
        room = Instantiate(bossR, spawnLocations[bossRoom].transform.position, Quaternion.identity);
        room.name = "bossRoom";



        //Create line of rooms that connect start and boss rooms
        Debug.Log("start room co-ords:" + spawnLocations[startRoom].transform.position + "boss room co-ords:" + spawnLocations[bossRoom].transform.position);
        float horizRooms = (spawnLocations[bossRoom].transform.position.x - spawnLocations[startRoom].transform.position.x) / 10;
        float vertRooms = (spawnLocations[bossRoom].transform.position.y - spawnLocations[startRoom].transform.position.y) / 10;
        Debug.Log(horizRooms + " " + vertRooms);
        int i = 0;
        int seq = 0;
        bool itemRoomCreated = false;
        //x-coordinate rooms
        int tempRoom = startRoom;
        if (horizRooms > 0)
        {
            for (i = 0; i < horizRooms; i++)
            {
                
                tempRoom += 1;
                rand = Random.Range(0, rooms.Length);
                Instantiate(spawnLocations[tempRoom], spawnLocations[tempRoom].transform.position, Quaternion.identity);
                room = Instantiate(rooms[rand], spawnLocations[tempRoom].transform.position, Quaternion.identity);
                room.name = "standardRoom("+seq+")";
                seq++;
            }
        }
        else if (horizRooms < 0)
        {
            for (i = 0; i > horizRooms; i--)
            {
                
                tempRoom -= 1;
                rand = Random.Range(0, rooms.Length);
                Instantiate(spawnLocations[tempRoom], spawnLocations[tempRoom].transform.position, Quaternion.identity);
                room = Instantiate(rooms[rand], spawnLocations[tempRoom].transform.position, Quaternion.identity);
                room.name = "standardRoom(" + seq + ")";
                seq++;
            }
        }
        else { }

        //y co-ordinate rooms
        if (vertRooms > 0)
        {
            for (i = 0; i < vertRooms-1; i++)
            {
                
                tempRoom -= 10;
                rand = Random.Range(0, rooms.Length);
                Instantiate(spawnLocations[tempRoom], spawnLocations[tempRoom].transform.position, Quaternion.identity);
                room = Instantiate(rooms[rand], spawnLocations[tempRoom].transform.position, Quaternion.identity);
                room.name = "standardRoom(" + seq + ")";
                seq++;
                int rand2 = Random.Range(0, 3);
                if (!itemRoomCreated)
                {
                    if(rand2 == 1)
                    {
                        int rand3 = Random.Range(0, 1);
                        if(rand3 == 0)
                        {
                            tempRoom += 1;
                            Instantiate(spawnLocations[tempRoom], spawnLocations[tempRoom].transform.position, Quaternion.identity);
                            room = Instantiate(itemR, spawnLocations[tempRoom].transform.position, Quaternion.identity);
                            tempRoom -= 1;
                            itemRoomCreated = true;
                        }
                        else
                        {
                            tempRoom -= 1;
                            Instantiate(spawnLocations[tempRoom], spawnLocations[tempRoom].transform.position, Quaternion.identity);
                            room = Instantiate(itemR, spawnLocations[tempRoom].transform.position, Quaternion.identity);
                            tempRoom += 1;
                            itemRoomCreated = true;
                        }
                        
                    }

                }
            }
        }
        else if (vertRooms < 0)
        {
            for (i = -1; i > vertRooms; i--)
            {
                
                tempRoom += 10;
                rand = Random.Range(0, rooms.Length);
                Instantiate(spawnLocations[tempRoom], spawnLocations[tempRoom].transform.position, Quaternion.identity);
                room = Instantiate(rooms[rand], spawnLocations[tempRoom].transform.position, Quaternion.identity);
                room.name = "standardRoom(" + seq + ")";
                seq++;
                int rand2 = Random.Range(0, 3);
                if (!itemRoomCreated)
                {
                    if (rand2 == 1)
                    {
                        int rand3 = Random.Range(0, 1);
                        if (rand3 == 0)
                        {
                            tempRoom += 1;
                            Instantiate(spawnLocations[tempRoom], spawnLocations[tempRoom].transform.position, Quaternion.identity);
                            room = Instantiate(itemR, spawnLocations[tempRoom].transform.position, Quaternion.identity);
                            tempRoom -= 1;
                            itemRoomCreated = true;
                        }
                        else
                        {
                            tempRoom -= 1;
                            Instantiate(spawnLocations[tempRoom], spawnLocations[tempRoom].transform.position, Quaternion.identity);
                            room = Instantiate(itemR, spawnLocations[tempRoom].transform.position, Quaternion.identity);
                            tempRoom += 1;
                            itemRoomCreated = true;
                        }

                    }

                }
            }
        }
        if (!itemRoomCreated)
        {
            int rand3 = Random.Range(0, 1);
            if (rand3 == 0)
            {
                tempRoom += 1;
                Instantiate(spawnLocations[tempRoom], spawnLocations[tempRoom].transform.position, Quaternion.identity);
                room = Instantiate(itemR, spawnLocations[tempRoom].transform.position, Quaternion.identity);
                tempRoom -= 1;
                itemRoomCreated = true;
            }
            else
            {
                tempRoom -= 1;
                Instantiate(spawnLocations[tempRoom], spawnLocations[tempRoom].transform.position, Quaternion.identity);
                room = Instantiate(itemR, spawnLocations[tempRoom].transform.position, Quaternion.identity);
                tempRoom += 1;
                itemRoomCreated = true;
            }
        }
        //generate item and potion rooms


        //put player in starting room
        player.transform.position = spawnLocations[startRoom].transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
