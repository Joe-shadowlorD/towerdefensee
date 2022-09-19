using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullete : MonoBehaviour
{
    public Transform target;

    public float speed = 70f;
    public GameObject impactEffect;

    public void Chase(Transform _target)
    {
        target = _target;
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

        Destroy(target.gameObject);

        Destroy(gameObject);
    }
}
