using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject SettingPanel;

    public VideoPlayer pausePanelVideoPlayer;
    public VideoPlayer settingPanelVideoPlayer;

    public void Pause()
    {
        PausePanel.SetActive(true);
        SettingPanel.SetActive(false);
        pausePanelVideoPlayer.Play();

        Time.timeScale = 0;
    }
    public void Continue()
    {
        PausePanel.SetActive(false);
        SettingPanel.SetActive(false);

        Time.timeScale = 1;
    }
    public void Exit()
    {
        Debug.Log(" game exit");
        Application.Quit();
    }
    public void OpenSettings()
    {
        PausePanel.SetActive(false);
        SettingPanel.SetActive(true);
        GameManager.Instance.currentScreenName = "setting";

        pausePanelVideoPlayer.Pause();
        settingPanelVideoPlayer.Play();
    }
}
