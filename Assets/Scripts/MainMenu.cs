using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject FoxPrefab;
    public GameObject SquirrelPrefab;
    public GameObject characterSelect;
    public GameObject mainMenu;
    public int index;

    public GameController instance;

    public void Awake()
    {
        characterSelect.SetActive(false);
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Play()
    {
        mainMenu.SetActive(false);
        characterSelect.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }

    //Character select menu
    public void Back()
    {
        characterSelect.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void FoxClicked()
    {
        WhichCharacter(0);

    }
    public void SquirrelClicked()
    {
        WhichCharacter(1);
    }
    public void WhichCharacter(int selection)
    {
        if (selection == 0)
        { //fox
            GameController.CharacterSelection = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        { //squirrel 
            GameController.CharacterSelection = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
