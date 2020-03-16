using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public GameObject playerPosition;

    public float zombieMovementSpeed = 100;
    public float trackingRange = 5;
    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playerPosition = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.up = playerPosition.transform.position - transform.position;

        if (Vector3.Distance(transform.position, playerPosition.transform.position) <= trackingRange)
        {            
            body.velocity = transform.up * zombieMovementSpeed * Time.deltaTime;
        }
    }
}
