﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispFollow : MonoBehaviour
{
    public float followSpeed = 1f;
    public float stoppingDistance = 0.5f;
    public float attackSpeed = 1f;
    
    private Transform playerTarget;
    private Vector3 attackTarget;
    
    private bool isAttacking = false;

    void Start()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        attackTarget = transform.position;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isAttacking)
        {
            Follow();

            if (Input.GetMouseButton(0))
            {
                attackTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                attackTarget.z = transform.position.z;
                isAttacking = true;
            }
        }
        if (isAttacking)
        {
            Attack();
        }
    }

    void Follow()
    {
        if (Vector2.Distance(transform.position, playerTarget.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerTarget.position, followSpeed * Time.deltaTime);
        }
    }
    
    void Attack()
    {
        if (transform.position != attackTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, attackTarget, attackSpeed * Time.deltaTime);
        }
        else
        {
            isAttacking = false;
        }
    }
}