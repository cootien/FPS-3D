using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class PeopleMovement : MonoBehaviour
{
    [SerializeField] private Animator anim;

    private bool _isMovingValue;

    public bool IsMoving
    {
        get => _isMovingValue;
        private set
        {
            if (_isMovingValue == value)
                return;
        }
    }
}
