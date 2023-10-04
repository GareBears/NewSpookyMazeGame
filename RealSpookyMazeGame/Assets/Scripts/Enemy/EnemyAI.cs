using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    PlayerController pcontroller;
    FlickerControl lightFlicker;

    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatisPlayer;

    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float sightRange, attackRange, lightRange;
    public bool playerInSightRange, playerInAttackRange, playerInLightRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        pcontroller = GameObject.Find("Player").GetComponent<PlayerController>();
        lightFlicker = GameObject.Find("PFlashLight").GetComponent <FlickerControl>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();
        if (walkPointSet)
        {
            agent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
        if (playerInSightRange)
        {
            lightFlicker.FlickerFalse();
        }
        else
        {
            lightFlicker.FlickerTrue();
        }
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            //ADD ATTACK HERE!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            StartCoroutine("Teleport");
            Debug.Log("I found You");
            pcontroller.LoseLife();
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void LightPlayer()
    {
        if (playerInLightRange)
        {
            lightFlicker.FlickerFalse();
        }
        else
        {
            lightFlicker.FlickerTrue();
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatisPlayer); 
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatisPlayer);
        playerInLightRange = Physics.CheckSphere(transform.position, lightRange, whatisPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
        if (playerInLightRange) LightPlayer();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lightRange);
    }

    IEnumerator Teleport()
    {
        gameObject.transform.position = new Vector3(0f, 0f, 65f);
        yield return new WaitForSeconds(0.01f);
    }
}
