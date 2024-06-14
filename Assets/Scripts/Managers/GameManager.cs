using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; 

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject PanelGameOver;
    [SerializeField] private GameObject PanelGameWin;
    public int CurrentLevel;
    

    private void Start()
    {
        CurrentLevel = 1; 
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    private void StopGame()
    {
        Debug.Log("===enter Stop game");

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0; 
    }
    public void OnGameover()
    {
        StopGame();
        PanelGameOver.SetActive(true);
    }

    public void OnMissionCompleted()
    {
        Debug.Log("===enter On Mission Completed");

        StopGame();
        PanelGameWin.SetActive(true);
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

}
