using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camswitch : MonoBehaviour
{
    public GameObject Cam1;
    public GameObject Cam2;
    // Update is called once per frame





    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }


    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Cam1.SetActive(true);
            Cam2.SetActive(false);
            print("space key was pressed");
        }




        if (Input.GetKeyDown(KeyCode.F))
        {

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Cam1.SetActive(false);
            Cam2.SetActive(true);
            print("F was pressed");
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }

        }



    }
}
