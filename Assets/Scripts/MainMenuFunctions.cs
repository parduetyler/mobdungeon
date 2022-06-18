using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuFunctions : MonoBehaviour
{
    public Canvas main;
    public Canvas gameStart;
    public int difficulty;
    public Button start;



    // Start is called before the first frame update
    void Start()
    {
       
        main.enabled = true;
        gameStart.enabled = false;

        start.interactable = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Main Menu Buttons
    public void StartButton()
    {
        main.enabled = false;
        gameStart.enabled = true;
    }

    public void StatsButton()
    {

    }


    public void QuitButton()
    {
        Application.Quit();
    }
    //Start Game Sub Menu Buttons
    public void GameBackButton()
    {
        gameStart.enabled = false;
        main.enabled = true;
    }
    public void difficultyNormal()
    {

        difficulty = 0;
        start.interactable = true;
    }
    public void difficultyHard()
    {
        difficulty = 1;
        start.interactable = true;

    }
    public void StartGameConfirmButton()
    {

        SceneManager.LoadScene("TestRoom");
        Time.timeScale = 1;
    }


    //Settings Sub Menu Buttons

}
