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
    [SerializeField] private float timeBetweenAttacks = 1f;
    private float timeSinceLastAttack = 0f;
    [SerializeField] private float aggroDisallowedDuration = 2f;
    private bool runAggroDisallowedTimer = false;
    private float aggroDisallowedTimer = 0f;
    [SerializeField] private float dashSpeed = 8f;

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
        Debug.Log("Chasing player");
        float angle = CalculateAngle(player.transform.position);
        Debug.Log(angle);

        rb.velocity = new Vector2(chaseSpeed * Mathf.Cos(angle), chaseSpeed * Mathf.Sin(angle));

        //var toPlayer = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        //rb.velocity = toPlayer;
        LookAt2D(player.transform.position);
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
        var toPlayer = new Vector2(player.transform.position.x - transform.position.x, player.transform.position.y - transform.position.y);
        float vectorMagnitude = toPlayer.magnitude;
        var unitToPlayer = new Vector2((toPlayer.x / vectorMagnitude), (toPlayer.y / vectorMagnitude));
        rb.velocity = new Vector2(toPlayer.x * dashSpeed, toPlayer.y * dashSpeed);
        //rb.velocity = new Vector2(0, 0); 
    }

    void escapingCheck()
    {
        //player is outside aggroRadius, escapeTimer begins incrementing
        escapeTimer = escapeTimer + Time.deltaTime;

        if (escapeTimer >= timeToDeaggro)
        {
            //player has escaped: cat returns to patrol, and escapeTimer is reset to 0 for the next aggro cycle
            deaggroOffPlayer();
            escapeTimer = 0f;
        }
    }

    bool timeBetweenAttacksCheck()
    {
        //returns True if enough time has passed, and another dash attack is allowed
        if (timeSinceLastAttack >= timeBetweenAttacks)
        {
            timeSinceLastAttack = 0f;
            return true;
        }
        return false;
    }

    void aggroOnPlayer()
    {
        if (aggroAllowedCheck()) 
        {
            runAggroDisallowedTimer = false;
            patrolState = false;
            attackState = true;
        }
    }

    bool aggroAllowedCheck()
    {
        if (runAggroDisallowedTimer == false)
        {
            Debug.Log("Aggro allowed");
            return true;
        }
        Debug.Log("Aggro not allowed");
        return false;
    }

    void deaggroOffPlayer()
    {
        patrolState = true;
        attackState = false;
        runAggroDisallowedTimer = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Aggro disallowed timer at: " + aggroDisallowedTimer);
        Debug.Log("Is the aggro disallowed timer running?? " + runAggroDisallowedTimer);
        Debug.Log("Attack state is: " + attackState);
        timeSinceLastAttack = timeSinceLastAttack + Time.deltaTime;
        //rb.velocity = new Vector2(0, 0);
        if (runAggroDisallowedTimer == true)
        {
            aggroDisallowedTimer = aggroDisallowedTimer + Time.deltaTime;
            if (aggroDisallowedTimer >= aggroDisallowedDuration)
            {
                aggroDisallowedTimer = 0f;
                runAggroDisallowedTimer = false;
            }
        }

        if (patrolState)
        {
            if (Vector2.Distance(transform.position, player.transform.position) < aggroRadius)
            {
                //if player enters aggroRadius, switch to attackState
                aggroOnPlayer();
            }
            else
            {
                //if player is not in aggroRadius, patrol passively
                patrol();
            }
        }
        else if (attackState)
        {
            if (Vector2.Distance(transform.position, player.transform.position) < attackRadius)
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
                        deaggroOffPlayer();
                    }
                }
            }
            else if ( (Vector2.Distance(transform.position, player.transform.position) > attackRadius) && (Vector2.Distance(transform.position, player.transform.position) < aggroRadius) )
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

    private float CalculateAngle(Vector2 playerpos)
    {
        float x = playerpos.x - transform.position.x;
        float y = playerpos.y - transform.position.y;

        return Mathf.Atan2(y, x);
    }
}
