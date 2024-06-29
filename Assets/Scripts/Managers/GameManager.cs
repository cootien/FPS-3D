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
    [SerializeField] public GameObject UIOnScreen;

    [SerializeField] private GameObject IntroVideo;


    public int CurrentLevel;

    //private bool isPaused = false;
    public VideoPlayer pausePanelVideoPlayer;
    public VideoPlayer introVideoPlayer;

    public string currentScreenName = "";

    public AudioSource FunBG;
    public AudioSource HorrorBG;
    public AudioSource Click;
    public AudioSource VoiceOver;



    private void Start()
    {
        CurrentLevel = 1;
        pausePanelVideoPlayer = PausePanel.GetComponent<VideoPlayer>();
        introVideoPlayer = IntroVideo.GetComponent<VideoPlayer>();

        VoiceOver.Play();

        StartCoroutine(PlayIntroVideo());

        //VoiceOver.Play();

    }
    private IEnumerator PlayIntroVideo()
    {
        UIOnScreen.SetActive(false);

        IntroVideo.SetActive(true);
        introVideoPlayer.Play();

        StartCoroutine(ScreenDelay10());
        yield return "";
        //Debug.Log($"inntro playing after 10 {introVideoPlayer.isPlaying}");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (currentScreenName == "main")
            {
                UIOnScreen.SetActive(true);

                Continue();
            }
            else if (currentScreenName == "setting")
            {
                Pause();

            }
            else
            {
                
                Pause();
            }
  
        }
    }

    private void StopGame()
    {
        //Debug.Log("===enter Stop game");

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0; 
    }

    public void OnGameover()
    {
        StopGame();

        HorrorBG.Stop();
        FunBG.Play();
        UIOnScreen.SetActive(false);

        PanelGameOver.SetActive(true);
        //Debug.Log("===enter On LOSE");

    }

    public void OnMissionCompleted()
    {
        Debug.Log("===enter On Mission Completed");
        //StartCoroutine(ScreenDelay());

        StopGame();
        PanelGameWin.SetActive(true);

        HorrorBG.Stop();
        FunBG.Play();

    }

    public void Pause()
    {
        Click.Play();
        UIOnScreen.SetActive(false);

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
        Click.Play();

        UIOnScreen.SetActive(true);

        //MiniMap.SetActive(true);
        PausePanel.SetActive(false);
        currentScreenName = "";
        Time.timeScale = 1;
    }

    //private IEnumerator ScreenDelay()
    //{
    //    yield return new WaitForSeconds(2f); 

    //}
    private IEnumerator ScreenDelay10()
    {
        yield return new WaitForSeconds(10f);
        //Debug.Log($"=inntro playing {introVideoPlayer.isPlaying}");
        IntroVideo.SetActive(false);
        UIOnScreen.SetActive(true);

        //VoiceOver.Stop();

        //Debug.Log("===video finish");
    }

}
