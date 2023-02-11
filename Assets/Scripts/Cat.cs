using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject player;

    public float aggroRadius = 1f;
    public float deaggroTimer = 1f;
    public float chaseSpeed = 1f;
    public float patrolSpeed = 1f;
    public float catHP = 20f;
    public int catDamage = 10;
    private int capturedRatCount = 0;

    public bool patrolState = true;
    public bool attackState = false;

    //waypoints define the cat's patrol path
    public Transform[] patrolWaypoints;
    private int currentWaypointIndex = 0;

    void LookAt2D(Vector2 target)
    {
        Vector2 current = transform.position;
        var direction = target - current;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void patrol()
    {
        Transform wp = patrolWaypoints[currentWaypointIndex];
        if (Vector2.Distance(transform.position, wp.position) < 0.1f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % patrolWaypoints.Length;
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, wp.position, patrolSpeed * Time.deltaTime);
            LookAt2D(wp.position);
        }
    }

    void chase_player()
    {
        /*
        if (Vector2.Distance(transform.position, player.position) < 0.1f)
        {
            attack_player()
            //wait a while
        }
        */
        
    }

    void attack_player()
    {
        /*
        player.HP = player.HP - catDamage;
        capturedRatCount = capturedRatCount + catDamage;
        */

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
        /*
        if (Vector2.Distance(transform.position, player.position) < aggroRadius) 
        {
            chase_player();
        }
        else
        {
            patrol();
        }
        */
    }
}
