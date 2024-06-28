using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissionManager : Singleton<MissionManager>
{
    [SerializeField] private MissionSO missionSO;
    [SerializeField] private TextMeshProUGUI textMission;

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
        //yield return VerifyPlayerExit();
         //yield return new WaitForSeconds(3f);
        Debug.Log("===VerifyMission");
        GameManager.Instance.OnMissionCompleted();
    }
    
    public void OnEnemyKilled()
    {
        currentKill++;
        
        textMission.text = $"{currentKill} " + $"  {requiredKill}";
        //Debug.Log("======= OnZombieKilled");
    }
    private IEnumerator VerifyEnemyKill()
    {
        //currentKill = 0;
        //textMission.text = $"{currentKill}/ " + $"{requiredKill}";
        yield return new WaitUntil(() => IsCompletedMission());
    }
    private void InitMisson()
    {
        //Debug.Log("===enter InitMisson");
        currentKill = 0;


        var index = GameManager.Instance.CurrentLevel - 1;
        var numKillMission = missionSO.listMission[index].NumKill;
        requiredKill = numKillMission;
        //Debug.Log($"===requiredKill: {requiredKill}");

        textMission.text = $"{currentKill} " + $"  {requiredKill}";

    }
    bool IsCompletedMission()
    {
        return currentKill >= requiredKill;
        //Debug.Log($"IscompletedMission: {IsCompletedMission}");

    }
    
}
