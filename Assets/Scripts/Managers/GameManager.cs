using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Video;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject PanelGameOver;
    [SerializeField] private GameObject PanelGameWin;
    [SerializeField] private GameObject SoundUIManager;
    public int CurrentLevel;

    private bool isPaused = false;
    public VideoPlayer pausePanelVideoPlayer;

    public string currentScreenName = "";


    private void Start()
    {
        CurrentLevel = 1;
        pausePanelVideoPlayer = PausePanel.GetComponent<VideoPlayer>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (currentScreenName == "main")
            {
                Continue();
            }
            else if (currentScreenName == "setting")
            {
                Pause();
                Debug.Log(" enter setting");

            }
            else
            {
                Pause();
            }
  
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
        //StartCoroutine(ScreenDelay());

        StopGame();
        PanelGameOver.SetActive(true);
    }

    public void OnMissionCompleted()
    {
        Debug.Log("===enter On Mission Completed");
        StartCoroutine(ScreenDelay());

        StopGame();
        PanelGameWin.SetActive(true);
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        currentScreenName = "main";
        PausePanel.SetActive(true);
        pausePanelVideoPlayer.Play();

        SoundUIManager.SetActive(false);
        //Debug.Log($"pause vid play: {pausePanelVideoPlayer.isPlaying}");
        Time.timeScale = 0;
    }
    public void Continue()
    {
        PausePanel.SetActive(false);
        currentScreenName = "";
        Time.timeScale = 1;
    }

    private IEnumerator ScreenDelay()
    {
        yield return new WaitForSeconds(2f); 

    }

}
