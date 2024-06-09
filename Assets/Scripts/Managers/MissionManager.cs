using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionManager : Singleton<MissionManager>
{
    [SerializeField] private MissionSO missionSO;

    private int requiredKill;
    private int currentKill;
    private bool isPlayerExit;

    private void Start()
    {
        InitMisson();
        StartCoroutine(VerifyMissions());
    }

    IEnumerator VerifyMissions()
    {
        yield return VerifyEnemyKill();
        yield return VerifyPlayerExit();
        // yield return new WaitForSeconds(3f);
        GameManager.Instance.OnMissionCompleted();
    }
    private IEnumerator VerifyPlayerExit()
    {
        //textMission.text = $"Find Exit Door";
        //exitDoor.onPlayerEnter.AddListener(OnPlayerExit);
        yield return new WaitUntil(() => isPlayerExit);
        //exitDoor.onPlayerEnter.RemoveListener(OnPlayerExit);
    }
    public void OnEnemyKilled()
    {
        currentKill++;
        //textMission.text = $"Kill {requiredKill} zombie" + $" - Current Kill : {currentKill}";
        //Debug.Log("======= OnZombieKilled");
    }
    private IEnumerator VerifyEnemyKill()
    {
        //currentKill = 0;
        //textMission.text = $"Kill {requiredKill} zombie" + $" - Current Kill : {currentKill}";
        yield return new WaitUntil(() => IsCompletedMission());
    }
    private void InitMisson()
    {
        var index = GameManager.Instance.CurrentLevel - 1;
        var numKillMission = missionSO.listMission[index].NumKill;
        requiredKill = numKillMission;
    }
    bool IsCompletedMission()
    {
        return currentKill >= requiredKill;
    }
    private void OnPlayerExit()
    {
        isPlayerExit = true;
    }
}
