using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public Transform Destination;
    public GameObject UI_WIN;
    public GameObject UI_Dead;
    public GameObject UI_Menu;


    private void Start()
    {
        UI_WIN.SetActive(false);
        UI_Dead.SetActive(false);
        UI_Menu.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        if ((player.position - Destination.position).magnitude < 3f)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
            UI_WIN.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0; 
            UI_Menu.SetActive(true);
        }
        // TODO
        // if (player.getComponent<player_control>.health <= 0f){
        //  Cursor.lockState = CursorLockMode.Confined;
        //  Time.timeScale = 0;
        //  UI_Dead.SetActive(true);
        // }
        //
    }


    public void GameRestart()
    {
        SceneManager.LoadScene(0);
    }

    public void GameQuit()
    {
        Application.Quit();
    }

    public void GameContinue()
    {
        UI_Menu.SetActive(false);
        Time.timeScale = 1;
    }
}
