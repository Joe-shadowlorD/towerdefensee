using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour
{
    private Transform target;
    public float range = 15f;

    [Header("Attributes")]

    public string EnemyTag = "Enemy";
    public Transform PartToRotato;
    public float Turnspeedo = 10f;

    [Header("Unity Setup Fields")]

    public float Firerate = 1f;
    private float firecontdowm = 0f;

    public GameObject bulletoprefeb;
    public Transform FirePointo;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(EnemyTag);
        float ShortDistance = Mathf.Infinity;
        GameObject NearEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < ShortDistance)
            {
                ShortDistance = distanceToEnemy;
                NearEnemy = enemy;

            }
        }

        if(NearEnemy != null && ShortDistance <= range)
        {
            target = NearEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        // Targeto lock on Desne
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(PartToRotato.rotation, lookRotation, Time.deltaTime * Turnspeedo).eulerAngles;
        PartToRotato.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (firecontdowm <= 0f)
        {
            shoot();
            firecontdowm = 1f / Firerate;
        }
        firecontdowm -= Time.deltaTime;
    }

    void shoot()
    {
        Debug.Log("SHOOTOOOO");
        GameObject bulletGO = (GameObject) Instantiate(bulletoprefeb, FirePointo.position, FirePointo.rotation);
        Bullete bullet = bulletGO.GetComponent<Bullete>();

        if (bullet != null)
            bullet.Chase(target);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
