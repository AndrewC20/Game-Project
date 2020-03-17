using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowMovement : MonoBehaviour
{
    Vector3 mousePosition;

    void Start()
    {
    }
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        Vector3 direction = mousePosition - transform.position;
        direction.Normalize();

        transform.up = direction;
    }
}
