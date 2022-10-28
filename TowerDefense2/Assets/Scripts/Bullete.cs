using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullete : MonoBehaviour
{
    public Transform target;

    public float speed = 70f;
    public float ExplosioRadiuus = 0f;
    public GameObject impactEffect;

    private GameObject _gameMaster;
    private MoneyManager _moneyManager;


    public void Chase(Transform _target)
    {
        target = _target;
    }

    private void Start()
    {
        _gameMaster = GameObject.FindWithTag("GameMaster");
        _moneyManager = _gameMaster.GetComponent<MoneyManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.position - transform.position;
        float distanceToFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceToFrame)
        {
            Hittedtarget();
            return;
        }

        transform.Translate(dir.normalized * distanceToFrame, Space.World);

    }

    void Hittedtarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        if(ExplosioRadiuus > 0f)
        {
            Boom();
        }
        else
        {
            Damage(target);
        }


        Destroy(gameObject);
    }
    public void Boom()
    {
        Collider[] HittedObjects = Physics.OverlapSphere(transform.position, ExplosioRadiuus);
        foreach (Collider collider in HittedObjects)
        {
            if(collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }

    public void Damage(Transform enemy)
    {
        int worth = enemy.GetComponent<enemy>().Worth;
        _moneyManager.MoneyAdd(worth);
        Destroy(enemy.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, ExplosioRadiuus);
    }
}
