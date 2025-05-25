using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 10f;

    public int health = 100;

    private Transform target;
    private int wavepointIndex = 0;

    void Start ()
    {
        target = Waypoint.points[0];
    }

    public void Takedamage (int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }
    void Die ()
    {
        Destroy(gameObject);
    }



    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= Waypoint.points.Length - 1)
        {
            Endpath();
            return;
        }

        wavepointIndex++;
        target = Waypoint.points[wavepointIndex];
    }

    void Endpath ()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
