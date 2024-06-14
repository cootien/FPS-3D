using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private UnityEvent onDie;
    [SerializeField] private Animator anim;

    public UnityEvent<int, int> onHealthChanged;
    public int MaxHP;

    private int _healthPoint;  

    private bool IsDead => _healthPoint <=0 ;

    public int HealthPoint
    {
        get => _healthPoint;
        set
        {
            _healthPoint = value;
            onHealthChanged.Invoke(_healthPoint, MaxHP);
        }

    }
    protected virtual void Start()
    {
        _healthPoint = MaxHP;
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
    protected virtual void Die()
    {
        Debug.Log("===enter Die - Health");
        if (anim != null)
        {
            
            anim.SetTrigger("Die");
            Debug.Log("===Set trigger Die");
        }
        onDie.Invoke();
        Debug.Log("===On die.Invoke");
    }
}
