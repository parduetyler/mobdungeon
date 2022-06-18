using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trophyVictory : MonoBehaviour
{
    Canvas victoryScreen;
    // Start is called before the first frame update
    void Start()
    {
      GameObject canvas = GameObject.Find("Victory Screen");
       victoryScreen =  canvas.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //victoryscreen
            victoryScreen.enabled = true;
            Time.timeScale = 0;
        }
    }
}
