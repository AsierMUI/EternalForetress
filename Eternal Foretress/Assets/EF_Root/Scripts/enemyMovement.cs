using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class enemyMovement : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private int targetIndex = 0; // Comienza desde el primer waypoint
    public float movementSpeed = 4;
    public float rotationSpeed = 6;
    public int health = 100; // Puntos de vida del enemigo

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
        if (targetIndex >= waypoints.Count) return; // Verifica si ha llegado al último waypoint

        transform.position = Vector3.MoveTowards(transform.position, waypoints[targetIndex].position, movementSpeed * Time.deltaTime);
        var distance = Vector3.Distance(transform.position, waypoints[targetIndex].position);
        if (distance <= 0.1f)
        {
            targetIndex++;
            if (targetIndex >= waypoints.Count)
            {
                Destroy(gameObject); // Destruye el enemigo al llegar al último waypoint
            }
        }
    }

    private void LookAt()
    {
        if (targetIndex < waypoints.Count) // Asegúrate de que hay waypoints
        {
            var dir = waypoints[targetIndex].position - transform.position;
            if (dir != Vector3.zero) // Verifica que la dirección no sea cero
            {
                var rootTarget = Quaternion.LookRotation(dir);
                transform.rotation = Quaternion.Slerp(transform.rotation, rootTarget, rotationSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(10); // Reduce la salud en 10 (ajusta según sea necesario)
            Destroy(other.gameObject); // Destruye la bala
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject); // Destruye el enemigo
        }
    }

    private void GetWaypoints()
    {
        waypoints.Clear();
        var rootWaypoint = GameObject.Find("WaypointsContainer").transform;
        for (int i = 0; i < rootWaypoint.childCount; i++) // Cambiado a rootWaypoint
        {
            waypoints.Add(rootWaypoint.GetChild(i));
        }
    }
}