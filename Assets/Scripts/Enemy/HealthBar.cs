using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image imgHealth;
    private float reduceSpeed = 2f;

    private float _target = 1;

    public void UpdateUI(int currentHP, int maxHP)
    {
        _target = (float)currentHP / (float)maxHP;
        Debug.Log($"===Curret HP -updateUI: { currentHP}");
        Debug.Log($"===Max HP -updateUI: { maxHP}");

        imgHealth.fillAmount = Mathf.MoveTowards(imgHealth.fillAmount, _target, reduceSpeed * Time.deltaTime);

    }
    //private void Update()
    //{
    //    imgHealth.fillAmount = Mathf.MoveTowards(imgHealth.fillAmount, _target, reduceSpeed * Time.deltaTime);
       
    //}
}