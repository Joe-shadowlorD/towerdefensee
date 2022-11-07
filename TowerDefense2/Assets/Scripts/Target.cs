using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    
    public float Starthealth = 100;
    private float health;

    [Header("Unity gra")]
    public Image healtbar;

    private bool isDead = false;

    void Start()
    {
        
        health = Starthealth;
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health < 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
