using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private UnityEvent onDie;
    [SerializeField] private Animator anim;

    public UnityEvent<int, int> onHealthChanged;
    public int maxHP;
    private int _healthPoint;  

    private bool IsDead => _healthPoint <=0 ;
    
    public int HealthPoint
    {
        get => _healthPoint;
        set
        {
            _healthPoint = value;
            onHealthChanged.Invoke(_healthPoint, maxHP);
        }
    }
    public void Start()
    {
        _healthPoint = maxHP;
    }
    public void TakeDamage(int damage)
    {
        if (IsDead) return;
        HealthPoint -= damage;
        if (IsDead)
        {
            Die();
        }
    }
    public void Die()
    {
        if (IsDead)
        {
            anim.SetTrigger("Die");
            Debug.Log("Enemy Died");
        }
        onDie.Invoke();
    }
}
