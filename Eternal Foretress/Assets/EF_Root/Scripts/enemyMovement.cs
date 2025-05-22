using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class enemyMovement : MonoBehaviour
{

    public List<Transform> waypoints = new List<Transform>();
    private int targetIndex = 1;
    public float movementSpeed = 4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        LookAt();
    }

    private void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[targetIndex].position, movementSpeed * Time.deltaTime);
        var distance = Vector3.Distance(transform.position, waypoints[targetIndex].position);
        if (distance <= 0.1f)
        {
            if (targetIndex >= waypoints.Count - 1)
            {
                return;
            }
            targetIndex++;
        }

    }

    private void LookAt()
    {
        transform.LookAt(waypoints[targetIndex]);
    }

}
