using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public int damage = 50;
    public GameObject impactEffect;

    public int worth = 50;

    public void Seek (Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisframe = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisframe)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisframe, Space.World);

    }

    void HitTarget ()
    {
       
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 1f);

        if (target.CompareTag("Enemy"))
        {
            PlayerStats.AddMoney(worth);
            Destroy(target.gameObject);
        }
        

        Destroy(gameObject);
    }

    void Damage (Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();
        if (e != null)
        {
            e.Takedamage(damage);
        }
        
    }
}
