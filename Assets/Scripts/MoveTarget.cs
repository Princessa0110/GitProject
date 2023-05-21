using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    public GameObject[] waypoints;
    private int currentTarget = 0;
    private float rotSpeed;
    public float speed;
    private float waypointRadius = 1;
    void Update()
    {
        if (Vector3.Distance(waypoints[currentTarget].transform.position, transform.position) < waypointRadius)
        {
            currentTarget++;
            if (currentTarget >= waypoints.Length)
            {
                currentTarget = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentTarget].transform.position,
        speed * Time.deltaTime);
    }
}