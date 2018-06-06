using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{

    public Transform waypointGroup;
    public float moveSpeed = 5f;
    public float closeness = 1f; // how close before switching to new target

    private Transform[] waypoints;
    private int currentIndex = 0;


    // Use this for initialization
    void Start()
    {
        // length is assigned to amount of children in waypointGroup
        int length = waypointGroup.childCount;
        // waypoints is assigned array
        waypoints = new Transform[length];

        //forward loop for way points
        for (int i = 0; i < length; i++)
        {
            //assign waypoints (number) to children in waypointGroup (according to order)
            waypoints[i] = waypointGroup.GetChild(i);
        }

    }


    void Update()
    {

        Transform current = waypoints[currentIndex];

        Vector3 position = transform.position;
        Vector3 direction = current.position - position;
        position += direction.normalized * moveSpeed * Time.deltaTime;

        transform.position = position;

        float distance = Vector3.Distance(position, current.position);

        //If close enough to way point
        if (distance <= closeness)
        {
            // Switch to next waypoint
            currentIndex++;
        }

        //If the current index exceeds the amount of waypoints
        if (currentIndex >= waypoints.Length)
        {
            //Loop back to the start
            currentIndex = 0;
        }

    }
}
