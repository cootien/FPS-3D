using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject SettingPanel;

    //public GameObject MiniMap;

    public VideoPlayer pausePanelVideoPlayer;
    public VideoPlayer settingPanelVideoPlayer;

    public void Pause()
    {
        //MiniMap.SetActive(false);
        PausePanel.SetActive(true);
        SettingPanel.SetActive(false);
        pausePanelVideoPlayer.Play();

        Time.timeScale = 0;
    }
    public void Continue()
    {
        //MiniMap.SetActive(true);

        GameManager.Instance.Click.Play();
        GameManager.Instance.UIOnScreen.SetActive(true);
        PausePanel.SetActive(false);
        SettingPanel.SetActive(false);

        Time.timeScale = 1;
    }
    public void Exit()
    {
        GameManager.Instance.Click.Play();
        Application.Quit();

    }
    public void OpenSettings()
    {
        GameManager.Instance.Click.Play();

        //MiniMap.SetActive(false);
        PausePanel.SetActive(false);
        SettingPanel.SetActive(true);
        GameManager.Instance.currentScreenName = "setting";

        pausePanelVideoPlayer.Pause();
        settingPanelVideoPlayer.Play();
    }
}
