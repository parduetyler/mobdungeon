using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBehavior : MonoBehaviour
{
    public GameObject boss;
    public GameObject trophy;
    private bool trophySpawned;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (boss == null)
        {
            if (!trophySpawned)
            {
                Instantiate(trophy, transform.localPosition, Quaternion.identity);
                trophySpawned = true;
                //test
            }

        }
    }
    public void Victory()
    {

    }

}
