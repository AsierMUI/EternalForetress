using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class enemyMovement : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private int targetIndex = 0; 
    public float movementSpeed = 4;
    public float rotationSpeed = 6;
    public int health = 100; 

    private void Awake()
    {
        GetWaypoints();
    }

    void Update()
    {
        Movement();
        LookAt();
    }

    private void Movement()
    {
        if (targetIndex >= waypoints.Count) return; 

        transform.position = Vector3.MoveTowards(transform.position, waypoints[targetIndex].position, movementSpeed * Time.deltaTime);
        var distance = Vector3.Distance(transform.position, waypoints[targetIndex].position);
        if (distance <= 0.1f)
        {
            targetIndex++;
            if (targetIndex >= waypoints.Count)
            {
                Destroy(gameObject); 
            }
        }
    }

    private void LookAt()
    {
        if (targetIndex < waypoints.Count) 
        {
            var dir = waypoints[targetIndex].position - transform.position;
            if (dir != Vector3.zero) 
            {
                var rootTarget = Quaternion.LookRotation(dir);
                transform.rotation = Quaternion.Slerp(transform.rotation, rootTarget, rotationSpeed * Time.deltaTime);
            }
        }
    }

    private void GetWaypoints()
    {
        waypoints.Clear();
        var rootWaypoint = GameObject.Find("WaypointsContainer").transform;
        for (int i = 0; i < rootWaypoint.childCount; i++) 
        {
            waypoints.Add(rootWaypoint.GetChild(i));
        }
    }
}