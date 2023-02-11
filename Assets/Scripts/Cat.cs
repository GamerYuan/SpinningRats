using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    Rigidbody rb;
    public float aggroRadius = 1f;
    public float deaggroTimer = 1f;
    public float chaseSpeed = 1f;
    public float patrolSpeed = 1f;
    public float catHP = 20f;
    public int capturedRatCount = 0;

    //waypoints define the cat's patrol path
    public Transform[] patrolWaypoints;
    private int currentWaypointIndex = 0;


    void patrol()
    {
        Transform wp = patrolWaypoints[currentWaypointIndex];
        if (Vector2.Distance(transform.position, wp.position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % patrolWaypoints.Length;
        }
        else
        {
            rb.MovePosition(wp.position);
        }
    }

    void chase_player()
    {

    }

    void attack_player()
    {

    }

    void return_to_patrol_path()
    {

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
