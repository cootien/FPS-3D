using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoints : MonoBehaviour
{
    [SerializeField] private float waypoinnt;

    private void Start()
    {
        
    }
    private void OnDrawGizmos()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Gizmos.DrawSphere(GetPointPosition(i), 1f);
            Gizmos.DrawLine(GetPointPosition(i), GetPointPosition(getNextPointIndex(i)));
        }
    }
    public int getNextPointIndex( int currentPoint)
    {
        if (currentPoint == transform.childCount - 1) //transform.count-1 : last point
        {
            return 0;
        }
        else { return currentPoint + 1; }

    }
    public Vector3 GetPointPosition(int wayPointIndex)
    {
        return transform.GetChild(wayPointIndex).position;
        
    }
}
