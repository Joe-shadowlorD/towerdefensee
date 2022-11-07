using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemy : MonoBehaviour
{
    public float speed = 5f;
    public int Worth = 50;
    public float Starthealth = 100;
    private float health;

    [Header("Unity gra")]
    public Image healtbar;

    private bool isDead = false;

    private Transform target;
    private int waypointIndex = 0;
   // MoneyManager Moneymanage;
    void Start()
    {
        target = Waypoints.points[0];
        health = Starthealth;
    }

   

    public void TakeDamage(float amount)
    {
        health -= amount;

        healtbar.fillAmount = health / Starthealth;
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        Destroy(gameObject);
    }
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
        if(waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
           // MoneyManager. += 10;
            return;
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }
}
