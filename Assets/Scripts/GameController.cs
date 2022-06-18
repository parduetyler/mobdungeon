using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] rooms;
    public GameObject[] itemPool;
    public GameObject[] pickups;
    public GameObject[] potions;
    GameObject[] currentRoom;
    // Start is called before the first frame update
    void Start()
    {
        GeneratePotions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GeneratePotions()
    {
        int i = 0;
        for (i = 0; i < 3; i++)
        {
            int rand = Random.Range(0, potions.Length);
            Instantiate(potions[rand], new Vector3(0, 0, 0), Quaternion.identity);

        }

    }
}
