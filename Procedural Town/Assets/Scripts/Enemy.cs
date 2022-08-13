using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private bool walkPointSet = false;
    private NavMeshAgent agent;

    private Vector3 walkPoint;

    public float walkPointRange;

    public LayerMask GroundMask;
    public Animation fox;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        Patroling();
        if (!Physics.Raycast(transform.position, -transform.up, 2f, GroundMask))
        {
            walkPointSet = true;
            fox.Play("run");

        }
    }

    private void Patroling()
    {
        //判断当前是否有巡逻点
        if (!walkPointSet) SearchWalkPoint();
        //向下一个巡逻点出发
        if (walkPointSet) agent.SetDestination(walkPoint);

        //判断是否到达
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
            fox.Play("idle1");
        }
    }


    private void SearchWalkPoint()
    {
        //设置巡逻点
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        //判断是否走出去了
        if (Physics.Raycast(walkPoint, -transform.up, 2f, GroundMask))
        {
            walkPointSet = true;
            fox.Play("run");
        }

    }

}
