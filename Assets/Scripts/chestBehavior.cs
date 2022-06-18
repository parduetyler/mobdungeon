using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chestBehavior : MonoBehaviour
{
    public GameObject chest;
    public GameObject[] itemPool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int rand = Random.Range(0, itemPool.Length);
            Destroy(chest);
            Instantiate(itemPool[rand], chest.transform.position, Quaternion.identity);
        }
    }
}
