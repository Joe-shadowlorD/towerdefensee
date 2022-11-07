using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapontoggle : MonoBehaviour
{
    public GameObject Arm;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            Arm.SetActive(true);


        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Arm.SetActive(true);

        }
    }
}
