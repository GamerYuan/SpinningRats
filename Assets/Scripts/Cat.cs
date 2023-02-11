using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    //OBJECT REFERENCES
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject player;

    //CAT FIELDS
    [SerializeField] private float aggroRadius = 1f;
    [SerializeField] private float deaggroTimer = 1f;
    [SerializeField] private float chaseSpeed = 1f;
    [SerializeField] private float patrolSpeed = 1f;
    [SerializeField] private float catHP = 20f;
    [SerializeField] private int catDamage = 10;
    [SerializeField] private int capturedRatCount = 0;

    //ATTACK & PATROL VARIABLES
    private bool patrolState = true;
    private bool attackState = false;
    [SerializeField] private int numberOfAttacksPerAggro = 2;
    private int attackedTimes = 0;
    [SerializeField] private float attackRadius = 0.5f; //cat will attempt dash attack when within attackRadius
    [SerializeField] private float timeToDeaggro = 3f;
    private float escapeTimer = 0f; //timer to see if player escapes cat by remaining outside aggroRadius
    [SerializeField] private float timeBetweenAttacks = 2f;
    private float timeSinceLastAttack = 0f; 


    //WAYPOINTS FOR CAT PATROL PATH
    [SerializeField] private Transform[] patrolWaypoints;
    private int currentWaypointIndex = 0;

    //For cat to look at the target it is heading towards
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
        transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
        LookAt2D(player.position);
    }

    void damage_player()
    {
        /*
        player.HP = player.HP - catDamage;
        capturedRatCount = capturedRatCount + catDamage;
        */

    }

    void attemptDashAttack()
    {

    }

    void escapingCheck()
    {
        //player is outside aggroRadius, escapeTimer begins incrementing
        escapeTimer = escapeTimer + Time.deltaTime;

        if (escapeTimer >= timeToDeaggro)
        {
            //player has escaped: cat returns to patrol, and escapeTimer is reset to 0 for the next aggro cycle
            patrolState = true;
            attackState = false;
            escapeTimer = 0f;
        }
    }

    void timeBetweenAttacksCheck()
    {
        //returns True if enough time has passed, and another dash attack is allowed
        if (timeSinceLastAttack >= timeBetweenAttacks)
        {
            timeSinceLastAttack = 0f;
            return true;
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        patrolState = true;
        attackState = false;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastAttack = timeSinceLastAttack + Time.deltaTime
        if (patrolState)
        {
            if (Vector2.Distance(transform.position, player.position) < aggroRadius)
            {
                //if player enters aggroRadius, switch to attackState
                patrolState = false;
                attackState = true;
            }
            else
            {
                //if player is not in aggroRadius, patrol passively
                patrol();
            }
        }
        else if (attackState)
        {
            if (Vector2.Distance(transform.position, player.position) < attackRadius)
            {
                escapeTimer = 0f;
                if (timeBetweenAttacksCheck())
                {
                    //if player enters attackRadius AND enough time has passed since last attack, cat attempts dash attack
                    attemptDashAttack();
                    attackedTimes++;
                    if (attackedTimes >= numberOfAttacksPerAggro)
                    {
                        //if max amount of dash attacks have been attempted, cat gives up and goes back to patrolling
                        attackState = false;
                        patrolState = true;
                        //TIMER WHERE CAT CANT BE RE-AGGROED 
                    }
                }
            }
            else if ( (Vector2.Distance(transform.position, player.position) > attackRadius) && (Vector2.Distance(transform.position, player.position) < aggroRadius) )
            {
                escapeTimer= 0f;
                //if player is between attackRadius and aggroRadius, cat just chases player
                chase_player();
            }
            else
            {
                //timer stuff for deaggroing as player remains outside aggroRadius for a duration
                escapingCheck();
            }
        }

    }
}
