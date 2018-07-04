using UnityEngine;
using System.Collections;


public class EnemyMovement : MonoBehaviour
{
    public float speed = 10f;

    private Transform target;
    private int wavepointIndex = 0;

    

    void Start()
    {

        target = TurnPoints.points[0];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
         transform.Translate(dir.normalized *speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= TurnPoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        target = TurnPoints.points[wavepointIndex];
    }

   
}