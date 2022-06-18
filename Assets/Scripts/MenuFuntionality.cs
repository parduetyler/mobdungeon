using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuFuntionality : MonoBehaviour
{
    [SerializeField] Text healthDisplay;
    [SerializeField] Text damageDisplay;

    [SerializeField] Text moveSpeedDisplay;
    [SerializeField] Text defenseDisplay;
    public Canvas UIMenu;
    public Canvas victoryScreen;
    public Canvas loseScreen;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Player = GameObject.Find("Player");
        PlayerBehavior player = Player.GetComponent<PlayerBehavior>();
        healthDisplay.text = "HP: " + player.health.ToString();
        damageDisplay.text = "DAMAGE: " + player.damage.ToString();
        moveSpeedDisplay.text = "MVSPD: " + player.moveSpeed.ToString();
        defenseDisplay.text = "DEFENSE: " + player.defense.ToString();
        UIMenu.enabled = false;
        victoryScreen.enabled = false;
        loseScreen.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        GameObject Player = GameObject.Find("Player");
        PlayerBehavior player = Player.GetComponent<PlayerBehavior>();
        healthDisplay.text = "HP: " + player.currentHealth.ToString() + "/" + player.health.ToString();
        damageDisplay.text = "DMG: " + player.damage.ToString();
        moveSpeedDisplay.text = "MVSPD: " + player.moveSpeed.ToString();
        defenseDisplay.text = "DEFENSE: " + player.defense.ToString();
        if (Input.GetButtonDown("Cancel"))
        {           
            if (UIMenu.enabled == true)
            {
                OnResumePress();
            }
            else if(UIMenu.enabled == false)
            {
                OnMenuPress();
            }
        }

    }
    //Misc Functions
    void PauseGame()
    {
        Time.timeScale = 0;
    }

    void ResumeGame()
    {
        Time.timeScale = 1;
    }
    //InGameUI functions
    public void OnMenuPress()
    {
        UIMenu.enabled = true;
        PauseGame();

    }
    public void OnResumePress()
    {
        UIMenu.enabled = false;
        ResumeGame();
    }
    //UIMenuFunctions
    public void QuitMenuPress()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitDesktop()
    {
        Application.Quit();
    }
}
