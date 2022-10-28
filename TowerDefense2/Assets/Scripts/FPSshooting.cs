using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSshooting : MonoBehaviour
{
    
    public Camera fpscam;
    public float damage = 10f;
    public float range = 100f;
    //public ParticleSystem muzzleflash;
    public GameObject impacteffect;
    public GameObject BulletPrefab;
    public GameObject FirePoint;
    public float firerate = 15f;
    private float nextshot = 0f;
    public float ammo = 20;
    float decrease = 0.0005f;


    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1") && Time.time >= nextshot)
        {
            if (ammo > 0)
            {
                nextshot = Time.time + 1f / firerate;
                shoot();
                ammo -= 1;
            }

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ammo = 20;
            Debug.Log("reloaded");
        }

        void shoot()
        {
           
            RaycastHit hit;
            if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
            {
                //muzzleflash.Play();

                Debug.Log(hit.transform.name);
                enemy target2 = hit.transform.GetComponent<enemy>();



                GameObject impactGO = Instantiate(impacteffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 2f);
            }
        }
    }
}
    
