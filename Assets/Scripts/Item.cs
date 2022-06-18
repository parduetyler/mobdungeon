using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item: MonoBehaviour
{
    string itemName;
    string itemDesc;
    public int itemID;
    public Item item;
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
        GameObject Player = GameObject.Find("Player");
        PlayerBehavior player = Player.GetComponent<PlayerBehavior>();
        if (collision.gameObject.tag == "Player")
        {
            switch (itemID)
            {
                case 0:
                    item.itemName = "Mushroom";
                    item.itemDesc = "You feel BIGGER! +4 Damage, +20 Health, -1 Speed ";
                    player.health += 20;
                    player.increaseHealth(20);
                    player.transform.localScale += new Vector3(1, 1, 0);
                    player.damage += 4;
                    player.moveSpeed -= 1;
                    Destroy(item);
                    break;
                case 1:
                    player.defense += 2;
                    Destroy(item);
                    break;
                case 2:
                    player.health += 30;
                    player.increaseHealth(30);
                    Destroy(item);
                    break;
                case 3:
                    player.damage += 4;
                    Destroy(item);
                    break;
                case 4:
                    player.moveSpeed += 2;
                    Destroy(item);
                    break;

            }
        }
    }

}
